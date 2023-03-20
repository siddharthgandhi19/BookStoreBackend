using BusinessLayer.Interface;
using CommonLayer.Models.Book;
using CommonLayer.Models.Cart;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CartBL : ICartBL
    {
        ICartRL iCartRL;
        public CartBL(ICartRL iCartRL)
        {
            this.iCartRL = iCartRL;
        }

        public CartInputModel AddToCart(CartInputModel cartInputModel, int UserId)
        {
            try
            {
                return iCartRL.AddToCart(cartInputModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCart(int CartId)
        {
            try
            {
                return iCartRL.DeleteCart(CartId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetCartOfUser> GetCartByCartId(int UserId, int CartId)
        {
            try
            {
                return iCartRL.GetCartByCartId(UserId, CartId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetCartOfUser> GetCartByUserId(CartByUserIdModel cartByUserIdModel)
        {
            try
            {
                return iCartRL.GetCartByUserId(cartByUserIdModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCart(int CartId, int Quantity, int UserId)
        {
            try
            {
                return iCartRL.UpdateCart(CartId, Quantity, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
