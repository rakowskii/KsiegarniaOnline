namespace OnlineBookstore.DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Product : EntityBase
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Author { get; set; }

        [MaxLength(50)]
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

       
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public bool IsBestseller { get; set; }

        [Required]
        public bool InStock { get; set; }

        [MaxLength(50)]
        public string Series { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public Types Type { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public Categories Category { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        public Covers Cover { get; set; }
        public List<Review> Reviews { get; set; }

        public enum Types 
        {
            Książka,
            Czasopismo,
            Komiks
        }

        public enum Categories 
        {
            Fantastyka,
            Kryminał,
            Historia,
            
        }

        public enum Covers 
        {
           Miękka,
           Twarda
        }









    }








}
