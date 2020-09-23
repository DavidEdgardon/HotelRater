using Hotel.Rates.Core;
using Hotel.Rates.Core.Models;
using Hotel.Rates.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Services
{
    public interface IRatePlanService
    {
        ServiceResult<IEnumerable<InventoryContext>> GetAll();
    }
}
