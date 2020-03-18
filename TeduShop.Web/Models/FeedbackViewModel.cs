using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { set; get; }

        [Required (ErrorMessage = "Phải nhập Tên")]
        [StringLength(250, ErrorMessage = "Tên không được quá 250 ký tự")]
        public string Name { set; get; }

        [StringLength(250, ErrorMessage = "Địa chỉ mail không được quá 250 ký tự")]
        public string Email { set; get; }

        [StringLength(250, ErrorMessage = "Tin nhắn không được quá 250 ký tự")]
        public string Message { set; get; }

        public DateTime CreatedDate { set; get; }

        [Required(ErrorMessage = "Phải nhập Trạng thái")]
        public bool Status { set; get; }

        public ContactDetailViewModel ContactDetail { set; get; }
    }
}