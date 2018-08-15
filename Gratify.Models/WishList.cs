using System.Collections.Generic;

namespace Gratify.Domain
{
    public class WishList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Item> Items { get; set; }

        public virtual User Owner { get; set; }
    }
}