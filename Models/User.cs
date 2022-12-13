using Proiect_Magazin.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Magazin.Models
{
    public class User
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string? Adress { get; set; }
        public int? PostalCode { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Cart>? Carts { get; set; }


    }
}
