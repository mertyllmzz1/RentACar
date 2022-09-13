using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentService
    {
        public Task<IResult> AllAddAsync(Rents data);
        public Task<IResult> UpdateAsync(Rents data);
        public Task<IList<Rents>> GetAllRents();
        public Task<Rents> GetRentsRelationById(int id);
    }
}
