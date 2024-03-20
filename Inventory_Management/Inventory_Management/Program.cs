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
        /// Recursive function that gets the (int) input safely 
        /// </summary>
        /// <returns>returns (int)[1-6]</returns>
        public static int GetUserAction()
        {
            string input = Console.ReadLine();
            int k = -1;

            try
            {
                k = int.Parse(input);
                if (k < 1 || k > 6) throw new OverflowException();
                return k;
            }
            catch (FormatException)
            {
                Console.WriteLine("The action input must be an integer [1-6]");
                return GetUserAction();
            }
            catch (OverflowException)
            {
                Console.WriteLine("The action input must be an integer between 1 and 6 (inclusive)");
                return GetUserAction();
            }
        }
        /// <summary>
        /// Gets the user input of all types (Unparsed)
        /// </summary>
        /// <returns>User input (string)</returns>
        public static string GetUserInput()
        {
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            /*
             * TODO
             * 1. The ability to list multiple product ids to remove:
             *    ~ id1
             *    ~ id2
             *    ~ id3
             *    ~ (some keyword to finish listing ids)
            */

            string actionPrompt =
                "Select an operation:\n" +
                "1. Add a product\n" +
                "2. Remove a product\n" +
                "3. Export the order\n" +
                "4. Search product\n" +
                "5. View inventory statistics\n" +
                "6. Exit";

            bool run = true;
            int userActionBuffer = 0;

            while (run)
            {
                Console.WriteLine(actionPrompt);

                userActionBuffer = GetUserAction();

                switch (userActionBuffer)
                {
                    case 6:
                        // Exit
                        run = false;
                        break;
                    case 1:
                        // Add a product
                        break;
                    case 2:
                        // Remove a product
                        break;
                    case 3:
                        // Export the order
                        break;
                    case 4:
                        // Search product
                        break;
                    case 5:
                        // Show inventory statistics
                        break;
                }
            }
        }
    }
}
