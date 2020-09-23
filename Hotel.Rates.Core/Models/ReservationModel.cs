using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Core.Models
{
    public class ReservationModel
    {
        public DateTime ReservationStart { get; set; }

        public DateTime ReservationEnd { get; set; }

        public int RatePlanId { get; set; }

        public int RoomId { get; set; }

        public int AmountOfAdults { get; set; }

        public int AmountOfChildren { get; set; }

    }
}
