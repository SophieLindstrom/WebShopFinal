using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopShoes.Models
{
    public class EFQueries
    {
        public static void PrintFavouriteProducts()
        {
            using (var db = new ShoeShopContext())
            {
                var products = db.Products;
                var selectedProducts = products.Where(p => p.Id == 2 || p.Id == 6 || p.Id == 18);
                Console.WriteLine("\nOur favourite products:");
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
