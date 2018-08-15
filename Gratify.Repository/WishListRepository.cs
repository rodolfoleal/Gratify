using CrossSolar.Repository;
using Gratify.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Gratify.Repository
{
    public class WishListRepository : GenericRepository<WishList>, IWishListRepository
    {
        public WishListRepository(GratifyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}