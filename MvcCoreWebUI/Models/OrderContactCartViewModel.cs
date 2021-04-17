using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Models
{
    public class OrderContactCartViewModel
    {
        //Order Contact
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Cart
        public Cart Cart { get; set; }
    }
}
