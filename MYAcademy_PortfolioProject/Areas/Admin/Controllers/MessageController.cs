
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        // Mesajları listele
        public IActionResult MessageList()
        {
            var values = _context.Messages
                .OrderByDescending(x => x.SendDate)
                .ToList();

            return View(values);
        }

        // Mesaj detayını görüntüle
        public IActionResult MessageDetails(int id)
        {
            var value = _context.Messages.Find(id);

            if (value == null)
                return NotFound();

            // Mesaj açıldığında otomatik okundu yap
            value.IsRead = true;
            _context.SaveChanges();

            return View(value);
        }

        // Mesajı okunmadı olarak işaretle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkAsUnread(int id)
        {
            var value = _context.Messages.Find(id);

            if (value == null)
                return NotFound();

            value.IsRead = false;
            _context.SaveChanges();

            return RedirectToAction("MessageList");
        }

        // Mesajı sil
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);

            if (value == null)
            {
                TempData["MessageError"] = "Mesaj bulunamadı.";
                return RedirectToAction(nameof(MessageList));
            }

            _context.Messages.Remove(value);
            _context.SaveChanges();

            TempData["MessageSuccess"] = "Mesaj başarıyla silindi.";

            return RedirectToAction(nameof(MessageList));
        }
    }
}
