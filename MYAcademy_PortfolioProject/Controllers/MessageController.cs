using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(Message message)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage);

                    TempData["MessageError"] = string.Join(" | ", errors);

                    return RedirectToAction("Index", "Default");
                }

                message.SendDate = DateTime.Now;
                message.IsRead = false;

                _context.Messages.Add(message);

                int result = _context.SaveChanges();

                if (result > 0)
                {
                    TempData["MessageSuccess"] = "Mesaj başarıyla gönderildi.";
                }
                else
                {
                    TempData["MessageError"] = "Mesaj kaydedilemedi.";
                }
            }
            catch (Exception ex)
            {
                // Geliştirme aşamasında gerçek hatayı görmek için:
                TempData["MessageError"] = ex.InnerException?.Message ?? ex.Message;
            }

            return RedirectToAction("Index", "Default");
        }
    }
}