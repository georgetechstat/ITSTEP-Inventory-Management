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
        public static long ID_Input()
        {
            long id = long.Parse(Console.ReadLine());
            return id;
        }
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
                "6. Update a product\n" +
                "7. Exit";

            int UserAction = 0;
            bool run = true;
            bool Task_Search = false;

            // main loop
            while (run)
            {
                Console.WriteLine(actionPrompt);
                UserAction = GetUserAction(1, 7);

                if (UserAction == 7)
                {
                    run = false;
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
                    // Export the order
                }
                else if (UserAction == 4)
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
                else if (UserAction == 5)
                {
                    // View inventory statistics

                    // TEMPORARY FUNCTIONALITY: LIST PRODUCTS.
                    // TO BE: FUNCTIONAL STATISTICAL ANALYSIS TOOL

                    inventoryManager.RawList();
                }
                else if (UserAction == 6)
                {
                    // Update a product
                }
            }
        }
    }
}
