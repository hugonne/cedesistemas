using System;
using System.Collections.Generic;
using System.Linq;
using Cedesistemas.WheresMyStuff.Models;
using Cedesistemas.WheresMyStuff.Repos;
using Cedesistemas.WheresMyStuff.WebApi.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Cedesistemas.WheresMyStuff.WebApi.Controllers
{
    [ApiController]
    [Route("[action]/[controller]/{id?}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepo _itemsRepo;

        public ItemsController(IItemsRepo itemsRepo)
        {
            _itemsRepo = itemsRepo;
        }

        [HttpGet]
        public IActionResult GetAll(bool locations = false)
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var allLocations = _itemsRepo
                .GetAll(locations)
                .Select(
                    a => new ItemDto
                    {
                        Id = a.Id,
                        Name = a.Name,
                        LocationId = a.LocationId,
                        //Usando operadores de propagación:: (si lo de la izquierda del ? es null, devuelve null
                        //si no es null, devuelve lo de la derecha del ?
                        LocationName = a.Location?.Name?.ToUpper() //a.Location == null ? null : a.Location.Name
                    });
            return Ok(allLocations);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            //Linq
            //var stuff = _stuffList.FirstOrDefault(a => a.Id == id);
            //IEnumerable<Stuff> stuffList = _stuffList.Where(a => a.DateTime >= DateTime.Today.AddDays(-7) && a.Location.Contains("Linos"));
            var item = _itemsRepo.GetById(id);

            if (item == null)
            {
                return NotFound("El objeto solicitado no se ha encontrado en el sistema"); //HTTP 404
            }

            var itemDto = new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                LocationId = item.LocationId,
                LocationName = item.Location.Name
            };
            return Ok(itemDto); //HTTP 200
        }

        [HttpPost]
        public IActionResult Add([FromBody] ItemDto itemDto)
        {
            var item = new Item
            {
                Name = itemDto.Name,
                LocationId = itemDto.LocationId,
                CreatedDateTime = DateTime.Now
            };

            if (!TryValidateModel(item))
            {
                return BadRequest(ModelState);
            }

            var newItemId = _itemsRepo.Add(item);
            _itemsRepo.SaveChanges();

            return Ok(newItemId);
        }

        [HttpPost]
        public IActionResult Update([FromBody] Item item)
        {
            var existingItem = _itemsRepo.GetById(item.Id);
            if (existingItem == null)
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
