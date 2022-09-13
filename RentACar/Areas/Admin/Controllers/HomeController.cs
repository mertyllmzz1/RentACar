using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        Business.CustomFunctions.UserManager manager; 
        public HomeController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            manager= new Business.CustomFunctions.UserManager(_contextAccessor);
        }
        public IActionResult Index()
        {
            //var claim = manager.GetUserInformations();
            return View();
        }
    }
}
