using Business_Layer.DTOS;
using DataAccess.BaseRepository;
using DataAccess.DTOS;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.BookingRepos
{
    public class BookingRepo : BaseRepo<Booking>, IBookingRepo
    {
        private readonly MyContext context;

        public BookingRepo(MyContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            var x = await context.Bookings.Include(p => p.Gust).Include(p => p.Room).Include(p => p.ServiceRequests).ThenInclude(p => p.Service).ToListAsync();

            return x;
        }
        //public async Task<dynamic> Edit(Booking booking)
        //{
        //    var book = await context.Bookings.FindAsync(booking.Id);
        //    if (book == null)
        //    {
        //        return "Not Found";

        //    }

        //}

        public async Task<Booking> GetByIdAsync(string id)
        {

            var x = await context.Bookings.Include(p => p.Gust).Include(p => p.Room).Include(p => p.ServiceRequests).ThenInclude(p => p.Service).FirstOrDefaultAsync(p => p.Id == id);
            return x;
        }

    }
}
