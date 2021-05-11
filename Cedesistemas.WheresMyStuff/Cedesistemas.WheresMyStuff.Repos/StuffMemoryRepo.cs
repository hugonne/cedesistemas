using System;
using System.Collections.Generic;
using System.Linq;
using Cedesistemas.WheresMyStuff.Models;

namespace Cedesistemas.WheresMyStuff.Repos
{
    public class StuffMemoryRepo : IStuffRepo
    {
        private readonly List<Stuff> _stuffList;

        public StuffMemoryRepo()
        {
            _stuffList = new List<Stuff>
            {
                new Stuff {
                    Id = 1,
                    Name = "Llaves del garaje",
                    Location = "Segundo cajón del la biblioteca",
                    DateTime = DateTime.Now,
                    IsVisibleForAll = true
                },
                new Stuff {
                    Id = 2,
                    Name = "Control Remoto",
                    Location = "Segundo cajón del la biblioteca",
                    DateTime = DateTime.Now.AddDays(-1)
                },
                new Stuff {
                    Id = 3,
                    Name = "Caja de herramientas",
                    Location = "Cuarto de linos"
                },
                new Stuff {
                    Id = 4,
                    Name = "Pilas recargables",
                    Location = "Cuarto de linos",
                    IsVisibleForAll = true
                }
            };
        }

        public IEnumerable<Stuff> GetAll()
        {
            return _stuffList;
        }

        public Stuff GetById(int id)
        {
            return _stuffList.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Stuff stuff)
        {
            _stuffList.Add(stuff);
        }

        public void Update(Stuff stuff)
        {
            var existingStuff = GetById(stuff.Id);
            if (existingStuff == null)
            {
                return;
            }

            existingStuff.Name = stuff.Name;
            existingStuff.Location = stuff.Location;
            existingStuff.DateTime = stuff.DateTime;
            existingStuff.IsVisibleForAll = stuff.IsVisibleForAll;
        }

        public void Delete(Stuff stuff)
        {
            _stuffList.Remove(stuff);
        }
    }
}