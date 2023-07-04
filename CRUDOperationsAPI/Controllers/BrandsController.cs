using CRUDOperationsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperationsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandDBContext _dbContext;


        public BrandsController(BrandDBContext dBContext)
        {
            _dbContext = this.dbContext;

        }
    }
}
