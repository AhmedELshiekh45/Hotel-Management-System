using DataAccess.BaseRepository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.PaymentRepos
{
    public interface IPaymentRepo:IBaseRepo<Payment>
    {
    }
}
