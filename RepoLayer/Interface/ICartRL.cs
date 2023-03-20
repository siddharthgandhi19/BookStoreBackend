using CommonLayer.Models.Cart;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ICartRL
    {
        public CartInputModel AddToCart(CartInputModel cartInputModel, int UserId);
        public bool DeleteCart(int CartId);
        public bool UpdateCart(int CartId, int Quantity, int UserId);
        public IEnumerable<GetCartOfUser> GetCartByUserId(CartByUserIdModel cartByUserIdModel);
        public IEnumerable<GetCartOfUser> GetCartByCartId(int UserId, int CartId);
    }
}
