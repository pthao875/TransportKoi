using System;
using System.Collections.Generic;
using System.Linq;

public class ShipmentManager
{
    private List<Shipment> shipments = new List<Shipment>();
    private int nextId = 1;

    // Thêm đơn hàng mới
    public void AddShipment(int senderId, int receiverId, string address, double weight)
    {
        var shipment = new Shipment
        {
            Id = nextId++,
            SenderId = senderId,
            ReceiverId = receiverId,
            Address = address,
            Weight = weight,
            Status = "Pending"
        };
        shipments.Add(shipment);
        Console.WriteLine("Shipment has been added successfully.");
    }

    // Xem danh sách các đơn hàng
    public void ViewShipments()
    {
        if (shipments.Count > 0)
        {
            Console.WriteLine("\nShipment List:");
            foreach (var shipment in shipments)
            {
                Console.WriteLine($"ID: {shipment.Id}, Sender ID: {shipment.SenderId}, Receiver ID: {shipment.ReceiverId}, Address: {shipment.Address}, Weight: {shipment.Weight} kg, Status: {shipment.Status}");
            }
        }
        else
        {
            Console.WriteLine("No shipments found.");
        }
    }

    // Các phương thức UpdateShipmentStatus và DeleteShipment vẫn giữ nguyên
}
