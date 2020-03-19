using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    // Cho phép các thể hiện chuyển sang dạng binary, hỗ trợ cho việc lưu dữ liệu vào session
    [Serializable]
    public class ShoppingCartViewModel
    {
        public int ProductId { set; get; }
        public ProductViewModel Product { set; get; }
        public int Quantity { set; get; }
    }
}