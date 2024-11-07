using System;

class Program
{
    static void Main(string[] args)
    {
        CustomerManager customerManager = new CustomerManager();
        ShipmentManager shipmentManager = new ShipmentManager();

        while (true)
        {
            Console.WriteLine("\n1. Add Customer");
            Console.WriteLine("2. View Customers");
            Console.WriteLine("3. Add Shipment");
            Console.WriteLine("4. View Shipments");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Enter email: ");
                    string email = Console.ReadLine();
                    customerManager.AddCustomer(name, phone, email);
                    break;

                case "2":
                    customerManager.ViewCustomers();
                    break;

                case "3":
                    Console.Write("Enter sender's customer ID: ");
                    int senderId = int.Parse(Console.ReadLine());
                    Console.Write("Enter receiver's customer ID: ");
                    int receiverId = int.Parse(Console.ReadLine());
                    Console.Write("Enter address: ");
                    string address = Console.ReadLine();
                    Console.Write("Enter weight (kg): ");
                    double weight = double.Parse(Console.ReadLine());
                    shipmentManager.AddShipment(senderId, receiverId, address, weight);
                    break;

                case "4":
                    shipmentManager.ViewShipments();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
