using Core.Abstract;
namespace Entities
{
    public class Rents : IEntity
    {
        public int ID { get; set; }
        public int Status { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int CarID { get; set; }
        public Cars Car { get; set; }//Tek seferde bir araç kiralanabilir olarak bir senaryo düşünüldü
        public int CustomerID { get; set; }
        public Customers Customers { get; set; }

    }
}
