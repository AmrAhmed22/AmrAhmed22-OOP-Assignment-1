namespace Part1_ProceduralToOOP
{
    internal class Program
    {
        static void Main()
        {
            
            var customers = new List<Customer>();
            var products = new List<Product>();
            var orders = new List<Order>();

            Console.WriteLine("Object-Oriented Order System");

            Seed(customers, products);
            RunDemo(customers, products, orders);

            PrintCustomers(customers);
            PrintProducts(products);
            PrintAllOrders(orders, customers);
            Console.WriteLine($"\nPaid sales total after demo: {TotalSalesPaidOnly(orders)}");

            RunMenu(customers, products, orders);
        }







        private static Customer? FindCustomer(List<Customer> customers, int id)
        {
            foreach (var customer in customers)
            {
                if (customer.Id == id)
                    return customer;
            }
            return null;
        }

        private static Product? FindProduct(List<Product> products, int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                    return product;
            }
            return null;
        }

        private static Order? FindOrder(List<Order> orders, int id)
        {
            foreach (var order in orders)
            {
                if (order.Id == id)
                    return order;
            }
            return null;
        }

        private static Customer GetCustomer(List<Customer> customers, int id)
        {
            var customer = FindCustomer(customers, id);
            
            if (customer is null)
                throw new InvalidOperationException($"Customer id {id} not found.");
            
            return customer;
        }

        private static Product GetProduct(List<Product> products, int id)
        {
            var product = FindProduct(products, id);
            
            if (product is null)
                throw new InvalidOperationException($"Product id {id} not found.");

            return product;
        }

        private static Order GetOrder(List<Order> orders, int id)
        {
            var order = FindOrder(orders, id);
            
            if (order is null)
                throw new InvalidOperationException($"Order id {id} not found.");
          
            return order;
        }


        private static void AddCustomer(List<Customer> customers,int id, string name, string email, string city, bool isVip)
        {
            if (FindCustomer(customers, id) is not null)
                throw new InvalidOperationException($"Customer id {id} already exists.");

            customers.Add(new Customer(id, name, email, city, isVip));
        }

        private static void AddProduct(List<Product> products,int id, string name, decimal price, int stock)
        {
            if (FindProduct(products, id) is not null)
                throw new InvalidOperationException($"Product id {id} already exists.");

            products.Add(new Product(id, name, price, stock));
        }

        private static void CreateOrder(List<Customer> customers, List<Order> orders,int orderId, int customerId, DateOnly date)
        {
            if (FindOrder(orders, orderId) is not null)
                throw new InvalidOperationException($"Order id {orderId} already exists.");

            var customer = GetCustomer(customers, customerId);

            var order = customer.PlaceOrder(orderId, date);
            orders.Add(order);
        }

        private static void AddLineToOrder(List<Product> products, List<Order> orders,int orderId, int productId, int quantity)
        {
            var order = GetOrder(orders, orderId);
            var product = GetProduct(products, productId);

            order.AddLine(product, quantity);
        }

        private static void PayOrder(List<Order> orders, int orderId)
        {
            GetOrder(orders, orderId).MarkPaid();
        }

        private static decimal TotalSalesPaidOnly(List<Order> orders)
        {
            decimal sum = 0m;
            foreach (var order in orders)
            {
                if (order.IsPaid)
                    sum += order.Total;
            }
            return sum;
        }









        private static void Seed(List<Customer> customers, List<Product> products)
        {
            AddCustomer(customers, 1, "Ahmed Anwer", "Ahmed@Simulation.com", "Cairo", true);
            AddCustomer(customers, 2, "Khaled Qamara", "Khaled@Simulation.com", "Alexandria", true);
            AddCustomer(customers, 3, "Amr Ahmed", "Amr@Simulation.com", "Giza", false);

            AddProduct(products, 101, "USB Cable", 50m, 100);
            AddProduct(products, 102, "Wireless Mouse", 250m, 40);
            AddProduct(products, 103, "Mechanical Keyboard", 1200m, 15);
            AddProduct(products, 104, "Laptop Stand", 400m, 25);
        }

        private static void RunDemo(List<Customer> customers, List<Product> products, List<Order> orders)
        {
            CreateOrder(customers, orders, 1001, 1, new DateOnly(2026, 9, 15));
            AddLineToOrder(products, orders, 1001, 101, 2);
            AddLineToOrder(products, orders, 1001, 102, 1);
            PayOrder(orders, 1001);

            CreateOrder(customers, orders, 1002, 2, new DateOnly(2026, 9, 15));
            AddLineToOrder(products, orders, 1002, 103, 1);
            AddLineToOrder(products, orders, 1002, 104, 1);

            CreateOrder(customers, orders, 1003, 3, new DateOnly(2026, 9, 16));
            AddLineToOrder(products, orders, 1003, 101, 5);
            PayOrder(orders, 1003);
        }




        private static void PrintCustomers(List<Customer> customers)
        {
            Console.WriteLine($"\n=== CUSTOMERS ({customers.Count}) ===");

            foreach (var customer in customers)
                Console.WriteLine(customer);
        }

        private static void PrintProducts(List<Product> products)
        {
            Console.WriteLine($"\n=== PRODUCTS ({products.Count}) ===");

            foreach (var product in products)
                Console.WriteLine(product);
        }

        private static void PrintOrder(Order order, List<Customer> customers)
        {
            var customer = GetCustomer(customers, order.CustomerId);

            Console.WriteLine($"\n=== ORDER #{order.Id} ===");
            Console.WriteLine($"Date: {order.Date:yyyy-MM-dd}");
            Console.WriteLine($"Customer: {customer.Name} (#{customer.Id})");
            Console.WriteLine($"Paid: {(order.IsPaid ? "yes" : "no")}");
            Console.WriteLine("Lines:");

            foreach (var line in order.GetLines())
                Console.WriteLine($"  - {line.Product.Name}  x{line.Quantity}  @{line.Product.Price:F2}  = {line.LineTotal:F2}");


            Console.WriteLine($"TOTAL: {order.Total:F2}");
        }

        private static void PrintAllOrders(List<Order> orders, List<Customer> customers)
        {
            Console.WriteLine($"\n=== ALL ORDERS ({orders.Count}) ===");

            foreach (var order in orders)
                PrintOrder(order, customers);
        }


        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Please enter a whole number.");
            }
        }

        private static decimal ReadDecimal(string mssage)
        {
            while (true)
            {
                Console.Write(mssage);
                
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;
                
                Console.WriteLine("Please enter a number.");
            }
        }

        private static DateOnly ReadDate(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly value))
                    return value;
                
                Console.WriteLine("Please enter a date like 2026-10-18.");
            }
        }

        private static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? "";
        }


        private static void PrintMenu()
        {
            Console.WriteLine("\n---------- MENU ----------");
            Console.WriteLine("1) Print customers");
            Console.WriteLine("2) Print products");
            Console.WriteLine("3) Print all orders");
            Console.WriteLine("4) Print one order by id");
            Console.WriteLine("5) Create order");
            Console.WriteLine("6) Add line to order");
            Console.WriteLine("7) Mark order paid");
            Console.WriteLine("8) Show paid sales total");
            Console.WriteLine("9) Add customer");
            Console.WriteLine("10) Add product");
            Console.WriteLine("0) Exit");
        }

        private static void RunMenu(List<Customer> customers, List<Product> products, List<Order> orders)
        {
            int choice = -1;
            while (choice != 0)
            {
                PrintMenu();
                choice = ReadInt("Choice: ");

                try
                {
                    switch (choice)
                    {
                        case 1: 
                            PrintCustomers(customers);
                            break;
                        
                        case 2:
                            PrintProducts(products);
                            break;
                        
                        case 3:
                            PrintAllOrders(orders, customers); 
                            break;
                        
                        case 4:
                            PrintOrder(GetOrder(orders, ReadInt("Order id: ")), customers);
                            break;
                        
                        case 5:

                            CreateOrder(customers, orders,ReadInt("Order id: "),
                                ReadInt("Customer id: "),
                                ReadDate("Date (YYYY-MM-DD): "));

                            break;
                        
                        case 6:
                            AddLineToOrder(products, orders,
                                ReadInt("Order id: "),
                                ReadInt("Product id: "),
                                ReadInt("Quantity: "));

                            break;
                        
                        case 7: 
                            PayOrder(orders, ReadInt("Order id: "));
                            
                            break;
                        
                        case 8:
                            Console.WriteLine($"Paid sales total: {TotalSalesPaidOnly(orders):F2}");
                            
                            break;
                        
                        case 9:
                            AddCustomer(customers,
                                ReadInt("Customer id: "),
                                ReadString("Name: "),
                                ReadString("Email: "),
                                ReadString("City: "),
                                ReadString("VIP (y/n): ").Trim().ToLower() == "y");

                            break;
                        
                        case 10:
                            AddProduct(products,
                                ReadInt("Product id: "),
                                ReadString("Name: "),
                                ReadDecimal("Price: "),
                                ReadInt("Stock: "));

                            break;
                        
                        case 0:
                            
                            Console.WriteLine("Bye.");
                            
                            break;
                        default: Console.WriteLine("Unknown choice."); break;
                    }
                }
                catch (Exception ex)  
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }


            }


        }





    
    }



}

