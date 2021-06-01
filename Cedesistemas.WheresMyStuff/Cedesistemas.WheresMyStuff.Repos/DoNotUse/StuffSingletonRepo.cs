using System;
using System.Collections.Generic;
using Cedesistemas.WheresMyStuff.Models;

namespace Cedesistemas.WheresMyStuff.Repos
{
    /// <summary>
    /// Esta clase sirve solo para efectos ilustrativos. No se debería usar.
    /// </summary>
    public sealed class StuffSingletonRepo
    {
        private static StuffSingletonRepo _instance;

        public List<Item> StuffList { get; set; }

        private StuffSingletonRepo()
        {
            StuffList = new List<Item>
            {
                new Item {
                    Id = 1,
                    Name = "Llaves del garaje",
                    //Location = "Segundo cajón del la biblioteca",
                    CreatedDateTime = DateTime.Now,
                    IsVisibleForAll = true
                },
                new Item {
                    Id = 2,
                    Name = "Control Remoto",
                    //Location = "Segundo cajón del la biblioteca",
                    CreatedDateTime = DateTime.Now.AddDays(-1)
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

        public static StuffSingletonRepo GetInstance()
        {
            //Opción 1:
            //if (_instance == null)
            //{
            //    _instance = new StuffRepo();
            //}
            //return _instance;

            //Opción 2:
            //return _instance ?? (_instance = new StuffRepo());

            return _instance ??= new StuffSingletonRepo();
        }
    }

    public interface ILogin
    {
        bool LogIn(string username, string password);
    }

    public class LocalLogin : ILogin
    {
        public bool LogIn(string username, string password)
        {
            //En este punto voy a mi bd y busco al usuario
            return true;
        }
    }

    public class GoogleLogin : ILogin
    {
        public bool LogIn(string username, string password)
        {
            //En este punto voy a Google y busco al usuario
            return true;
        }
    }
}
