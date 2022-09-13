using Core.Abstract;


namespace Entities.DTO
{
    public class DtoCarsCrud:IDTO
    {
        public int ID { get; set; }
        public string Plate { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int RentPriceFirst { get; set; }
        public int RentPriceSecond { get; set; }
        public int RentPriceThird { get; set; }
        public bool Avaliable { get; set; }
        public int Capacity { get; set; }
        public byte GearType { get; set; }
        public int MaxDistance { get; set; }
        public int CategoriesID { get; set; }
        public string SubImage1 { get; set; }
        public string SubImage2 { get; set; }
        public string SubImage3 { get; set; }
        public string Explanation { get; set; }
    }
}
