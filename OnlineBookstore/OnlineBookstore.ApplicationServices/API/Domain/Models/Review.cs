using OnlineBookstore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.API.Domain.Models
{
    public class Review
    {
        public string UserId { get; set; }
        public string Reviews { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
    }
}
        
        


        
        

       
        

