using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ProjectList()
        {
            var values = _context.Projects.Include(x => x.Category).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProject(Project project)
        {
            // Category nesnesi formdan gönderilmediği için doğrulamadan çıkarıyoruz.
            ModelState.Remove(nameof(Project.Category));

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(project);
            }

            var categoryExists = _context.Categories
                .Any(x => x.CategoryId == project.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError("CategoryId", "Lütfen geçerli bir kategori seçiniz.");

                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(project);
            }

            try
            {
                _context.Projects.Add(project);
                _context.SaveChanges();

                TempData["Success"] = "Proje başarıyla eklendi.";

                return RedirectToAction("ProjectList");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Kayıt sırasında hata oluştu: " + ex.Message);

                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(project);
            }
        }

        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var project = _context.Projects
                .Include(x => x.Category)
                .FirstOrDefault(x => x.ProjectId == id);

            if (project == null)
                return NotFound();

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(project);
        }

        [HttpPost]
        public IActionResult UpdateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(project);
            }

            var existingProject = _context.Projects
                .FirstOrDefault(x => x.ProjectId == project.ProjectId);

            if (existingProject == null)
                return NotFound();

            var categoryExists = _context.Categories
                .Any(x => x.CategoryId == project.CategoryId);

            if (!categoryExists)
            {
                ModelState.AddModelError("CategoryId", "Geçerli bir kategori seçiniz.");

                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(project);
            }

            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.GithubUrl = project.GithubUrl;
            existingProject.CoverImageUrl = project.CoverImageUrl;
            existingProject.CategoryId = project.CategoryId;

            _context.SaveChanges();

            return RedirectToAction("ProjectList");
        }

        [HttpPost]
        public IActionResult DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
                return NotFound();

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction("ProjectList");

        }
    }
}
