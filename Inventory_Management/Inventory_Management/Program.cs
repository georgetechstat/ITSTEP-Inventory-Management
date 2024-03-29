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
        public static int GetUserAction(int lower, int upper)
        {
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
        public static void PrintDataOnFilters(List<Product> current, List<string> filters)
        {
            Console.Write("Showing products with the filter(s):");
            foreach (string filter in filters)
            {
                Console.Write($"{filter}\n");
            }

            foreach (Product prod in current)
            {
                Console.Write(prod.ToString());
            }
        }
        static void Main(string[] args)
        {
            InventoryManager inventoryManager = new InventoryManager();

            string actionPrompt =
                "Select an operation:\n" +
                "1. Add a product\n" +
                "2. Remove a product\n" +
                "3. Export the order\n" +
                "4. Search product\n" +
                "5. View inventory statistics\n" +
                "6. Exit";

            int UserAction = 0;
            bool run = true;

            // main loop
            while (run)
            {
                Console.WriteLine(actionPrompt);
                UserAction = GetUserAction(1, 6);

                if (UserAction == 6)
                {
                    run = false;
                    break;
                }
                else if (UserAction == 1)
                {
                    // Add a product
                }
                else if (UserAction == 2)
                {
                    // Remove a product
                }
                else if (UserAction == 3)
                {
                    // Export the order
                }
                else if (UserAction == 4)
                {
                    // Search Product
                    bool Task_Search = true;
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
                            "6. Exit\n" +
                            "Your Prompt: ");

                        UserAction = GetUserAction(1, 6);

                        switch (UserAction)
                        {
                            case 6:
                                Task_Search = false;
                                break;
                            case 1:
                                // by name
                                Console.Write("Enter the product's name: ");
                                string prodname = Console.ReadLine();

                                current = current.Where(p => p.Name == prodname).ToList();
                                Filters.Add($"Name: {prodname}");

                                Console.Write("Showing products with the filter(s):");
                                foreach (string filter in Filters)
                                {
                                    Console.Write($"{filter}\n");
                                }

                                foreach (Product prod in current)
                                {
                                    Console.Write(prod.ToString());
                                }
                                break;
                            case 2:
                                // by category
                                Console.Write("Enter the product's category: ");
                                string prodcategory = Console.ReadLine();

                                current = current.Where(p => p.Category == prodcategory).ToList();
                                Filters.Add($"Category: {prodcategory}");

                                Console.Write("Showing products with the filter(s):");
                                foreach (string filter in Filters)
                                {
                                    Console.Write($"{filter}\n");
                                }

                                foreach (Product prod in current)
                                {
                                    Console.Write(prod.ToString());
                                }
                                break;
                            case 3:
                                // by manufacturer
                                Console.Write("Enter the product's manufacturer: ");
                                string prodmanufacturer = Console.ReadLine();

                                current = current.Where(p => p.Manufacturer == prodmanufacturer).ToList();
                                Filters.Add($"Manufacturer: {prodmanufacturer}");

                                Console.Write("Showing products with the filter(s):");
                                foreach (string filter in Filters)
                                {
                                    Console.Write($"{filter}\n");
                                }

                                foreach (Product prod in current)
                                {
                                    Console.Write(prod.ToString());
                                }
                                break;
                            case 4:
                                // by qty
                                Console.Write("Enter the product's quantity: ");
                                int prodqty = GetUserAction(0, int.MaxValue);

                                current = current.Where(p => p.Quantity == prodqty).ToList();
                                Filters.Add($"Quantity: {prodqty}");

                                Console.Write("Showing products with the filter(s):");
                                foreach (string filter in Filters)
                                {
                                    Console.Write($"{filter}\n");
                                }

                                foreach (Product prod in current)
                                {
                                    Console.Write(prod.ToString());
                                }
                                break;
                            case 5:
                                // by price
                                Console.Write("Enter the product's price: ");
                                double prodprice = double.Parse(Console.ReadLine());

                                current = current.Where(p => p.Price == prodprice).ToList();
                                Filters.Add($"Price: {prodprice}");

                                Console.Write("Showing products with the filter(s):");
                                foreach (string filter in Filters)
                                {
                                    Console.Write($"{filter}\n");
                                }

                                foreach (Product prod in current)
                                {
                                    Console.Write(prod.ToString());
                                }
                                break;
                        }
                    }
                }
                else if (UserAction == 5)
                {
                    // View inventory statistics
                }
            }
        }
    }
}
