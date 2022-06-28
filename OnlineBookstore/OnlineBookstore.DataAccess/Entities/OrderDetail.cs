using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookstore.DataAccess.Entities
{
    public class OrderDetail : EntityBase
    {
        [ForeignKey("Order")]
        public int OrderId { get; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }        
    }
}