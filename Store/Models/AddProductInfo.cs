using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop2.Models
{
    public class AddProductInfo
    {
        public int ID { get; set; }
        public int ProductID { get; set; }

        public decimal price { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        public virtual Product product { get; set; }
    }
}
