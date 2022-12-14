using Proiect_Magazin.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Magazin.Models
{
    public class User
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]

        [StringLength(30, MinimumLength = 3)]

        public string? FirstName { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Prenumele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria sau AnaMaria")]

        [StringLength(30, MinimumLength = 3)]

        public string? LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [StringLength(70)]
        public string? Adress { get; set; }
        public int? PostalCode { get; set; }
        public string? Email { get; set; }
        [RegularExpression(@"^[0]\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]

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
