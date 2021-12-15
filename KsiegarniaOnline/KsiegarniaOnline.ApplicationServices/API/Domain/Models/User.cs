using KsiegarniaOnline.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.Models
{
    public class User
    {
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public Role Roles { get; set; }
    }
}
