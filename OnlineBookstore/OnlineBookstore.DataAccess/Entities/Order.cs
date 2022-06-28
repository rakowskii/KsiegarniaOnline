using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookstore.DataAccess.Entities
{
    public class Order : EntityBase
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime OrderPlaced { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public decimal OrderTotal { get; set; }
        public User Users { get; set; }
        
        [Required(ErrorMessage = "Podaj imię")]
        [Display(Name = "Imię")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Podaj nazwisko")]
        [Display(Name = "Nazwisko")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Podaj adres")]
        [Display(Name = "Adres 1")]
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [Display(Name = "Adres 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Podaj kod pocztowy")]
        [Display(Name = "Kod pocztowy")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Podaj miasto")]
        [Display(Name = "Miasto")]
        [MaxLength(50)]
        public string City { get; set; }

        [Display(Name = "Województwo")]
        [MaxLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Podaj kraj")]
        [Display(Name = "Kraj")]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Podaj numer telefonu")]
        [Display(Name = "Numer telefonu")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(25)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Podaj adres e-mail")]
        [Display(Name = "Adres e-mail")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Email jest w złym formacie")]
        public string Email { get; set; }   
    }
}