using DataAccess.BaseRepository;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RequstService
{
    public class RequstServiceRepo : BaseRepo<ServiceRequest>, IRequst
    {
        private readonly MyContext context;

        public RequstServiceRepo(MyContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ServiceRequest>> GetBookingRequstsAsync(string id)
        {
            var x = await context.ServiceRequests.Include(p => p.Service).Where(s => s.BookingId == id).ToListAsync();
            return x;
        }
    }
}
