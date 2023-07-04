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


        [HttpGet("{id}")]
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



        [HttpPost]
        public async Task<ActionResult<Brands>> AddBrand(Brands brand) 
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();

            return brand;

        
        }
        

        [HttpPut]
        public async Task<ActionResult<Brands>> UpdateDB(int id, Brands brand) {

            if (id != brand.Id) {
                return BadRequest();

            }


            try
            {
                _dbContext.Brands.Update(brand);
                await _dbContext.SaveChangesAsync();
                return brand;
            }
            catch (Exception ex) {
                return BadRequest("Failed to update because " + ex.Message);
            }

        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Brands>> DeleteRecord(int id)
        {
            if (_dbContext.Brands == null)
            { 
            return BadRequest(); 
            }

            var brand=_dbContext.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

    }




}
