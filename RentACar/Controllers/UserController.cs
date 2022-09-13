
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Web;
using Business.CustomFunctions;

namespace UIWeb.Areas.Controllers
{
    public class UserController : Controller
    {
        private readonly ICustomerService service;
        private readonly IHttpContextAccessor accessor;
        public UserController(ICustomerService service, IHttpContextAccessor accessor)
        {
            this.service = service;
            this.accessor = accessor;
        }

        public IActionResult Index()
        {
            UserManager manager = new UserManager(accessor);
            var claims = manager.GetUserInformations();
            if (claims !=null)
            {
                return Redirect("/Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string mail, string pw)
        {
            Customers existingUser = service.LoginAsync(mail, pw).Result;
           
            if (existingUser == null)
            {
                ViewBag.Message = "Eşleşen kullanıcı bulunamadı. Tekrar deneyin";
                return View();
            }
            else
            {
                var claim = new List<Claim>();
                claim.Add(new Claim("ID", existingUser.ID.ToString()));
                claim.Add(new Claim(ClaimTypes.Name, existingUser.NameSurname));
                claim.Add(new Claim("Avatar", existingUser.Avatar));
                if (existingUser.IsAdmin == true)
                {
                    claim.Add(new Claim(ClaimTypes.Role, "admin"));
                    //claim.Add(new Claim(ClaimTypes.Role, "araba"));                
                }
                else
                {
                    claim.Add(new Claim(ClaimTypes.Role, "customer"));
                }
   
                var user = new ClaimsIdentity(claim, "UserInfo");
                ClaimsPrincipal principal = new ClaimsPrincipal(user);
                var SetCookies = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddDays(1),
                    IsPersistent = true,
                };

                HttpContext.SignInAsync(principal, SetCookies);

                if (existingUser.IsAdmin==true)
                {
                    return Redirect("/admin");
                }
                else
                {
                    return Redirect("/");
                }
            }

        }
        [HttpPost]
        public IActionResult Register(IFormFile Avatar,Customers customer)
        {
            string AnaResimResponse = Helpers.ImageLoad.Load(Avatar);
            if (AnaResimResponse == "0")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen Jpeg veya Jpg uzantılı resim seçiniz";
            }
            else if (AnaResimResponse == "1")
            {
                ViewBag.Message = "Ekleme Başarısız, Lütfen resim seçiniz";
            }
            else
            {
                customer.Avatar = AnaResimResponse;

            }
            customer.BirthDate = Convert.ToDateTime("17.07.1998");
            customer.Phone = "5448354186";
            var statusResult = service.AddAsync(customer).Result;
            if (statusResult.StatusCode == Core.Results.ComplexTypes.StatusCode.Success)
            {
                var Bulunan = service.LoginAsync(customer.Email, customer.Password).Result;
                var claim = new List<Claim>();
                claim.Add(new Claim("ID", Bulunan.ID.ToString()));
                claim.Add(new Claim(ClaimTypes.Name, Bulunan.NameSurname));
                var user = new ClaimsIdentity(claim, "UserInfo");
                ClaimsPrincipal principal = new ClaimsPrincipal(user);
                var CookiesTime = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddDays(1),
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, CookiesTime);
            }
            else
            {
                ViewBag.Message = statusResult.UserMessage;
            }
            return Redirect("/");
        }
    }
}
