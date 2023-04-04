using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.Address
{
    public class AddressModel
    {
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int AddressTypeId { get; set; }
    }
}
