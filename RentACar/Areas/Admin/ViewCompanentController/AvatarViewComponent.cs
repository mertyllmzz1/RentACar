using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.ViewCompanentController
{
    public class AvatarViewComponent :ViewComponent
    {
        private readonly IHttpContextAccessor _contextAccessor;
        Business.CustomFunctions.UserManager manager;
        public AvatarViewComponent(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            manager = new Business.CustomFunctions.UserManager(_contextAccessor);
        }
        public IViewComponentResult Invoke()
        {
            var claim = manager.GetUserInformations();
            return View();
        }
    }
}
