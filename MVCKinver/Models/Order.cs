using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace MVCKinver.Models
{
    [Bind(Exclude = "OrderId")]
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [DisplayName("省、市")]
        public string City1 { get; set; }

        [DisplayName("市、区")]
        public string City2 { get; set; }

        [DisplayName("区")]
        public string City3 { get; set; }

        [Required(ErrorMessage = "* 请填写联系人姓名")]
        [DisplayName("联系人姓名")]
        [StringLength(160)]
        public string Username { get; set; }

        [Required(ErrorMessage = "* 请填写详细地址")]
        [DisplayName("详细地址")]
        [StringLength(70)]
        public string Address { get; set; }

        [DisplayName("邮编")]
        public string PostalCode { get; set; }

        [StringLength(24)]
        [DisplayName("联系电话")]
        [Required(ErrorMessage = "* 请填写联系电话")]
        public string PhoneNumber { get; set; }

        [StringLength(24)]
        public string Mobile { get; set; }

        [StringLength(24)]
        public string BestDeliverTime { get; set; }

        [StringLength(24)]
        public string DeliverDay { get; set; }

        [ScaffoldColumn(false)]
        //[Range(100,100000)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } 

        //[Required(ErrorMessage = "请填写联系邮箱")]
        //[DisplayName("Email Address")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Email is is not valid.")]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; }

        
    }
}