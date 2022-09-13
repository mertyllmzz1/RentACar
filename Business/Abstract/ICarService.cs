using Core.Results;
using Entities.DTO;

namespace Business.Abstract
{
    public interface ICarService
    {
        public Task<IResult> AddAsync(DtoCarsCrud data);
        public Task<IResult> UpdateAsync(CarsUpdateDTO data);
        public Task<IResult> DeleteAsync(int Id);
        public Task<IList<DtoCars>> GetAllCars();
        public Task<Cars> GetRelationCar(int Id);
        public Task<IResult> UpdateCarImagesAsync(CarsImageDTO data);
        public Task<IList<Cars>> GetSuitableCarsByDate(DateTime rentDate, DateTime deliveryDate);//Dto oluşturulabilir
    }
}
