using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Categories: IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public IList<Cars> Cars { get; set; }
    }
}
