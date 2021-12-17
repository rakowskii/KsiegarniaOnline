using KsiegarniaOnline.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.Models
{
    public class Review
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Reviews { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
        public User Users { get; set; }
        public Product Products { get; set; }
    }
}

       
        

