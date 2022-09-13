using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class DtoCars
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public  int Capacity { get; set; }
        public  int GearType { get; set; }
        public  int MaxDistance { get; set; }
        public  string Explanation { get; set; }
        public bool Avaliable { get; set; }
        public string  Image { get; set; }
        public int RentPriceFirst { get; set; }
        public int RentPriceSecond { get; set; }
        public int RentPriceThird { get; set; }
    }
}
