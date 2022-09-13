using Business.Abstract;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "admin")]
    public class MusteriController : Controller
    {
        private readonly ICustomerService service;
        public MusteriController(ICustomerService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllCustomersAsync().Result);
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Customers data)
        {
            return View(service.AddAsync(data).Result);
        }
        [Route("/admin/musteri/update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetFirstCustomersAsync(Id).Result);
        }
        [HttpPost]
        [Route("/admin/musteri/update/{Id}")]
        public IActionResult Update(int Id, CustomerIsAdminDTO data)
        {
            ViewBag.Message = service.UpdateAsync(data).Result;
            return View(service.GetFirstCustomersAsync(Id).Result);
        }
        [Route("/admin/musteri/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            TempData["Message"] = service.DeleteAsync(Id).Result;
            return Redirect("/admin/Musteriler");
        }
    }
}
