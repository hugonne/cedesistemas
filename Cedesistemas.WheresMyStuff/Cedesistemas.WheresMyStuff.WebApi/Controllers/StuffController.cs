using System;
using System.Collections.Generic;
using System.Linq;
using Cedesistemas.WheresMyStuff.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cedesistemas.WheresMyStuff.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
    public class StuffController : ControllerBase
    {
        private readonly List<Stuff> _stuffList; //Field - Class variable

        public StuffController()
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

        public IActionResult GetAll()
        {
            return Ok(_stuffList);
        }

        public IActionResult GetById(int id)
        {
            //Linq
            //var stuff = _stuffList.FirstOrDefault(a => a.Id == id);
            //IEnumerable<Stuff> stuffList = _stuffList.Where(a => a.DateTime >= DateTime.Today.AddDays(-7) && a.Location.Contains("Linos"));
            IEnumerable<Stuff> stuffList = _stuffList.Where(a => a.Id == id);
            Stuff stuff = stuffList.FirstOrDefault();

            if (stuff == null)
            {
                return NotFound("El objeto solicitado no se ha encontrado en el sistema"); //HTTP 404
            }
            return Ok(stuff); //HTTP 200
        }
    }
}
