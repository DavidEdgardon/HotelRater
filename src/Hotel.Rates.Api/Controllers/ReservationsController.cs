using Hotel.Rates.Core.Functionalities;
using Hotel.Rates.Core.Models;
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
    public class ReservationsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public ReservationsController(InventoryContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ReservationModel reservationModel)
        {
            ReservationFunctions x = new ReservationFunctions(_context);
            var result = x.ReserveRoom(reservationModel);
            if (result >= 1)
            {
                return Ok(new
                {
                    Price = result
                });
            }
            return BadRequest();
        }
    }
}
