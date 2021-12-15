using System.Collections.Generic;

namespace KsiegarniaOnline.DataAccess.Entities
{
    class ShoppingCart : EntityBase
    {
        
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
