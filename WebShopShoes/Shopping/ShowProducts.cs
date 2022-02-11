using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopShoes;
using Microsoft.EntityFrameworkCore;
using WebShopShoes.Models;

namespace WebShopShoes.Shopping
{
    class ShowProducts
    {
        public static void ShowProductSelection()
        {
            using (var db = new ShoeShopContext())
            {
                var products = db.Products;
                var selectedProducts = products.Where(p => p.Id == 2 || p.Id == 6 || p.Id == 18);
                Console.WriteLine("\nMost Popular Products:");
                Console.WriteLine("--------------------------");

                foreach (var prod in selectedProducts)
                {
                    Console.WriteLine($"{prod.ProductName} -- {prod.ProductPrice:C2}");
                }
                Console.WriteLine("--------------------------");
            }
        }
    }
}
