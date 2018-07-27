using Gratify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gratify.API
{
    public class ListsDataStore
    {
        public static ListsDataStore Current { get; } = new ListsDataStore();

        public List<List> Lists { get; set; }

        public ListsDataStore()
        {
            Lists = new List<List>()
            {
                new List()
                {
                    Id = 1,
                    Name = "Lista teste 1",
                    Description="primeira list ade teste"
                },
                new List()
                {
                    Id = 2,
                    Name = "Lista teste 2",
                    Description="segunda lista teste"
                },
                new List()
                {
                    Id = 3,
                    Name = "Lista teste 3",
                    Description="Terceira lista de teste"
                }
            };
        }
    }
}
