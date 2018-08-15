using Gratify.Domain;
using Gratify.Repository;

namespace Gratify.Business
{
    public class UserBusiness : GenericBusiness<User>, IUserBusinesss
    {
        public UserBusiness(IUserRepository repository) : base(repository)
        {
        }
    }
}