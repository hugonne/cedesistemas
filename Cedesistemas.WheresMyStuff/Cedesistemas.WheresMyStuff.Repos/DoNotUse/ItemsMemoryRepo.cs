using System;
using System.Collections.Generic;
using System.Linq;
using Cedesistemas.WheresMyStuff.Models;

namespace Cedesistemas.WheresMyStuff.Repos
{
    public class ItemsMemoryRepo : IItemsRepo
    {
        private readonly List<Item> _itemList;

        public ItemsMemoryRepo()
        {
            _itemList = new List<Item>
            {
                new Item {
                    Id = 1,
                    Name = "Llaves del garaje",
                    //Location = "Segundo cajón del la biblioteca",
                    DateTime = DateTime.Now,
                    IsVisibleForAll = true
                },
                new Item {
                    Id = 2,
                    Name = "Control Remoto",
                    //Location = "Segundo cajón del la biblioteca",
                    DateTime = DateTime.Now.AddDays(-1)
                },
                new Item {
                    Id = 3,
                    Name = "Caja de herramientas",
                    //Location = "Cuarto de linos"
                },
                new Item {
                    Id = 4,
                    Name = "Pilas recargables",
                    //Location = "Cuarto de linos",
                    IsVisibleForAll = true
                }
            };
        }

        public IEnumerable<Item> GetAll(bool includeLocations = false)
        {
            return _itemList;
        }

        public Item GetById(int id)
        {
            return _itemList.FirstOrDefault(a => a.Id == id);
        }

        public int Add(Item item)
        {
            item.Id = _itemList.Max(a => a.Id) + 1;
            item.DateTime = DateTime.Now;
            _itemList.Add(item);
            return item.Id;
        }

        public void Update(Item item)
        {
            var existingStuff = GetById(item.Id);
            if (existingStuff == null)
            {
                return;
            }

            existingStuff.Name = item.Name;
            existingStuff.Location = item.Location;
            existingStuff.DateTime = item.DateTime;
            existingStuff.IsVisibleForAll = item.IsVisibleForAll;
        }

        public void Delete(Item item)
        {
            _itemList.Remove(item);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}