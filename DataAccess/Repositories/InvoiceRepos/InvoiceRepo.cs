using DataAccess.BaseRepository;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.InvoiceRepos
{
    public class InvoiceRepo : BaseRepo<Invoice>, IInvoiceRepo
    {
        private readonly MyContext _context;

        public InvoiceRepo(MyContext context) : base(context)
        {
            this._context = context;
        }
        public async Task AddAsync(Invoice invoice)
        {
            await _context.AddAsync(invoice);
        }

        public void Delete(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices
                .Include(p => p.Booking).ThenInclude(b => b.Gust)
                 .Include(p => p.Booking).ThenInclude(b => b.Room)
                .Include(p => p.Booking).ThenInclude(b => b.ServiceRequests)
                 .ThenInclude(ser => ser.Service)
                .ToListAsync();
        }
        public async Task<Invoice> GetByIdAsync(string id)
        {
            return await _context.Invoices.
                Where(p => p.Id == id)
                .Include(p => p.Booking).ThenInclude(p => p.Gust)
                 .Include(p => p.Booking).ThenInclude(b => b.Room)
                .Include(p => p.Booking).ThenInclude(b => b.ServiceRequests)
                .ThenInclude(ser => ser.Service).FirstOrDefaultAsync();
        }
    }
}
