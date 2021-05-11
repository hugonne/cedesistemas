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
        private readonly StuffSingletonRepo _stuffSingletonRepo;
        private readonly StuffMemoryRepo _stuffMemoryRepo;

        public StuffController()
        {
            _stuffSingletonRepo = StuffSingletonRepo.GetInstance();
            _stuffMemoryRepo = new StuffMemoryRepo();
        }

        public IActionResult GetAll()
        {
            return Ok(_stuffSingletonRepo.StuffList);
        }

        public IActionResult Add()
        {
            _stuffSingletonRepo.StuffList.Add(new Stuff
            {
                Id = 5,
                Name = "Reloj azul",
                Location = "Mesa de noche",
                DateTime = DateTime.Now.AddDays(-1)
            });
            return Ok(_stuffSingletonRepo.StuffList);
        }

        public IActionResult GetById(int id)
        {
            //Linq
            //var stuff = _stuffList.FirstOrDefault(a => a.Id == id);
            //IEnumerable<Stuff> stuffList = _stuffList.Where(a => a.DateTime >= DateTime.Today.AddDays(-7) && a.Location.Contains("Linos"));
            IEnumerable<Stuff> stuffList = _stuffSingletonRepo.StuffList.Where(a => a.Id == id);
            Stuff stuff = stuffList.FirstOrDefault();

            if (stuff == null)
            {
                return NotFound("El objeto solicitado no se ha encontrado en el sistema"); //HTTP 404
            }
            return Ok(stuff); //HTTP 200
        }
    }
}
