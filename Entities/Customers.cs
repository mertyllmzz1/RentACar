

using Core.Abstract;

namespace Entities
{
    //Tablo ismi için User Daha uygun olurdu ancak düzenlemekle uğraşmak istemedim :)
    public class Customers:IEntity
    {
        public int ID{ get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Avatar { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime BirthDate { get; set; }
        public IList<Rents> Rents { get; set; }

    }
}
