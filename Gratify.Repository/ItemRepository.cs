using CrossSolar.Repository;
using Gratify.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gratify.Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(GratifyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
