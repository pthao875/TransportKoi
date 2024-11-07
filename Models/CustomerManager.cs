using System;
using System.Collections.Generic;
using System.Linq;

public class CustomerManager
{
    private List<Customer> customers = new List<Customer>();
    private int nextId = 1;

    // Thêm khách hàng mới
    public void AddCustomer(string name, string phone, string email)
    {
        var customer = new Customer
        {
            Id = nextId++,
            Name = name,
            Phone = phone,
            Email = email
        };
        customers.Add(customer);
        Console.WriteLine("Customer has been added successfully.");
    }

    // Xem tất cả khách hàng
    public void ViewCustomers()
    {
        if (customers.Count > 0)
        {
            Console.WriteLine("\nCustomer List:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Phone: {customer.Phone}, Email: {customer.Email}");
            }
        }
        else
        {
            Console.WriteLine("No customers found.");
        }
    }

    // Tìm khách hàng theo ID
    public Customer GetCustomerById(int id)
    {
        return customers.FirstOrDefault(c => c.Id == id);
    }
}
