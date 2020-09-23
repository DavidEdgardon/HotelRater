using Hotel.Rates.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Core.Functionalities
{
    public class RatePlanFunctions
    {
        private readonly InventoryContext _context;

        public RatePlanFunctions(InventoryContext context)
        {
            this._context = context;
        }

        public IQueryable Get()
        {
            var result = _context.RatePlans.Include(r => r.Seasons).Include(r => r.RatePlanRooms).ThenInclude(r => r.Room)
              .Select(x => new
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
            return result;
        }

        public IEnumerable GetPlanbyId(long id)
        {
            var ratePlan = _context.RatePlans
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .FirstOrDefault(x => x.Id == id);

            var result = new{
                RatePlanId = ratePlan.Id,
                RatePlanName = ratePlan.Name,
                ratePlan.RatePlanType,
                ratePlan.Price,
                Seasons = ratePlan.Seasons.Select(s => new{
                    s.Id,
                    s.StartDate,
                    s.EndDate
                }),Rooms = ratePlan.RatePlanRooms.Select(r => new{
                    r.Room.Name,
                    r.Room.MaxAdults,
                    r.Room.MaxChildren,
                    r.Room.Amount
                })
            };
            yield return result;
        }
    }
}
