using System;
using System.Collections.Generic;
using Cedesistemas.WheresMyStuff.Models;

namespace Cedesistemas.WheresMyStuff.Repos
{
    public sealed class StuffRepo
    {
        private static StuffRepo _instance;

        public List<Stuff> StuffList { get; set; }

        private StuffRepo()
        {
            StuffList = new List<Stuff>
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

        public static StuffRepo GetInstance()
        {
            //Opción 1:
            //if (_instance == null)
            //{
            //    _instance = new StuffRepo();
            //}
            //return _instance;

            //Opción 2:
            //return _instance ?? (_instance = new StuffRepo());

            return _instance ??= new StuffRepo();
        }
    }
}
