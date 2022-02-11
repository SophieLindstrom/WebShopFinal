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
        static void Main(string[] args)
        {
            WebshopMenu();
        }

        public static void WebshopMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Admin");
            Console.WriteLine("2) Customer");
            Console.WriteLine("3) Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    AdminMenu();
                    break;
                case "2":
                    CustomerMenu();
                    break;
                case "3":
                    Console.WriteLine("THANK YOU! BYE BYE!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Not a correct alternativ, please choose from below options: ");
                    WebshopMenu();
                    break;
            }
        }
        public static void AdminMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Manage Categories");
            Console.WriteLine("2) Manage Products");
            Console.WriteLine("3) Go back to main page");

            switch (Console.ReadLine())
            {
                case "1":
                    ManageCategories();
                    break;
                case "2":
                    ManageProducts();
                    break;
                case "3":
                    WebshopMenu();
                    break;
                default:
                    Console.WriteLine("Not a correct alternativ, please choose from below options: ");
                    AdminMenu();
                    break;
            }
        }

        public static void ManageCategories()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a category");
            Console.WriteLine("2) Remove a category");
            Console.WriteLine("3) Go back to Admin Menu");
            switch (Console.ReadLine())
            {
                case "1":
                    AddCategory();
                    break;
                case "2":
                    RemoveCategory();
                    break;
                case "3":
                    AdminMenu();
                    break;
                default:
                    Console.WriteLine("Not a correct alternativ, please choose from below options: ");
                    ManageCategories();
                    break;
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

            }
            ManageCategories();

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
                PrintCategories();
            }
            ManageCategories();

        }
        public static void ManageProducts()
        {

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add a Product");
            Console.WriteLine("2) Remove a Product");
            Console.WriteLine("3) Update a Product");
            Console.WriteLine("4) Go back to Admin Menu");
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
                    break;
                case "4":
                    AdminMenu();
                    break;
                default:
                    Console.WriteLine("Not a correct alternativ, please choose from below options: ");
                    ManageProducts();
                    break;
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
                    Console.WriteLine("Du har lagt till 1 ny produkt");
                }
                catch (Exception)
                {
                    Console.WriteLine("You failed to add a product");
                }
                PrintProducts();
            }
            ManageProducts();
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
            }
            PrintProducts();
            ManageProducts();
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
            }
            PrintProducts();
            ManageProducts();
        }
        public static void CustomerMenu()
        {
            Console.WriteLine("Welcome to Jenny's and Sophie's ShoeShop! Let them eat shoes!");
            ShowProducts.ShowProductSelection();

                using (var database = new ShoeShopContext())
                {
                    var productList = database.Categories;
                    foreach (var product in productList)
                    {
                        Console.WriteLine(product.Id + " <- " + product.CategoryName);
                    }
                };

                int sectionChosen = int.Parse(Console.ReadLine());
                printSection(sectionChosen);

            Console.WriteLine("1) Add a product to your order");
            Console.WriteLine("2) Remove product from your order");
            Console.WriteLine("3) View your order");
            Console.WriteLine("4) Confirm your order");
            Console.WriteLine("5) Go back to Main Menu");
            switch (Console.ReadLine())
            {
                case "1":
                    AddProductToCart();
                    break;
                case "2":
                    RemoveProductToCart();
                    break;
                case "3":
                    ViewCurrentOrder();
                    break;
                case "4":
                    ConfirmCurrentOrder();
                    break;
                case "5":
                    WebshopMenu();
                    break;
                default:
                    Console.WriteLine("Not a correct alternativ, please choose from below options: ");
                    CustomerMenu();
                    break;
            }


        }
        public static void printSection(int sectionID)
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Products;
                var selectedProducts = productList.Where(p => p.ProductCategoryId == sectionID);

                foreach (var product in selectedProducts)
                { 
                    Console.WriteLine(product.Id + " <- " + product.ProductName);
                }
            };
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

                    var newProduct = new OrderDetail
                    {
                        OrderId = 1435,
                        Product = prod,
                        Quantity = cart.Quantity
                    };


                    db.OrderDetails.Add(newProduct);
                    db.OrderDetails.Update(newProduct); // ändringar ska göras efter köp
                    //cart.Add(new CartLine(cart.ProductId, cart.Quantity));
                    return;
                }
            }
        }

    }
}
