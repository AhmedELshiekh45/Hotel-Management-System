using Business_Layer.DTOS;
using DataAccess.BaseRepository;
using DataAccessLayer.Context;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.RoomRepos
{
    public class RoomRepo : BaseRepo<Room>, IRoomRepo
    {
        private readonly MyContext context;

        public RoomRepo(MyContext context) : base(context)
        {
            this.context = context;
        }

        public async Task Edit(RoomDto roomDto)
        {

        }
    }
}
