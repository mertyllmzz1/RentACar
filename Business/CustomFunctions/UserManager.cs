using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Business.CustomFunctions
{
    public class UserManager
    {
        private readonly IHttpContextAccessor accessor;
        public UserManager(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }
        public UserClaims GetUserInformations()
        {
            var session = accessor.HttpContext.User.Claims.ToList();
            UserClaims userClaims = new UserClaims();
            
            foreach (var item in session)
            {
                if (item.Type==ClaimTypes.Role )
                {
                    userClaims.Role = item.Value;
                }
                if (item.Type.ToLower() =="avatar")
                {
                    userClaims.Avatar=item.Value;
                }
                if (item.Type.ToLower()== ClaimTypes.Name)
                {
                    userClaims.Name=  item.Value;
                }
                if (item.Type.ToLower()=="ID")
                {
                    userClaims.ID = item.Value;
                }
            }
            return userClaims;
        }
    }
}
