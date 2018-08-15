using Gratify.Domain;
using Gratify.Repository;

namespace Gratify.Business
{
    public class WishListBusiness : GenericBusiness<WishList>, IWishListBusinesss
    {
        public WishListBusiness(IWishListRepository repository) : base(repository)
        {
        }
    }
}