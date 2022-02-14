using System;
using WebShopShoes.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebShopShoes.Shopping;
using System.Collections.Generic;
using Dapper;


namespace Shoeshop
{
    class Program
    {
        static Dictionary<Product, int> productCart = new Dictionary<Product, int>();
        static Decimal total = 0;
        static void Main(string[] args)
        {
            //string pName;
            ////List<Product> products = new List<Product>();
            //List<Product> products;
            //Console.Write("Search product name: ");
            //pName = Console.ReadLine();

            //products = WebShopShoes.DapperModels.DapperQueries.Products(pName);
            //Console.WriteLine();
            //Console.WriteLine("Products: ");

            //foreach (Product p in products)
            //{
            //    Console.WriteLine(p.id.ToString() + " " + p.product_name);
            //}
           
            WebshopMenu();
            
        }

        public static void WebshopMenu()
        {
            Console.WriteLine("Welcome to Jenny's and Sophie's ShoeShop! Let them eat shoes!");
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
            Console.Write("Enter Category: ");
            var productCategoryId = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            var productName = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            var productPrice = Console.ReadLine();
            Console.Write("Enter Product info: ");
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
                    Console.WriteLine("You have added 1 new product");
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
                Console.Write("Which Product ID do you want to remove?: ");
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

                Console.Write("Which Product ID do you want to update?: ");
                var productNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter new Product price: ");
                var productPrice = decimal.Parse(Console.ReadLine());
                Console.Write("Enter new Product info: ");
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
            ShowProducts.ShowProductSelection();
            Console.WriteLine("1) Search product (free text search)");
            Console.WriteLine("2) Browse and buy");
            Console.WriteLine("3) Remove product from your order");
            Console.WriteLine("4) View your order");
            Console.WriteLine("5) Confirm your order");
            Console.WriteLine("6) Go back to Main Menu");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SearchProduct();
                    break;
                case "2":
                    BrowseAndBuy(); //navigera kring artiklar
                    break;
                case "3":
                    RemoveProductFromCart(); // tar bort product från Program.productList
                    break;
                case "4":
                    ViewCurrentOrder(); // Printar Program.productList av product
                    CustomerMenu();
                    break;
                case "5":
                    ConfirmOrder(); //Här inne bestämmer man frakt och betal sätt och sedan spara i Order och Orderdetail
                    break;
                case "6":
                    Console.WriteLine("THIS WILL CLEAR YOUR CURRENT ORDER LIST  -  ARE YOU SURE? yes or no?");
                    string answer = Console.ReadLine();
                    if ("yes" == answer)
                    {
                        Program.productCart.Clear();
                        Program.total = 0;
                        WebshopMenu();
                    }
                    else
                    {
                        break;
                    }
                    break;
                default:
                    Console.WriteLine("Not a correct alternativ, please choose from below options: ");
                    CustomerMenu();
                    break;

            }


        }

        
        public static void RemoveProductFromCart()
        {
            ViewCurrentOrder();
            Console.WriteLine("Which product do you want to remove?");
            Console.WriteLine("Enter the ID: ");
            int productID = int.Parse(Console.ReadLine());
            Product removeProd = new Product();
            foreach (var prod in Program.productCart)
            {
                if (prod.Key.Id == productID)
                    removeProd = prod.Key;
            }
            Console.WriteLine("Enter the quantity to remove: ");
            int amount = int.Parse(Console.ReadLine());
            Program.productCart[removeProd] = (Program.productCart[removeProd] - amount);
            Program.total -= (removeProd.ProductPrice ?? 0 * amount);
            if (Program.productCart[removeProd] == 0)
            {
                Program.productCart.Remove(removeProd);
            }
            ViewCurrentOrder();
            CustomerMenu();
        }
        public static void BrowseAndBuy()
        {
            PrintCategories();
            Console.WriteLine("Choose a category to view its products");
            int sectionChosen = int.Parse(Console.ReadLine());
            printSection(sectionChosen);
            Console.WriteLine("Do you wish to buy any of the products above? choose yes or no");
            if (Console.ReadLine() == "yes")
            {
                AddProductToCart();
            }
            CustomerMenu();
        }
        public static void printSection(int sectionID)
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Products;
                var selectedProducts = productList.Where(p => p.ProductCategoryId == sectionID);

                foreach (var product in selectedProducts)
                {
                    Console.WriteLine(product.Id + " <- " + product.ProductName + " Price is: "+ product.ProductPrice);
                }
            };
        }

        public static void PrintProductCategories()
        {
            using (var database = new ShoeShopContext())
            {
                var productList = database.Categories;
                foreach (var product in productList)
                {
                    Console.WriteLine(product.Id + " <- " + product.CategoryName);
                }
            };
        }

        public static void AddProductToCart()
        {
            Console.WriteLine("Enter the product ID of the product your want to add to the cart");
            int productID = int.Parse(Console.ReadLine());
            Product AddProd = FindProductBasedOnID(productID);
            Console.WriteLine("Enter the amount of the above product you want to buy");
            int quantity = int.Parse(Console.ReadLine());
            Program.productCart.Add(AddProd, quantity);
            Program.total += (AddProd.ProductPrice ?? 0 * quantity);
            ViewCurrentOrder();
            CustomerMenu();
        }

        public static void ConfirmOrder()
        {
            Console.WriteLine("Are you sure you want to confirm above order? yes or no?");
            if (Console.ReadLine() == "no")
            {
                CustomerMenu();
            }
            else
            {
                ViewCurrentOrder();
                using (var database = new ShoeShopContext())
                {
                    var shippinglist = database.Shippers;
                    foreach (var shipperi in shippinglist)
                    {
                        Console.WriteLine(shipperi.Id + " <- " + shipperi.ShipperName + " The price is " + shipperi.FreightPrice);
                    }
                    Console.WriteLine("Please choose a freight alternative id: ");
                    int choiceFreight = int.Parse(Console.ReadLine());
                    var ship = (from s in database.Shippers
                                where s.Id == choiceFreight
                                select s).SingleOrDefault();
                    Program.total += ship.FreightPrice ?? 0;
                    var paymentlist = database.Payments;
                    foreach (var payi in paymentlist)
                    {
                        Console.WriteLine(payi.Id + " <- " + payi.PaymentName);
                    }
                    Console.WriteLine("Please choose a payment alternative id: ");
                    int choicePayment = int.Parse(Console.ReadLine());
                    var pay = (from s in database.Payments
                               where s.Id == choicePayment
                               select s).SingleOrDefault();
                    var newCust = new Customer();
                    Console.WriteLine("Are you a current custumer? yes or no?");
                    if (Console.ReadLine() == "no")
                    {
                        var customerlist = database.Customers;
                        Console.WriteLine("Please enter your first name: ");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Please enter your last name: ");
                        string lastname = Console.ReadLine();
                        Console.WriteLine("Please enter your email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Please enter you adress in one line");
                        string adress = Console.ReadLine();

                        newCust = new Customer
                        {
                            FirstName = firstName,
                            LastName = lastname,
                            Adress = adress,
                            EmailAdress = email
                        };
                        try
                        {
                            database.Add(newCust);
                            database.SaveChanges();
                            Console.WriteLine("Dear " + firstName + " we are now proccessing you order.....");
                            Console.WriteLine("Your new customer ID is ---> " + newCust.Id + " <--- Remember this!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("We failed to add you as a Customer");
                            CustomerMenu();
                        }
                        Console.WriteLine("Your order is being placed:");
                    }
                    else
                    {
                        Console.WriteLine("Write your customer ID: ");
                        int idi = int.Parse(Console.ReadLine());
                        newCust = (from s in database.Customers
                                            where s.Id == idi
                                            select s).SingleOrDefault();
                    }
                    var newOrder = new Order
                    {
                        TotalPrice = Program.total, //Includes shipping from above
                        OrderShipper = ship,
                        OrderPayment = pay,
                        OrderDate = DateTime.Now,
                        OrderCustomer = newCust
                    };
                    try
                    {
                        database.Add(newOrder);
                        database.SaveChanges();
                        Console.WriteLine("Your order has order number: -----> " + newOrder.Id);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("We failed to add your Order");
                        CustomerMenu();
                    }
                    foreach (var produc in Program.productCart)
                    {
                        var newDetailRow = new OrderDetail
                        {
                            OrderId = newOrder.Id,
                            ProductId = produc.Key.Id,
                            Quantity = produc.Value,
                        };
                        try
                        {
                            database.Add(newDetailRow);
                            database.SaveChanges();

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("We failed to add your Orderdetail");
                            CustomerMenu();
                        }
                    }
                }
            };
            Program.productCart.Clear();
            Program.total = 0;
            Console.WriteLine("Thank you for your order!");
        }
        public static void ViewCurrentOrder()
        {
            Console.WriteLine("---------------------");
            foreach (var printi in Program.productCart)
            {
                Console.WriteLine("Id: " + printi.Key.Id + " <-- " + "name: " + printi.Key.ProductName + " amount: " + printi.Value + " price/unit: " + printi.Key.ProductPrice);
            }
            Console.WriteLine("Total amount: " + Program.total);
            Console.WriteLine("---------------------");
        } 

        public static Product FindProductBasedOnID(int ID)
        {
            Product retVal;
            using (var database = new ShoeShopContext())
            {
                retVal = (from s in database.Products
                          where s.Id == ID
                          select s).SingleOrDefault();
            };
            return retVal;
        }
        
            
        
          public static void SearchProduct()
          {
            using (var db = new ShoeShopContext())
            {
                Console.WriteLine("Search product: ");
                string userInput = Console.ReadLine();
                var products = db.Products;
                var searchProduct = products.Where(sp => sp.ProductName.Contains(userInput)); 

                Console.WriteLine("--------------------------");
                Console.WriteLine("{0,-5}{1,-26}{2,-21}", "Id", "Name", "Price");
                foreach (var product in searchProduct)
                {
                    Console.WriteLine($"{product.Id,-4} {product.ProductName,-25} {product.ProductPrice,-20:C2}");
                }
                Console.WriteLine("--------------------------");
                CustomerMenu();
            }
                
            
          }


    }
}
