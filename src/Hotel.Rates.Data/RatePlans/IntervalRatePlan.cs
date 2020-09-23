using Hotel.Rates.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data.RatePlans
{
    public class IntervalRatePlan : RatePlan
    {
        public IntervalRatePlan()
        {
            RatePlanType = (int)RatePlans.RatePlanType.Interval;
        }

        public int IntervalLength { get; set; }
    }
}
