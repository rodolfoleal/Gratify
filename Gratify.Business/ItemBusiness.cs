using Gratify.Domain;
using Gratify.Repository;

namespace Gratify.Business
{
    public class ItemBusiness : GenericBusiness<Item>, IItemBusinesss
    {
        public ItemBusiness(IItemRepository repository) : base(repository)
        {
        }
    }
}