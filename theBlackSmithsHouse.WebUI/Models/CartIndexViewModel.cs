using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using theBlackSmithsHouse.Domain.Entities;

namespace theBlackSmithsHouse.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}