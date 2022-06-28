using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.DataAccess.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }     
        public Role Roles { get; set; }
        public List<Order> Orders { get; set; }
        public List<Review> Review { get; set; }
    }

    public enum Role
    {
        Użytkownik,
        Admin
    }
}