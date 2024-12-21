using DataAccess.BaseRepository;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ServiceRepos
{
    public class ServiceRepo : BaseRepo<Service>, IServiceRepo
    {
        private readonly MyContext context;

        public ServiceRepo(MyContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await context.Services.Include(s => s.ServiceRequests).ToListAsync();
        }
        public async Task<Service> GetByIdAsync(string id)
        {
            return await context.Services.Include(s => s.ServiceRequests).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
