using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop2.Models
{
    public class ProductPackInfo
    {
        public int ID { get; set; }

        public int ProductID { get; set; }
        public int PackTypeID { get; set; }

        public int quantity { get; set; }

        public virtual Product product { get; set; }
        public virtual PackType packType { get; set; }
    }
}