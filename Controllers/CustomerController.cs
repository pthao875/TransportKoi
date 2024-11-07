using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TransportKoi.Controllers
{
    // Controller cho quản lý khách hàng
    public class CustomerController : Controller
    {
        // Sử dụng CustomerManager để quản lý khách hàng (thêm, sửa, xóa)
        private static List<Customer> customers = new List<Customer>();
        private static int nextCustomerId = 1; // Biến để tạo ID tự động cho khách hàng

        // Trang chủ của Customer, hiển thị danh sách khách hàng
        public IActionResult Index()
        {
            return View(customers); // Trả về danh sách khách hàng tới view
        }

        // Hiển thị form để thêm khách hàng mới
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý khi gửi dữ liệu từ form thêm khách hàng
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Id = nextCustomerId++; // Gán ID cho khách hàng mới
                customers.Add(customer); // Thêm khách hàng vào danh sách
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách khách hàng
            }
            return View(customer); // Nếu có lỗi, giữ nguyên form
        }

        // Hiển thị thông tin chi tiết của một khách hàng
        public IActionResult Details(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null)
            {
                return NotFound(); // Trả về lỗi 404 nếu không tìm thấy khách hàng
            }
            return View(customer); // Trả về thông tin khách hàng tới view
        }

        // Hiển thị form để cập nhật thông tin khách hàng
        public IActionResult Edit(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // Xử lý khi gửi dữ liệu từ form cập nhật thông tin khách hàng
        [HttpPost]
        public IActionResult Edit(Customer updatedCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = customers.Find(c => c.Id == updatedCustomer.Id);
                if (customer != null)
                {
                    customer.Name = updatedCustomer.Name;
                    customer.Phone = updatedCustomer.Phone;
                    customer.Email = updatedCustomer.Email;
                }
                return RedirectToAction("Index");
            }
            return View(updatedCustomer);
        }

        // Xác nhận xóa một khách hàng
        public IActionResult Delete(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // Xử lý khi xóa khách hàng
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = customers.Find(c => c.Id == id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
            return RedirectToAction("Index");
        }
    }
}
