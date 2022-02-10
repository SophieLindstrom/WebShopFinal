using System;
using WebShopShoes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebShopShoes.Shopping;

namespace Shoeshop
{
    class Program
    {
        public static bool WebshopMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Admin");
            Console.WriteLine("2) Customer");
            Console.WriteLine("3) Exit");



            switch (Console.ReadLine())
            {
                case "1":
                    AdminMenu();
                    return true;
                case "2":
                    //Customer();
                    return true;
                case "3":
                    //Exit();
                    return true;
                default:
                    return true;

            }

        }
        public static bool AdminMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Manage Categories");
            Console.WriteLine("2) Manage Products");

            switch (Console.ReadLine())
            {
                case "1":
                    ManageCategories();
                    return true;
                case "2":
                    ManageProducts();
                    return true;
                case "3":
                    // Exit();
                    return true;
                default:
                    return true;
            }
        }

        public static bool ManageCategories()
        {
          while (true)
          { 
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a category");
            Console.WriteLine("2) Remove a category");
            switch (Console.ReadLine())
            {
                case "1":
                    AddCategory();
                    break;
                case "2":
                    RemoveCategory();
                    break;
                //case "3":
                //    Exit();
                //    return true;
                default:
                    return true;
            }
          }
        }
        public static void AddCategory()
        {

            PrintCategories();
            Console.Write("Vilken kategori vill du lägga till?: ");
            var categoryName = Console.ReadLine();

            using (var database = new ShoeShopContext())
            {
                var newCategory = new Category
                {
                    CategoryName = categoryName

                };

                database.Add(newCategory);
                database.SaveChanges();
                PrintCategories();
                Console.WriteLine("Du har lagt till 1 ny kategori");
                // System.Environment.Exit(1);
            }

        }
        public static void PrintCategories()
        {
            using (var database = new ShoeShopContext())
            {
                var categoryList = database.Categories;
                foreach (var category in categoryList)
                {
                    Console.WriteLine(category.Id + "\t" + category.CategoryName);

                }
            }
        }
        public static void PrintProducts()
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Products;
                foreach (var product in productList)
                {
                   //Console.WriteLine($"Product ID:{}Category ID:{-10}");
                    Console.WriteLine("{0, -5} {1, 5}", "Product ID", "Category ID" );
                    Console.WriteLine(product.Id + "\t" + product.ProductCategoryId + "\t" + product.ProductName + "\t" + product.ProductPrice + "\t" + product.ProductInfo);

                }
            }
        }

        public static void RemoveCategory()
        {
            using (var database = new ShoeShopContext())
            {
                PrintCategories();

                Console.Write("Vilket kategorinummer vill du ta bort?: ");


                var categoryNumber = int.Parse(Console.ReadLine());
                var removeCategory = new Category
                {
                    Id = categoryNumber

                };
                database.Attach(removeCategory);
                database.Remove(removeCategory);
                database.SaveChanges();
                // System.Environment.Exit(1);
                PrintCategories();
            }

        }
        public static bool ManageProducts()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a Product");
            Console.WriteLine("2) Remove a Product");
            Console.WriteLine("3) Update a Product");
            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct();
                    return true;
                case "2":
                    RemoveProduct();
                    return true;
                case "3":
                    UpdateProduct();
                    return true;
                case "4":
                    // Exit();
                    return true;
                default:
                    return true;
            }

        }
        public static void AddProduct()
        {
            PrintCategories();

            Console.Write("Ange kategori: ");
            var productCategoryId = int.Parse(Console.ReadLine());

            Console.Write("Ange produktnamn: ");
            var productName = Console.ReadLine();
            Console.Write("Ange produktpris: ");
            var productPrice = Console.ReadLine();
            Console.Write("Ange produktinfo: ");
            var productInfo = Console.ReadLine();

            using (var database = new ShoeShopContext())
            {
                var newProduct = new Product
                {
                    ProductCategoryId = productCategoryId,
                    ProductName = productName,
                    ProductPrice = decimal.Parse(productPrice),
                    ProductInfo = productInfo

                };
                try
                {
                    database.Add(newProduct);
                    database.SaveChanges();
                    Console.WriteLine("Du har lagt till 1 ny produkt");//rows affected
                }
                catch (Exception e)
                {
                    Console.WriteLine("You failed to add a product : " + e.Message);
                }


                PrintProducts();
            }
        }

        public static void RemoveProduct()
        {
            using (var database = new ShoeShopContext())
            {
                PrintProducts();

                Console.Write("Vilken produktnummer vill du ta bort?: ");


                var productNumber = int.Parse(Console.ReadLine());
                var removeProduct = new Product
                {
                    Id = productNumber

                };
                database.Attach(removeProduct);
                database.Remove(removeProduct);
                database.SaveChanges();
                // System.Environment.Exit(1);
                PrintProducts();
            }

        }
        //public static void UpdateProduct()
        //{
        //    using (var database = new ShoeshopContext())
        //    {
        //        PrintProducts();

        //        Console.Write("Vilket produktnummer vill du uppdatera?: ");
        //        var productNumber = int.Parse(Console.ReadLine());

        //        Console.Write("Ange nytt produktpris: ");
        //        var productPrice = Console.ReadLine();
        //        Console.Write("Ange ny produktinfo: ");
        //        var productInfo = Console.ReadLine();

        //        var updateProduct = new Models.Product

        //        {
        //            Id = productNumber,
        //            ProductPrice = decimal.Parse(productPrice),
        //            ProductInfo = productInfo
        public static void UpdateProduct()
        {
            using (var database = new ShoeShopContext())
            {
                PrintProducts();

                Console.Write("Vilket produktnummer vill du uppdatera?: ");
                var productNumber = int.Parse(Console.ReadLine());

                Console.Write("Ange nytt produktpris: ");
                var productPrice = decimal.Parse(Console.ReadLine());
                Console.Write("Ange ny produktinfo: ");
                var productInfo = Console.ReadLine();

                var result = database.Products.Single(b => b.Id == productNumber);
                if (result != null)
                {

                    result.ProductInfo = productInfo;
                    result.ProductPrice = productPrice;
                    database.SaveChanges();
                }

                // System.Environment.Exit(1);
                PrintProducts();


            }

        }
        //        };
        //        database.Update(updateProduct);

        //        database.SaveChanges();
        //        // System.Environment.Exit(1);
        //        PrintProducts();


        //    }

        //}



        static void Main(string[] args)
        {
            //bool showMenu = true;
            //while (showMenu)
            //{
            //    showMenu = WebshopMenu();
            //}

            Cart myCart = new Cart();
            myCart.CartLines.Add(new CartLine(1, 2));

            WebshopMenu();



            //    using (var db = new ShoeshopContext())
            //{
            //    var productcategories = db.Categories;

            //    foreach (var category in productcategories)
            //   {
            //       Console.WriteLine(category.Id + "\t" + category.CategoryName);
            //    }
            //}

            //using (var db = new ShoeshopContext())
            //{
            //    var cities = db.Products;

            //    foreach (var city in cities)
            //    {
            //        Console.WriteLine(city.CityName);
            //        using (var dbb = new ShoeshopContext())
            //        {
            //            var parkingHouses = dbb.ParkingHouses;
            //            foreach (var house in parkingHouses)
            //            {
            //                if (city.Id == house.CityId)
            //                    Console.WriteLine(house.HouseName);
            //            }

            //        }
            //    }
            //}

            // while (true)
            //{
            //    using (var database = new ShoeshopContext())
            //    {
            //        var productList = database.Products;
            //        foreach (var product in productList)
            //        {
            //            Console.WriteLine(product.Id + "\t" + String.Format("{0:.00}", product.ProductPrice) + "\t" + product.ProductName);
            //        }
            //    }


            //Console.Clear();



        }
    }
}