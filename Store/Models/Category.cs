using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public String name { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}