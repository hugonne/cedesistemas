using System;
using System.Collections.Generic;
using System.Linq;
using Cedesistemas.WheresMyStuff.Models;
using Cedesistemas.WheresMyStuff.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Cedesistemas.WheresMyStuff.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepo _itemsRepo;

        public ItemsController(IItemsRepo itemsRepo)
        {
            _itemsRepo = itemsRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_itemsRepo.GetAll());
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            //Linq
            //var stuff = _stuffList.FirstOrDefault(a => a.Id == id);
            //IEnumerable<Stuff> stuffList = _stuffList.Where(a => a.DateTime >= DateTime.Today.AddDays(-7) && a.Location.Contains("Linos"));
            var stuff = _itemsRepo.GetById(id);

            if (stuff == null)
            {
                return NotFound("El objeto solicitado no se ha encontrado en el sistema"); //HTTP 404
            }
            return Ok(stuff); //HTTP 200
        }

        [HttpPost]
        public IActionResult Add([FromBody] Item item)
        {
            var newItemId = _itemsRepo.Add(item);
            _itemsRepo.SaveChanges();
            return Ok(newItemId);
        }

        [HttpPost]
        public IActionResult Update([FromBody] Item item)
        {
            var existingItem = _itemsRepo.GetById(item.Id);
            if(existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = item.Name;
            existingItem.LocationId = item.LocationId;

            //var newItem = new Item
            //{
            //    Name = "Test"
            //};
            //_itemsRepo.Add(newItem);

            _itemsRepo.SaveChanges();
            return Ok();
        }
    }
}
