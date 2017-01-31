using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop2.Models
{
    public enum sign
    {
        law, phis
    }

    public class Buyer
    {
        public int ID { get; set; }
        //edrpou, drfo
        [StringLength(12, MinimumLength = 8)]
        public String stateCode { get; set; }
        public String sign { get; set; }
    }
}