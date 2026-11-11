using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillList(int? categoryId, string? search)
        {
            var query = _context.Skills
        .Include(x => x.SkillCategory)
        .AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.SkillCategoryId == categoryId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.SkillName!.Contains(search));
            }

            var values = query
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            ViewBag.Categories = _context.SkillCategories
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            ViewBag.SelectedCategory = categoryId;
            ViewBag.Search = search;

            ViewBag.TotalSkillCount = _context.Skills.Count();

            ViewBag.ActiveSkillCount = _context.Skills
                .Count(x => x.IsActive);

            ViewBag.CategoryCount = _context.SkillCategories.Count();

            return View("SkillList", values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            ViewBag.Categories = _context.SkillCategories
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.SkillCategories
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.DisplayOrder)
                    .ToList();

                return View(skill);
            }

            skill.CreatedDate = DateTime.Now;
            skill.IsActive = true;

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = _context.Skills
                .Include(x => x.SkillCategory)
                .FirstOrDefault(x => x.SkillId == id);

            if (skill == null)
                return NotFound();

            ViewBag.Categories = _context.SkillCategories
                .Where(x => x.IsActive || x.SkillCategoryId == skill.SkillCategoryId)
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.SkillCategories
                    .Where(x => x.IsActive || x.SkillCategoryId == skill.SkillCategoryId)
                    .OrderBy(x => x.DisplayOrder)
                    .ToList();

                return View(skill);
            }

            var existingSkill = _context.Skills
                .FirstOrDefault(x => x.SkillId == skill.SkillId);

            if (existingSkill == null)
                return NotFound();

            existingSkill.SkillName = skill.SkillName;
            existingSkill.SkillValue = skill.SkillValue;
            existingSkill.SkillColor = skill.SkillColor;
            existingSkill.SkillIcon = skill.SkillIcon;
            existingSkill.Description = skill.Description;
            existingSkill.ExperienceYear = skill.ExperienceYear;
            existingSkill.DisplayOrder = skill.DisplayOrder;
            existingSkill.IsActive = skill.IsActive;
            existingSkill.SkillCategoryId = skill.SkillCategoryId;
            existingSkill.UpdatedDate = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("SkillList");
        }

        [HttpPost]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill == null)
                return NotFound();
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}
