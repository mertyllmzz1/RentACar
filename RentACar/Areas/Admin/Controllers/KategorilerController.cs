using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "admin")]
    public class KategorilerController : Controller
    {
        private readonly ICategoryService service;
        public KategorilerController(ICategoryService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAllCategoriesAsync().Result);
        }

        // Ekleme Yapılacak Olan Sayfayı açmamızı sağlayan Metot.
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Categories data)
        {
            return View(service.AddAsync(data).Result);
        }
        [Route("/admin/Kategoriler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetCategoryByID(Id).Result);
        }
        [HttpPost]
        [Route("/admin/Kategoriler/Update/{Id}")]
        public IActionResult Update(int Id, Categories data)
        {
            data.ID = Id;
            ViewBag.Message = service.UpdateAsync(data).Result;
            return View(service.GetCategoryByID(Id).Result);
        }

        // 5dk geliyom
        [Route("/admin/Kategoriler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            TempData["Message"] = service.DeleteAync(Id).Result;
            return Redirect("/admin/Kategoriler");
        }
    }
}
