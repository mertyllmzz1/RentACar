using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.CustomFunctions
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enums)
        {
            var info = enums.GetType().GetField(enums.ToString());
            var description = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return description.Length > 0 ? description[0].Description : enums.ToString();
        }
    }
}
