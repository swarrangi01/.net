using CRUDOperationsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandDBContext _dbContext;


        public BrandsController(BrandDBContext dBContext)
        {
            _dbContext = dBContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brands>>> GetBrands() 
        {
            if (_dbContext.Brands == null) 
            { 
            return NotFound();
            }

            return await _dbContext.Brands.ToListAsync();
        
        }


        [HttpGet]
        public async Task<ActionResult<Brands>>  GetBrandsById(int id)
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }

            var brand = await _dbContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return brand;

        }

    }
}
