using Hotel.Rates.Core;
using Hotel.Rates.Core.Models;
using Hotel.Rates.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Services
{
    public class RatePlanService : IRatePlanService
    {
        private readonly InventoryContext _context;

        public RatePlanService(InventoryContext context)
        {
            _context = context;
        }

        public ServiceResult<IEnumerable<InventoryContext>> GetAll()
        {
            var result = _context.RatePlans.Include(r => r.Seasons).Include(r => r.RatePlanRooms).ThenInclude(r => r.Room).Select(x => new
                {
                    RatePlanId = x.Id,
                    RatePlanName = x.Name,
                    x.RatePlanType,
                    x.Price,
                    Seasons = x.Seasons.Select(s => new
                    {
                        s.Id,
                        s.StartDate,
                        s.EndDate
                    }),
                    Rooms = x.RatePlanRooms.Select(r => new
                    {
                        r.Room.Name,
                        r.Room.MaxAdults,
                        r.Room.MaxChildren,
                        r.Room.Amount
                    })
                });
            return ServiceResult<IEnumerable<InventoryContext>>.SuccessResult(result);
        }
    }
}
