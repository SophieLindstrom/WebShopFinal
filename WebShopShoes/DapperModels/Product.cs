using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopShoes.DapperModels
{
    class Product
    {
        
            public int id { get; set; }
            public string product_name { get; set; }
            public int product_category_id { get; set; }
            public decimal product_price { get; set; }
            public string product_info { get; set; }

       
    }
}
