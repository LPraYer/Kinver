using System;
using System.ComponentModel.DataAnnotations;

namespace MVCKinver.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Product Product { get; set; }
        //public virtual ProductSize ProductSize { get; set; }
    }
}