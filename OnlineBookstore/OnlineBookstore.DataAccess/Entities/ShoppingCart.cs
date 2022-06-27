using System.Collections.Generic;

namespace OnlineBookstore.DataAccess.Entities
{
    class ShoppingCart : EntityBase
    {       
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}