using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    internal class Program
    {
        /// <summary>
        /// Recursive function for getting user input in range of (inclusive) lower and upper
        /// </summary>
        public static int GetUserAction(int lower, int upper, bool prompt = false)
        {
            if (prompt)
            {
                Console.Write("Your Prompt: ");
            }
            int choice = int.Parse(Console.ReadLine());
            bool pass = true;

            if (choice < lower || choice > upper)
            {
                Console.WriteLine($"The input must be in range [{lower} : {upper}]");
                pass = false;
            }

            if (pass)
            {
                return choice;
            }
            else
            {
                return GetUserAction(lower, upper);
            }
        }
        /// <summary>
        /// Shorthand for getting ID input from the user
        /// </summary>
        public static long ID_Input()
        {
            long id = long.Parse(Console.ReadLine());
            return id;
        }
        /// <summary>
        /// Only show the products matching the filters.
        /// </summary>
        public static void PrintDataOnFilters(List<Product> current, List<string> filters)
        {
            Console.Write("Showing products with the filter(s):\n");
            foreach (string filter in filters)
            {
                Console.Write($"{filter}\n");
            }
            Console.Write('\n');

            foreach (Product prod in current)
            {
                Console.WriteLine(prod.ToString());
            }
        }
        static void Main(string[] args)
        {
            InventoryManager inventoryManager = new InventoryManager();

            string actionPrompt =
                "Select an operation:\n" +
                "1. Add a product\n" +
                "2. Remove a product\n" +
                "3. Search product\n" +
                "4. View inventory statistics\n" +
                "5. Update a product\n" +
                "6. Exit";

            // Main buffer
            int UserAction = 0;
            // User selection for updating
            int update_path = -1;
            // User selection for analysing data
            int analysis_cmd = 0;
            // Main loop condition
            bool run = true;
            // Task loop switch
            bool Task_Search = false;
            // Update process switch
            bool update_process = false;

            // main loop
            while (run)
            {
                Console.WriteLine(actionPrompt);
                UserAction = GetUserAction(1, 6, true);

                if (UserAction == 6)
                {
                    run = false;
                    inventoryManager.SerializeInventory();
                    break;
                }
                else if (UserAction == 1)
                {
                    // Add a product
                    Console.Write("Enter the product's name: ");
                    string prodname = Console.ReadLine();

                    Console.Write("Enter the product's price: ");
                    double prodprice = double.Parse(Console.ReadLine());

                    Console.Write("Enter the product's quantity: ");
                    int prodqty = GetUserAction(0, int.MaxValue);

                    Console.Write("Enter one of the categories: \n");
                    for (int i = 0; i < inventoryManager.Categories.Count; i++)
                    {
                        Console.Write($"{i + 1}. {inventoryManager.Categories[i]}\n");
                    }

                    string prodcat =  inventoryManager.Categories[GetUserAction(0, inventoryManager.Categories.Count) - 1];

                    Console.Write("Enter product manufacturer: ");
                    string prodman = Console.ReadLine();

                    inventoryManager.AddProduct(prodname, prodprice, prodqty, prodcat, prodman);
                }
                else if (UserAction == 2)
                {
                    // Remove a product
                    Console.Write("Enter the product's ID: ");
                    long prodid = ID_Input();

                    inventoryManager.RemoveProduct(prodid);
                }
                else if (UserAction == 3)
                {
                    // Search Product
                    Task_Search = true;
                    List<string> Filters = new List<string>();
                    List<Product> current = inventoryManager.Products;

                    while (Task_Search)
                    {
                        Console.Write("Search by:\n" +
                            "1. Product Name\n" +
                            "2. Product Category\n" +
                            "3. Product Manufacturer\n" +
                            "4. Product Quantity\n" +
                            "5. Product Price\n" +
                            "6. Product ID\n" +
                            "7. Exit\n" +
                            "Your Prompt: ");

                        UserAction = GetUserAction(1, 7);

                        switch (UserAction)
                        {
                            case 7:
                                Task_Search = false;
                                break;
                            case 1:
                                // by name
                                Console.Write("Enter the product's name: ");
                                string prodname = Console.ReadLine();

                                current = current.Where(p => p.Name == prodname).ToList();
                                Filters.Add($"Name: {prodname}");

                                PrintDataOnFilters(current, Filters);
                                break;
                            case 2:
                                // by category
                                Console.Write("Enter the product's category: ");
                                string prodcategory = Console.ReadLine();

                                current = current.Where(p => p.Category == prodcategory).ToList();
                                Filters.Add($"Category: {prodcategory}");

                                PrintDataOnFilters(current, Filters);
                                break;
                            case 3:
                                // by manufacturer
                                Console.Write("Enter the product's manufacturer: ");
                                string prodmanufacturer = Console.ReadLine();

                                current = current.Where(p => p.Manufacturer == prodmanufacturer).ToList();
                                Filters.Add($"Manufacturer: {prodmanufacturer}");

                                PrintDataOnFilters(current, Filters);
                                break;
                            case 4:
                                // by qty
                                Console.Write("Enter the product's quantity: ");
                                int prodqty = GetUserAction(0, int.MaxValue);

                                current = current.Where(p => p.Quantity == prodqty).ToList();
                                Filters.Add($"Quantity: {prodqty}");

                                PrintDataOnFilters(current, Filters);
                                break;
                            case 5:
                                // by price
                                Console.Write("Enter the product's price: ");
                                double prodprice = double.Parse(Console.ReadLine());

                                current = current.Where(p => p.Price == prodprice).ToList();
                                Filters.Add($"Price: {prodprice}");

                                PrintDataOnFilters(current, Filters);
                                break;
                            case 6:
                                // by id
                                Console.Write("Enter the product's ID: ");
                                long id = ID_Input();

                                current = current.Where(p => p.UId == id).ToList();
                                Filters.Add($"ID: {id}");

                                PrintDataOnFilters(current, Filters);
                                break;
                        }
                    }
                }
                else if (UserAction == 4)
                {
                    Console.Write("\nSelect analysis function:\n" +
                        "1. List all products\n" +
                        "2. Get Total holding\n" +
                        "3. Get Average Product value\n" +
                        "4. List all products in range of your price\n" +
                        "5. Get Minimal Holding.\n" +
                        "6. Exit\n");

                    analysis_cmd = GetUserAction(1, 6, true);

                    // Case 6 not included as switch case will exit implicitly
                    switch (analysis_cmd)
                    {
                        case 1:
                            Console.WriteLine("Listing all products.");
                            inventoryManager.RawList();
                            break;
                        case 2:
                            Console.WriteLine("Fetching Total Holding..");
                            Console.WriteLine($"TOTAL: {inventoryManager.GetTotalHolding()}$");
                            break;
                        case 3:
                            double[] stats = inventoryManager.AverageProductValue();
                            Console.WriteLine($"AVERAGE PRODUCT VALUE: {stats[0]}$\n" +
                                $"STANDARD DEVIATION: {stats[1]}\n");
                            break;
                        case 4:
                            Console.Write("Enter your price: ");
                            double val = double.Parse(Console.ReadLine());

                            Console.Write("Enter your range: ");
                            double range = double.Parse(Console.ReadLine());

                            Console.WriteLine($"Listing products with price of {val}$ with range {range}$");
                            inventoryManager.RangeList(val, range);
                            break;
                        case 5:
                            Console.WriteLine($"MINIMAL INVENTORY HOLDING: {inventoryManager.GetMinimalHolding()}$\n");
                            break;
                    }
                }
                else if (UserAction == 5)
                {
                    // Update a product
                    update_process = true;

                    Console.Write("Enter the product's ID: ");
                    long prodid = ID_Input();

                    Product prod = inventoryManager.Products.Find(p => p.UId == prodid);

                    if (prod == null)
                    {
                        Console.WriteLine($"Product not found with ID: {prodid}");
                        update_process = false;
                    }

                    while (update_process)
                    {
                        Console.Write($"Current product info:\n{prod}\n");

                        Console.WriteLine($"Update the product's\n" +
                            $"1. Name\n" +
                            $"2. Price\n" +
                            $"3. Quantity\n" +
                            $"4. Category\n" +
                            $"5. Manufacturer\n" +
                            $"6. Go Back\n");
                        
                        Console.Write("Your Prompt: ");
                        update_path = GetUserAction(1, 6);

                        switch (update_path)
                        {
                            case 6:
                                update_process = false;
                                break;
                            case 1:
                                Console.Write("Enter a new product name: ");
                                prod.Name = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write("Enter the product's new price: ");
                                prod.Price = double.Parse(Console.ReadLine());
                                break;
                            case 3:
                                Console.Write("Enter the product's new quantity: ");
                                prod.Quantity = GetUserAction(0, int.MaxValue);
                                break;
                            case 4:
                                Console.WriteLine("Select the product's new category:");
                                for (int i = 0; i < inventoryManager.Categories.Count; i++)
                                {
                                    Console.Write($"{i+1}. {inventoryManager.Categories[i]}\n");
                                }

                                Console.Write("Your Prompt: ");
                                int selectedCategory = GetUserAction(1, inventoryManager.Categories.Count);

                                prod.Category = inventoryManager.Categories[selectedCategory - 1];
                                break;
                            case 5:
                                Console.WriteLine("Enter the product's new manufacturer: ");
                                string prodmanufacturer = Console.ReadLine();

                                prod.Manufacturer = prodmanufacturer;
                                break;
                        }
                    }
                }
            }
        }
    }
}
