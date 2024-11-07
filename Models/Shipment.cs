using System;

public class Shipment
{
    public int Id { get; set; }
    public int SenderId { get; set; }    // ID của khách hàng gửi
    public int ReceiverId { get ; set; }  // ID của khách hàng nhận
    public string Address { get; set; }
    public double Weight { get; set; }   // Đơn vị: kg
    public string Status { get; set; }   // Các trạng thái: "Pending", "In Transit", "Delivered", "Cancelled"
}
