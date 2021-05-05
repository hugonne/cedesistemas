using System;
using Microsoft.AspNetCore.Mvc;

namespace Cedesistema.NetCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]
    public class PeopleController : ControllerBase
    {
        public PeopleController()
        {
        }

        //Endpoint
        [HttpGet]
        public string Saludar(string id)
        {
            return $"Hola mundo {id}";
        }

        [HttpGet]
        public string Despedirse()
        {
            return "Chao!"; ;
        }

        [HttpGet()]
        public string SaludarAAlguien(string id, string apellido)
        {
            return $"Hola {id} {apellido}";
        }
    }
}
