using CommonLayer.Models.WishList;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
        public bool AddWishList(int BookId, int UserId);
        public bool DeleteWishList(int WishListId, int UserId);
        public IEnumerable<WishListModel> GetAllWishList(int UserId);
    }
}
