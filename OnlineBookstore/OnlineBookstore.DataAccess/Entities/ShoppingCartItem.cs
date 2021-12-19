namespace OnlineBookstore.DataAccess.Entities
{
    public class ShoppingCartItem : EntityBase
    {
        
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
