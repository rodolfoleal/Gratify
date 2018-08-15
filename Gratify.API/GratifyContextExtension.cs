using CrossSolar.Repository;
using Gratify.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Gratify.API
{
    public static class GratifyContextExtension
    {
        public static void EnsureSeedDataForContext(this GratifyDbContext context)
        {
            if (context.WishLists.Any())
            {
                return;
            }

            // init seed data
            var wishLists = new List<WishList>()
            {
                new WishList()
                {
                     Name = "Teste WishList",
                     Description = "List to test functionalities",
                     Items = new List<Item>()
                     {
                         new Item() {
                             Name = "Secador de Cabelo",
                             URL = "https://www.americanas.com.br/produto/132532746",
                             Price = 23.12
                         },
                          new Item() {
                             Name = "Grampeador",
                             URL = "https://www.americanas.com.br/produto/132532746"
                          },
                     },
                     Owner = new User()
                    {   Name = "Test User",
                        Email = "test@gmail.com",
                        Bio = "Olá usuário de teste 1",
                        Username = "testuser"
                    }
                },
                new WishList()
                {
                    Name = "Lista Da Val",
                    Description = "Lista para meu aniversário",
                    Items = new List<Item>()
                     {
                         new Item() {
                             Name = "Shampoo",
                             URL = "https://www.americanas.com.br/produto/132532746",
                         },
                          new Item() {
                             Name = "Mouse",
                             URL = "https://www.americanas.com.br/produto/132532746",
                             Price = 10.62
                          },
                     },
                     Owner = new User()
                    {   Name = "Usuario 2",
                        Email = "ususario2@gmail.com",
                        Bio = "Olá usuário de usuario2",
                        Username = "usuario2"
                    }
                },
                new WishList()
                {
                    Name = "Casamento João e Ricardo",
                    Description = "Lista do meu casamento",
                    Items = new List<Item>()
                     {
                         new Item() {
                             Name = "Monitor",
                             URL =  "https://www.americanas.com.br/produto/132532746"
                         },
                          new Item() {
                             Name = "Bicicleta",
                             URL = "https://www.americanas.com.br/produto/132532746",
                             Price = 1900.62
                          },
                     },
                     Owner = new User()
                    {   Name = "Joao",
                        Email = "joa@gmail.com",
                        Bio = "Olá biografia de joao",
                        Username = "joaouser"
                    }
                }
            };

            context.WishLists.AddRange(wishLists);
            context.SaveChanges();  //executes statements
        }
    }
}