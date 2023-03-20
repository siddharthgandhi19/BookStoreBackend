using BusinessLayer.Interface;
using CommonLayer.Models.Book;
using CommonLayer.Models.WishList;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BusinessLayer.Service
{
    public class WishListBL : IWishListBL
    {
        IWishListRL iWishListRL;
        public WishListBL(IWishListRL iWishListRL)
        {
            this.iWishListRL= iWishListRL;
        }

        public bool AddWishList(int BookId, int UserId)
        {
            try
            {
                return iWishListRL.AddWishList(BookId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteWishList(int WishListId, int UserId)
        {
            try
            {
                return iWishListRL.DeleteWishList(WishListId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<WishListModel> GetAllWishList(int UserId)
        {
            try
            {
                return iWishListRL.GetAllWishList(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
