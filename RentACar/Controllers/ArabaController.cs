using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Controllers
{
    public class ArabaController : Controller
    {
        Business.Abstract.ICarService service;

        public ArabaController(ICarService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAllCars().Result);
        }
        [HttpGet]
        public IActionResult Index(Rents rent)
        {
            if (rent.RentDate > rent.DeliveryDate)
            {
                //DateTime tempDate = rentDate;
                //rentDate = deliveryDate;
                //deliveryDate = tempDate;
            }
            var qq = service.GetSuitableCarsByDate(rent.RentDate,rent.DeliveryDate).Result;
            return View(service.GetSuitableCarsByDate(rent.RentDate,rent.DeliveryDate).Result);
        }
    }
}
