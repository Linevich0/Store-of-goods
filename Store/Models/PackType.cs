using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop2.Models
{
    public class PackType
    {
        public int ID { get; set; }
        public String name { get; set; }

        public virtual ICollection<ProductPackInfo> productsPackInfo { get; set; }
    }
}