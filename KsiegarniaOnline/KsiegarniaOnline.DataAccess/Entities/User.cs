using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KsiegarniaOnline.DataAccess.Entities
{
    public class User : EntityBase
    {
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

    }

        


}
