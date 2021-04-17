using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Address:IEntity
    {
        public Address()
        {
            UserAddresses = new List<UserAddress>();
        }
        public int Id { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public List<UserAddress> UserAddresses { get; set; }
    }
}
