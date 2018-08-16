using Gratify.Domain;
using Gratify.Repository;

namespace Gratify.Business
{
    public class ItemBusiness : GenericBusiness<Item>, IItemBusiness
    {
        public ItemBusiness(IItemRepository repository) : base(repository)
        {
        }
    }
}