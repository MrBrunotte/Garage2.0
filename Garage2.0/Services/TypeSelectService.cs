using Garage2._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.Services
{
    public class TypeSelectService : ISelectService
    {
        private readonly Garage2_0Context _context;

        public TypeSelectService(Garage2_0Context _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<SelectListItem>> TypeAsync()
        {
            return await _context.ParkedVehicle
                         .Select(m => m.VehicleType)
                         .Distinct()
                         .Select(m => new SelectListItem
                         {
                             Text = m.ToString(),
                             Value = m.ToString()
                         })
                         .ToListAsync();
        }
    }
}
