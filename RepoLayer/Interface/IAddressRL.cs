using CommonLayer.Models.Address;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IAddressRL
    {
        public AddressModel AddAddress(AddressModel addressModel, int UserId);
        public bool DeleteAddress(AddressIdModel addressIdModel);
        public AddressModel UpdateAddress(AddressModel addressModel, int AddressId, int UserId);
        public List<AddressModel> GetAddress();
    }
}
