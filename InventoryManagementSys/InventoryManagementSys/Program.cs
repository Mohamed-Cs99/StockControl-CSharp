using System;

namespace InventoryManagementSys
{
    class Program
    {
        struct Product
        {
            public int id, quantity;
            public string name;
            public double price;
        }

        static Product[] InventoryProducts = new Product[100];
        public static int indx = 0;
        public static int _id = 0;

        public static void AddNewProduct()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Product Name: ");
            string product_name = Console.ReadLine();

            Console.Write("Product Price: ");
            double product_price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Quantity: ");
            int product_quantity = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            Product prod = new Product()
            {
                id = ++_id,
                name = product_name,
                price = product_price,
                quantity = product_quantity,
            };

            InventoryProducts[indx] = prod;
            indx++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nProduct {prod.name} has been added with ID {prod.id}.\n");
            Console.ResetColor();
        }

        public static void DisplayProducts()
        {
            if (indx == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo Products Found!\n");
                Console.ResetColor();
                return;
            }

            for (int i = 0; i < indx; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Product ID: {InventoryProducts[i].id}");
                Console.WriteLine($"Name: {InventoryProducts[i].name}");
                Console.WriteLine($"Price: {InventoryProducts[i].price}");
                Console.WriteLine($"Quantity: {InventoryProducts[i].quantity}\n");
            }
            Console.ResetColor();
        }

        public static void UpdateProduct()
        {
            if (indx == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("List is empty!");
                Console.ResetColor();
                return;
            }

            Console.Write("Product you want to update: ");
            string productName = Console.ReadLine();
            int newIndx = -1; // Initialize variable

            for (int i = 0; i < indx; i++)
            {
                if (productName.ToUpper() == InventoryProducts[i].name.ToUpper())
                {
                    newIndx = i;
                    break;
                }
            }

            if (newIndx == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found!");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter Product New Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter Product New Price: ");
            double newPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Product New Quantity: ");
            int newQuantity = Convert.ToInt32(Console.ReadLine());

            InventoryProducts[newIndx].name = newName;
            InventoryProducts[newIndx].price = newPrice;
            InventoryProducts[newIndx].quantity = newQuantity;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product Updated Successfully!");
            Console.ResetColor();
        }

        public static void SearchForProduct()
        {
            if (indx == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("List is empty!");
                Console.ResetColor();
                return;
            }

            Console.Write("Product Name: ");
            string item = Console.ReadLine();
            int foundIndx = -1;

            for (int i = 0; i < indx; i++)
            {
                if (item.ToUpper() == InventoryProducts[i].name.ToUpper())
                {
                    foundIndx = i;
                    break;
                }
            }

            if (foundIndx == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No products found!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Product Name: {InventoryProducts[foundIndx].name}");
                Console.WriteLine($"Product Price: {InventoryProducts[foundIndx].price}");
                Console.WriteLine($"Product Quantity: {InventoryProducts[foundIndx].quantity}");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================");
            Console.WriteLine("Welcome to Inventory Management System");
            Console.WriteLine("======================================");
            Console.ResetColor();

            bool keepRunning = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Update product");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Search for product");
                Console.WriteLine("5. Display all products");
                Console.WriteLine("6. Exit");
                Console.ResetColor();

                Console.Write("\nSelect an option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddNewProduct();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        // delete product
                        break;
                    case 4:
                        SearchForProduct();
                        break;
                    case 5:
                        DisplayProducts();
                        break;
                    case 6:
                        keepRunning = false;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nThank you for using the Inventory Management System!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid option, please try again!\n");
                        Console.ResetColor();
                        break;
                }
            } while (keepRunning);
        }
    }
}
