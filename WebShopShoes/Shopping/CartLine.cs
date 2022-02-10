using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopShoes.Shopping
{
    public class CartLine
    {
        public int ProductId { get; }
        public int Quantity { get; set; }
        public CartLine(int productId, int quantity )
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
