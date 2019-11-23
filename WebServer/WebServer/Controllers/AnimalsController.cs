using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.Data;
using WebServer.DTO;

namespace WebServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AnimalsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //api/animals
        [HttpGet]
        public IActionResult GetAnimals()
        {
            List<AnimalDTO> model = _dbContext.Animals.Select(x => new AnimalDTO()
            {
                Name = x.Name,
                Bread = x.Bread,
                DateBirth = x.DateBirth.ToString(),
                Image = x.Image
            }).ToList();

            //model.Add(new AnimalDTO()
            //{
            //    Name = "Oksana",
            //    Bread = "Russian Blue",
            //    DateBirth = "07.01.2017",
            //    Image = "https://www.humanesociety.org/sites/default/files/styles/1240x698/public/2018/06/cat-217679.jpg?h=c4ed616d&itok=3qHaqQ56"
            //});
            return Ok(model);
        }
    }
}