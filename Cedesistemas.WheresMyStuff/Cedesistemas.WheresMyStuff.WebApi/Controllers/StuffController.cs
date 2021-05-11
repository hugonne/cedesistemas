using System;
using System.Collections.Generic;
using System.Linq;
using Cedesistemas.WheresMyStuff.Models;
using Cedesistemas.WheresMyStuff.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Cedesistemas.WheresMyStuff.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
    public class StuffController : ControllerBase
    {
        private readonly StuffRepo _stuffRepo;

        public StuffController()
        {
            _stuffRepo = StuffRepo.GetInstance();
        }

        public IActionResult GetAll()
        {
            return Ok(_stuffRepo.StuffList);
        }

        public IActionResult Add()
        {
            _stuffRepo.StuffList.Add(new Stuff
            {
                Id = 5,
                Name = "Reloj azul",
                Location = "Mesa de noche",
                DateTime = DateTime.Now.AddDays(-1)
            });
            return Ok(_stuffRepo.StuffList);
        }

        public IActionResult GetById(int id)
        {
            //Linq
            //var stuff = _stuffList.FirstOrDefault(a => a.Id == id);
            //IEnumerable<Stuff> stuffList = _stuffList.Where(a => a.DateTime >= DateTime.Today.AddDays(-7) && a.Location.Contains("Linos"));
            IEnumerable<Stuff> stuffList = _stuffRepo.StuffList.Where(a => a.Id == id);
            Stuff stuff = stuffList.FirstOrDefault();

            if (stuff == null)
            {
                return NotFound("El objeto solicitado no se ha encontrado en el sistema"); //HTTP 404
            }
            return Ok(stuff); //HTTP 200
        }
    }
}
