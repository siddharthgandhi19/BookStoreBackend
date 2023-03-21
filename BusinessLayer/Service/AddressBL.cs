using BusinessLayer.Interface;
using CommonLayer.Models.Address;
using CommonLayer.Models.Book;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBL : IAddressBL
    {
        IAddressRL iAddressRL;
        public AddressBL(IAddressRL iAddressRL)
        {
            this.iAddressRL = iAddressRL;
        }

        public AddressModel AddAddress(AddressModel addressModel, int UserId)
        {
            try
            {
                return iAddressRL.AddAddress(addressModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAddress(AddressIdModel addressIdModel)
        {
            try
            {
                return iAddressRL.DeleteAddress(addressIdModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AddressModel> GetAddress()
        {
            try
            {
                return iAddressRL.GetAddress();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AddressModel UpdateAddress(AddressModel addressModel, int AddressId, int UserId)
        {
            try
            {
                return iAddressRL.UpdateAddress(addressModel, AddressId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
