using CrossSolar.Repository;
using Gratify.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gratify.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GratifyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
