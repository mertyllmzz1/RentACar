using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles = "Yönetici")]
    public class RentController : Controller
    {
        private readonly IRentService service;
        public RentController(IRentService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllRents().Result);
        }
        [Route("/admin/Detay/{Id}")]
        public IActionResult Detay(int Id)
        {
            return View(service.GetRentsRelationById(Id).Result);
        }
    }
}
