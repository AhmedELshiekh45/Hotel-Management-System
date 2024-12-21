using DataAccess.Repositories.BookingRepos;
using DataAccess.Repositories.InvoiceRepos;
using DataAccess.Repositories.PaymentRepos;
using DataAccess.Repositories.RequstService;
using DataAccess.Repositories.RoomRepos;
using DataAccess.Repositories.ServiceRepos;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DataAccess.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext context;

        public IBookingRepo BookinRepo { get; }

        public UserManager<User> UserManager { get; }

        public RoleManager<IdentityRole> RoleManager { get; }

        public IRoomRepo RoomRepo { get; }

        public IRequst RequestRepo { get; }

        public IInvoiceRepo InvoiceRepo { get; }

        public IPaymentRepo PaymentRepo { get; }

        public IServiceRepo ServiceRepo { get; }

        public UnitOfWork(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, MyContext context)
        {
            this.context = context;
            this.RoleManager = roleManager;
            this.UserManager = userManager;
            this.BookinRepo = new BookingRepo(context);
            this.RoomRepo = new RoomRepo(context);
            this.RequestRepo = new RequstServiceRepo(context);
            this.ServiceRepo = new ServiceRepo(context);
            this.InvoiceRepo = new InvoiceRepo(context);
            this.PaymentRepo = new PaymentRepo(context);
        }
        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }



    }
}
