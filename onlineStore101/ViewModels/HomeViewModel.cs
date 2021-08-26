using onlineStore101.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineStore101.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}