using AutoMapper;
using Core.Results;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> AddAsync(DtoCarsCrud data)
        {
            return await _unitOfWork.RepoCars.AsyncAdd(_mapper.Map<Cars>(data)).ContinueWith(p => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<IResult> DeleteAsync(int Id)
        {
            return await _unitOfWork.RepoCars.AsyncDelete(x => x.ID == Id).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<IList<DtoCars>> GetAllCars()
        {
            var result = _unitOfWork.RepoCars.AsyncGetAll().Result;
            return await Task.Run(() => _mapper.Map<IList<DtoCars>>(result));

        }
        public async Task<Cars> GetRelationCar(int Id)
        {
            return await _unitOfWork.RepoCars.AsyncFirst(x => x.ID == Id, x => x.Categories);
        }

        public Task<IList<Cars>> GetSuitableCarsByDate(DateTime rentDate, DateTime deliveryDate)
        {
            throw new NotImplementedException();
        }

        //public async Task<IResult> UpdateAsync(Cars data)
        //{

        //    return await _unitOfWork.RepoCars.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        //}

        public async Task<IResult> UpdateAsync(CarsUpdateDTO data)
        {
            Cars car = _unitOfWork.RepoCars.AsyncFirst(s => s.ID == data.ID, s => s.Categories).Result;
            if (car != null)
            {
                car.Name = data.Name;
                car.Plate = data.Plate;
                car.RentPriceFirst = data.RentPriceFirst;
                car.RentPriceSecond = data.RentPriceSecond;
                car.RentPriceThird = data.RentPriceThird;
                car.Avaliable = data.Avaliable;
                car.Capacity = data.Capacity;
                car.CategoriesID = data.CategoriesID;
                car.MaxDistance = data.MaxDistance;
                car.Explanation = data.Explanation;
            }
            return await _unitOfWork.RepoCars.AsyncUpdate(car).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<IResult> UpdateCarImagesAsync(CarsImageDTO data)
        {
            Cars car = _unitOfWork.RepoCars.AsyncFirst(s => s.ID == data.ID, s => s.Categories).Result;
            if (car!=null)
            {
                car.Image = data.Image;
                car.SubImage1 = data.SubImage1;
                car.SubImage2 = data.SubImage2;
                car.SubImage3 = data.SubImage3;

            }
            return await _unitOfWork.RepoCars.AsyncUpdate(car).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        //public async Task<IList<Cars>> GetSuitableCarsByDate(DateTime rentDate, DateTime deliveryDate)
        //{
        //    var resultr = _unitOfWork.RepoCars.AsyncGetAll(null, s => s.Rents).Result.Select(s => s.Rents.Where(s => s.RentDate < rentDate && s.DeliveryDate > rentDate));
        //    var result = _unitOfWork.RepoCars.AsyncGetAll(null, s => s.Rents.Where(s => (s.RentDate <= rentDate && s.DeliveryDate >= rentDate) && (s.RentDate <= de))).Result.Where(s => s.Rents.Count == 0).ToList();
        //    var result = _unitOfWork.RepoCars.AsyncGetAll(null, s => s.Rents.Where(s => ((s.RentDate <= rentDate || s.DeliveryDate > rentDate) && (s.RentDate <= deliveryDate || s.DeliveryDate > deliveryDate)) || (s.RentDate >= rentDate &&  ))).Result.Where(s => s.Rents.Count == 0).ToList();

        //    return await Task.Run(() => result);

        //}
    }
}
