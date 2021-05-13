using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp1.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Cname { get; set; }
        public string  Email { get; set; }
        public string  City { get; set; }
    }
}