using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop2.Models
{
    public enum unitsType
    {
        ml, l, dp, mm, sm, m, gr, kg
    }

    public class Product
    {
        public int ID { get; set; }
        public String name { get; set; }
        public unitsType? unitsType { get; set; }
        public int barCode { get; set; }
        public int CategoryID { get; set; }

        public virtual Category category { get; set; }
        public virtual ICollection<AddProductInfo> addProductInfo { get; set; }
        public virtual ICollection<ProductPackInfo> productPackInfo { get; set; }
    }
}