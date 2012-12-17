using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCKinver.Models
{
    public class ContactInfo
    {

        public int ContactInfoId { set; get; }
        
        [DisplayName("您的称呼：")]
        public string Name { set; get; }

        
        [DisplayName("联系邮箱：")]
        //[EmailAddress]
        public string MailAddress { set; get; }

        //[Required(ErrorMessage = "联系电话必填test")]
        [DisplayName("联系电话：")]
        //[Phone]
        public string PhoneNumber { set; get; }

        [DisplayName("留言信息：")]
        public string Message { set; get; }

        public string Service { set; get; }
    }
}