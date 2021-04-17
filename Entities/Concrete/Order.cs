using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public Order()
        {
            Date=DateTime.Now;
            OrderLines = new List<OrderLine>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public  User User { get; set; }
        public List <OrderLine> OrderLines { get; set; }
    }
}
