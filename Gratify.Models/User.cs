using System.Collections.Generic;

namespace Gratify.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Bio { get; set; }

        public string HashSecret { get; set; }

        public virtual List<WishList> WishLists { get; set; }

        public virtual ICollection<UserToUser> Following { get; set; }
        public virtual ICollection<UserToUser> Followers { get; set; }
    }
}