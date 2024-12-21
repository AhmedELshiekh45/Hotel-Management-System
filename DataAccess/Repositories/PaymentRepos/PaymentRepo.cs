using DataAccess.BaseRepository;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.PaymentRepos
{
    public class PaymentRepo : BaseRepo<Payment>, IPaymentRepo
    {
        public PaymentRepo(MyContext context) : base(context)
        {
        }
    }
}
