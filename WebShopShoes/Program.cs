using System;
using WebShopShoes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebShopShoes.Shopping;
using System.Collections.Generic;

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
                    CustomerMenu();
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
                Console.WriteLine("{0, -5} {1, 5}", "Product ID", "Category ID");
                foreach (var product in productList)
                {
                   //Console.WriteLine($"Product ID:{}Category ID:{-10}");
                    
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
           while (true) 
           { 
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a Product");
            Console.WriteLine("2) Remove a Product");
            Console.WriteLine("3) Update a Product");
            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    RemoveProduct();
                    break;
                case "3":
                    UpdateProduct();
                    return true;
                case "4":
                    // Exit();
                   // return true;
                default:
                    return true;
            }
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
        public static bool CustomerMenu()
        {
            Console.WriteLine("Welcome to Jenny's and Sophie's ShoeShop! Let them eat shoes!");
            ShowProducts.ShowProductSelection();

            while (true)
            {
                Console.WriteLine("1) Show Sneakers:");
                Console.WriteLine("2) Show Wintershoes");
                Console.WriteLine("3) Show Sandals");
                Console.WriteLine("4) Show Boots");
                Console.WriteLine("5) Show Slippers");
                Console.WriteLine("6) Search Product");
                switch (Console.ReadLine())
                {
                    case "1":
                        SneakerSection();
                        break;
                    case "2":
                        WintershoeSection();
                        break;
                    case "3":
                       SandalSection();
                        break;
                   case "4":
                        BootSection();
                        break;
                   case "5":
                        SlipperSection();
                        break;
                    case "6":
                       // ProductSearch();
                       break;

                    default:
                        return true;
                }
            }
        }
        public static void SneakerSection()
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Products;
                var selectedProducts = productList.Where(p => p.ProductCategoryId == 1);


                foreach (var product in selectedProducts)
                { 

                    Console.WriteLine(product.ProductName);//+ "\t" + product.ProductInfo);

                }
            };
        }
        public static void WintershoeSection()
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Products;
                var selectedProducts = productList.Where(p => p.ProductCategoryId == 2);


                foreach (var product in selectedProducts)
                {

                    Console.WriteLine(product.ProductName);//+ "\t" + product.ProductInfo);

                }
            };
        }
        public static void SandalSection()
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Products;
                var selectedProducts = productList.Where(p => p.ProductCategoryId == 3);


                foreach (var product in selectedProducts)
                {
                    Console.WriteLine(product.ProductName);//+ "\t" + product.ProductInfo);
                }
            };
        }
        public static void BootSection()
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Products;
                var selectedProducts = productList.Where(p => p.ProductCategoryId == 4);


                foreach (var product in selectedProducts)
                {
                    Console.WriteLine(product.ProductName);//+ "\t" + product.ProductInfo);
                }
            };
        }
        public static void SlipperSection()
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Products;
                var selectedProducts = productList.Where(p => p.ProductCategoryId == 5);


                foreach (var product in selectedProducts)
                {
                    Console.WriteLine(product.ProductName);//+ "\t" + product.ProductInfo);
                }
            };
        }
        //public static void AddCartLine(CartLine cl)
        //{
        //    var shoppingList = new List<CartLine>();

        //    var userInputID = int.Parse(Console.ReadLine());
        //    var userInputQuantity = int.Parse(Console.ReadLine());
        //    foreach (var item in shoppingList)
        //    {
        //        if (item.ProductId == cl.ProductId)
        //        {
        //            item.Quantity += cl.Quantity;
        //            //  item.Quantity = item.Quantity + cl.Quantity; det är samma
        //            return;
        //        }

        //    }
        //    shoppingList.Add(new CartLine(userInputID, userInputQuantity));
        //    Console.WriteLine(shoppingList);
        //    return;

        //}



        static void Main(string[] args)
        {

            WintershoeSection();




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

        public static void AddProductToCart(int productId, int quantity)
        {
            using (var db = new ShoeShopContext())
            {
                Product prod = (from p in db.Products
                                  where p.Id == productId
                                  select p).SingleOrDefault();
                
                {
                    
                    
                    CartLine cart = new CartLine(productId, quantity);
                    cart.ProductId = productId;
                    cart.Quantity = quantity;
                    // db.Produkters.Update(prod); // ändringar ska göras efter köp
                    //cart.Add(new CartLine(cart.ProductId, cart.Quantity));
                    return;
                }
            }
        }

    }
    }
