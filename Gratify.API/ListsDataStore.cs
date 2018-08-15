using Gratify.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gratify.API
{
    public class ListsDataStore
    {
        public static ListsDataStore Current { get; } = new ListsDataStore();

        public List<WishList> Lists { get; set; }

        public ListsDataStore()
        {
            Lists = new List<WishList>()
            {
                new WishList()
                {
                    Id = 1,
                    Name = "Lista teste 1",
                    Description="primeira list ade teste"
                },
                new WishList()
                {
                    Id = 2,
                    Name = "Lista teste 2",
                    Description="segunda lista teste"
                },
                new WishList()
                {
                    Id = 3,
                    Name = "Lista teste 3",
                    Description="Terceira lista de teste"
                }
            };
        }
    }
}
