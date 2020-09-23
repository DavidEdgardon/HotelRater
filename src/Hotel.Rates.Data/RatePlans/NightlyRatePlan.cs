using Hotel.Rates.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data.RatePlans
{
    public class NightlyRatePlan : RatePlan
    {
        public NightlyRatePlan()
        {
            RatePlanType = (int)RatePlans.RatePlanType.Nightly;
        }
    }
}
