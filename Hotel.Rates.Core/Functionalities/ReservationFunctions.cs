using Hotel.Rates.Core.Models;
using Hotel.Rates.Data;
using Hotel.Rates.Data.RatePlans;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Core.Functionalities
{
    public class ReservationFunctions
    {
        private readonly InventoryContext _context;

        public ReservationFunctions(InventoryContext context)
        {
            this._context = context;
        }

        public double ReserveRoom(ReservationModel reservationModel)
        {
            var ratePlan = _context
                .NightlyRatePlans
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .First(r => r.Id == reservationModel.RatePlanId);
            var canReserve = ratePlan.Seasons
                .Any(s => s.StartDate <= reservationModel.ReservationStart && s.EndDate >= reservationModel.ReservationEnd);
            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == reservationModel.RoomId && r.RatePlanId == reservationModel.RatePlanId);
            var isRoomAvailable =  0 < room.Room.Amount  &&
                room.Room.MaxAdults >= reservationModel.AmountOfAdults &&
                room.Room.MaxChildren >= reservationModel.AmountOfChildren;
            var days = (reservationModel.ReservationEnd - reservationModel.ReservationStart).TotalDays;
            if(ratePlan.Id == -1 || ratePlan.Id == -2)
            {
                if (canReserve && isRoomAvailable)
                {
                    room.Room.Amount -= 1;
                    _context.SaveChanges();
            
                    double cost = days * ratePlan.Price;
                    return cost;
                 }
            }else if(ratePlan.Id == -3){
                if (days < 3)
                {
                    return 0;
                }
                else
                {
                    if (canReserve && isRoomAvailable)
                    {
                        room.Room.Amount -= 1;
                        _context.SaveChanges();

                        double cost = (days * (ratePlan.Price / 2));
                        return cost;
                    }
                }
            }else if(ratePlan.Id == -4) {
                if (days < 3)
                {
                    return 0;
                }
                else
                {
                    if (canReserve && isRoomAvailable)
                    {
                        room.Room.Amount -= 1;
                        _context.SaveChanges();

                        double cost = (days * (ratePlan.Price / 3));
                        return cost;
                    }
                }
            }
            return 0;
        }
    }
}
