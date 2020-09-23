using Hotel.Rates.Core.Functionalities;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatePlansController : ControllerBase
    {
        private readonly InventoryContext _context;

        public RatePlansController(InventoryContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            RatePlanFunctions x = new RatePlanFunctions(_context);
            return Ok(x.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RatePlanFunctions x = new RatePlanFunctions(_context);
            return Ok(x.GetPlanbyId(id));
        }
    }
}
