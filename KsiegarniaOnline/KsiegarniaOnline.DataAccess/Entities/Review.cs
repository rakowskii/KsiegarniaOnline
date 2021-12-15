using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KsiegarniaOnline.DataAccess.Entities
{
    public class Review : EntityBase
    {
        
       
        public int UserId { get; set; }

        
        public int ProductId { get; set; }

        [Required]
        public string Reviews { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
        public User Users { get; set; }
        public Product Products { get; set; }

    }
}
        
        
                
            
        
             


                
                    

            
        


