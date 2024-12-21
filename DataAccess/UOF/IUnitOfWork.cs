using DataAccess.Repositories.BookingRepos;
using DataAccess.Repositories.InvoiceRepos;
using DataAccess.Repositories.PaymentRepos;
using DataAccess.Repositories.RequstService;
using DataAccess.Repositories.RoomRepos;
using DataAccess.Repositories.ServiceRepos;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UOF
{
    public interface IUnitOfWork:IDisposable
    {
        public IBookingRepo BookinRepo { get;}
        public IRoomRepo RoomRepo { get;}
        public UserManager<User> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public IRequst RequestRepo { get; }
        public IPaymentRepo PaymentRepo { get; }
        public IInvoiceRepo InvoiceRepo { get; }
        public IServiceRepo ServiceRepo { get; }
        Task<int> CompleteAsync();
    }
}
