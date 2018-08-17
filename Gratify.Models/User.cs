using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Gratify.Domain
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }

        public virtual List<WishList> WishLists { get; set; }

        public virtual ICollection<UserToUser> Following { get; set; }
        public virtual ICollection<UserToUser> Followers { get; set; }
    }
}