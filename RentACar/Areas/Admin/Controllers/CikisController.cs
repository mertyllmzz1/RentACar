using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    public class CikisController : Controller
    {
        [Area("admin")]
        public IActionResult Index()
        {

            HttpContext.SignOutAsync();
            TempData["CikisMesaji"] = "Oturum Kapatıldı";
            return Redirect("/User");
        }
    }
}
