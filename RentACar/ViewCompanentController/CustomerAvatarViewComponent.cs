using Business.CustomFunctions;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.ViewCompanentController
{
    public class CustomerAvatarViewComponent : ViewComponent
    {

        private readonly IHttpContextAccessor _contextAccessor;
    

        public CustomerAvatarViewComponent(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            Business.CustomFunctions.UserManager manager = new UserManager(_contextAccessor);
            var claim = manager.GetUserInformations();
            ViewBag.Claims = claim;
            return View();
        }
    }
}
