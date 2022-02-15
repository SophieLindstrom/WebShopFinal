using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
//using WebShopShoes.DapperModels;
using WebShopShoes.Models;

namespace WebShopShoes.DapperModels
{
    public class DapperQueries
    {
        static string ConnectionString = "data source=.\\SQLEXPRESS; initial catalog = ShoeShop; persist security info = True; Integrated Security = True;";


        //public static List<Product> SearchProducts(string likeName)
        //{
        //    string sql = $"SELECT * FROM Product WHERE product_name LIKE '%{likeName}%'";
        //    List<Product> Products = new List<Product>();

        //    using (var connection = new SqlConnection(ConnectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            Products = connection.Query<Product>(sql).ToList();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }

        //    return Products;
        //}

        public static List<PopularProducts> GetPopularProductsByCustomer()
        {
            string sql = "SELECT TOP(3) COUNT(Order_details.order_id) AS cnt, Product.product_name " + 
                        "FROM Order_details " +
                        "JOIN Product ON(Order_details.product_id = Product.id) " +
                        "GROUP BY Product.product_name " +
                        "ORDER By cnt DESC";
            List<PopularProducts> popularProducts = new List<PopularProducts>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    popularProducts = connection.Query<PopularProducts>(sql).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return popularProducts;
        }
        
        public static void PrintPopularProductsByCustomer()
        {
            List<PopularProducts> popularProducts = GetPopularProductsByCustomer();

            Console.WriteLine("\nCustomers favourite products:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("{0,-20} {1,-20}", "Product name", "Number of Costumer Orders");
            foreach (PopularProducts prod in popularProducts)
            {
                Console.WriteLine($"{prod.product_name,-20} -- {prod.cnt,-20}");
            }
            Console.WriteLine("--------------------------");

        } 
    }
}
