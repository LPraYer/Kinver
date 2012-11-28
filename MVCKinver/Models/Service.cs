using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCKinver.Models
{
    public class Service
    {
        [DisplayName("服务id")]
        public int ServiceId { get; set; }

        [DisplayName("服务名称")]
        public string Title { get; set; }

        [DisplayName("主要描述")]
        public string KeyDescription { get; set; }

        [DisplayName("辅助描述")]
        public string PlusDescription { get; set; }

        [DisplayName("图片地址")]
        public string ServiceImageUrl { get; set; }
    }
}