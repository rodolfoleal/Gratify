using Gratify.Domain;
using Gratify.Repository;

namespace Gratify.Business
{
    public class WishListBusiness : GenericBusiness<WishList>, IWishListBusiness
    {
        public WishListBusiness(IWishListRepository repository) : base(repository)
        {
        }
    }
}