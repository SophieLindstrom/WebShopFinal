using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using WebShopShoes.DapperModels;

namespace WebShopShoes.DapperModels
{
    public class DapperQueries
    {
        static string ConnectionString = "data source=.\\SQLEXPRESS; initial catalog = ShoeShop; persist security info = True; Integrated Security = True;";


        //public static List<Product> SearchProducts(string likeName)
        //{
        //    string sql = $"SELECT * FROM Product WHERE product_name LIKE '%{likeName}%'";
        //    List<WebShopShoes.Models.Product> Products = new List<WebShopShoes.DapperModels.DapperQueries.Product>();

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
    }
}
