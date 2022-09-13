using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class UserClaims
    {
        public string ID { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
    }
}
