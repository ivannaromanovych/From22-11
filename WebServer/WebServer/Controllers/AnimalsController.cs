using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.DTO;

namespace WebServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    public class AnimalsController : ControllerBase
    {
        //api/animals
        [HttpGet]
        public IActionResult GetAnimals()
        {
            List<AnimalDTO> model = new List<AnimalDTO>();
            model.Add(new AnimalDTO()
            {
                Name = "Boria",
                Bread = "Manul",
                DateBirth = "12.12.2018",
                Image = "https://images.earthtouchnews.com/media/179015/06_02_2014_manul_Pallass-cat_1.jpg"
            });
            model.Add(new AnimalDTO()
            {
                Name = "Oksana",
                Bread = "Russian Blue",
                DateBirth = "07.01.2017",
                Image = "https://www.humanesociety.org/sites/default/files/styles/1240x698/public/2018/06/cat-217679.jpg?h=c4ed616d&itok=3qHaqQ56"
            });
            return Ok(model);
        }
    }
}