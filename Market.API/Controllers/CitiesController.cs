using Market.API.Data;
using Market.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Market.API.Controllers
{

    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {

        private readonly DataContext _context;

        public CitiesController(DataContext context)
        {



            _context = context;
        }


        //get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Cities.ToListAsync());
        }

        
        //Get por parámetro
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (city == null)
            {

                return NotFound();
            }

            return Ok(city);

        }

        // Post- Create
        [HttpPost]
        public async Task<ActionResult> Post(City city)
        {

            _context.Add(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }

        // Put-- update
        [HttpPut]
        public async Task<ActionResult> Put(City city)
        {

            _context.Update(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Cities
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (filaafectada == 0)
            {

                return NotFound();

            }

            return NoContent();



        }

    }
}
