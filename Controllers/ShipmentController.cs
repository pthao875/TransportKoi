using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TransportKoi.Controllers
{
    // Controller cho quản lý vận chuyển
    public class ShipmentController : Controller
    {
        // Sử dụng danh sách để lưu trữ các lô hàng trong bộ nhớ
        private static List<Shipment> shipments = new List<Shipment>();
        private static int nextShipmentId = 1; // ID tự động cho lô hàng mới

        // Trang chủ của Shipment, hiển thị danh sách lô hàng
        public IActionResult Index()
        {
            return View(shipments); // Trả về danh sách lô hàng tới view
        }

        // Hiển thị form để thêm lô hàng mới
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý khi gửi dữ liệu từ form thêm lô hàng
        [HttpPost]
        public IActionResult Create(Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                shipment.Id = nextShipmentId++; // Gán ID cho lô hàng mới
                shipments.Add(shipment); // Thêm lô hàng vào danh sách
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách lô hàng
            }
            return View(shipment); // Nếu có lỗi, giữ nguyên form
        }

        // Hiển thị thông tin chi tiết của một lô hàng
        public IActionResult Details(int id)
        {
            var shipment = shipments.Find(s => s.Id == id);
            if (shipment == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy lô hàng
            }
            return View(shipment); // Trả về thông tin lô hàng tới view
        }

        // Hiển thị form để cập nhật thông tin lô hàng
        public IActionResult Edit(int id)
        {
            var shipment = shipments.Find(s => s.Id == id);
            if (shipment == null)
            {
                return NotFound();
            }
            return View(shipment);
        }

        // Xử lý khi gửi dữ liệu từ form cập nhật thông tin lô hàng
        [HttpPost]
        public IActionResult Edit(Shipment updatedShipment)
        {
            if (ModelState.IsValid)
            {
                var shipment = shipments.Find(s => s.Id == updatedShipment.Id);
                if (shipment != null)
                {
                    shipment.SenderId = updatedShipment.SenderId;
                    shipment.ReceiverId = updatedShipment.ReceiverId;
                    shipment.Address = updatedShipment.Address;
                    shipment.Weight = updatedShipment.Weight;
                }
                return RedirectToAction("Index");
            }
            return View(updatedShipment);
        }

        // Xác nhận xóa một lô hàng
        public IActionResult Delete(int id)
        {
            var shipment = shipments.Find(s => s.Id == id);
            if (shipment == null)
            {
                return NotFound();
            }
            return View(shipment);
        }

        // Xử lý khi xóa lô hàng
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var shipment = shipments.Find(s => s.Id == id);
            if (shipment != null)
            {
                shipments.Remove(shipment);
            }
            return RedirectToAction("Index");
        }
    }
}
