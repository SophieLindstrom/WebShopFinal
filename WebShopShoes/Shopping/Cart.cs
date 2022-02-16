//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WebShopShoes.Shopping
//{
//    public class Cart
//    {
//        public List<CartLine> CartLines { get; }
//        public Cart()
//        {
//            CartLines = new List<CartLine>();
//        }

//        public void AddCartLine(CartLine cl)
//        {
//            foreach (var item in CartLines)
//            {
//                if (item.ProductId == cl.ProductId)
//                {
//                    item.Quantity += cl.Quantity;
//                  //  item.Quantity = item.Quantity + cl.Quantity; det är samma
//                    return;
//                }
                
//            }
//            CartLines.Add(new CartLine(cl.ProductId, cl.Quantity));
//            return;
//        }
//    }
//}
