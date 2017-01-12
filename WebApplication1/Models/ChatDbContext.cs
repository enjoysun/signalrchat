using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext():base("name=chatroom")
        {

        }
        public DbSet<UserInfo> userinfo { get; set; }
        public DbSet<RoomInfo> roominfo { get; set; }
    }
}