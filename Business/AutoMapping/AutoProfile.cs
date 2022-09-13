using Entities.DTO;
using AutoMapper;
namespace Business.AutoMapping
{
    public class AutoProfile:Profile
    {
        public AutoProfile()
        {
            CreateMap<Cars, DtoCars>().ReverseMap();
            CreateMap<Cars, DtoCarsCrud>().ReverseMap();
            CreateMap<Cars, CarsUpdateDTO>().ReverseMap();
            CreateMap<Cars, CarsImageDTO>().ReverseMap();
            CreateMap<Customers, CustomerIsAdminDTO>().ReverseMap();
        }
        
    }
}
