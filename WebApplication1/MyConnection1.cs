using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebApplication1.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace WebApplication1
{
    public class MyConnection1 : PersistentConnection
    {
        public readonly ChatDbContext dbcontext = new ChatDbContext();
        //protected override Task OnConnected(IRequest request, string connectionId)
        //{
        //    return Connection.Send(connectionId, "{\"data\":\"已连接persistentconnection欢迎使用！\"}");
        //}

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var dt = JsonConvert.DeserializeObject<Recivedata>(data);
            var user = dbcontext.userinfo.Where(c => c.ID == dt.uid).FirstOrDefault();
            var room = dbcontext.roominfo.Where(c => c.ID == dt.rid).FirstOrDefault();
            if (dt.sort == action.connectioned.ToString())
            {
                this.Groups.Add(connectionId, room.Roomname);
                return this.Groups.Send(room.Roomname,"{\"data\":\"欢迎\""+ user.Nickname +" \"进入\""+ room.Roomname+"}",  connectionId);
            }
            else if (dt.sort == action.sendmessage.ToString())
            {
                return this.Groups.Send(room.Roomname, "{\"data\":\" "+ dt.data +"\",\"sendpeo\":\" "+ user.Nickname + "\",\"sendtime\":\"" + DateTime.Now +"\"}", connectionId);
            }
            else
            {
                return Connection.Broadcast(data);
            }

        }
    }
    public class Chatdata
    {
        public RoomInfo room { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public action Connsort { get; set; }
        public Modeldata data { get; set; }
        public UserInfo user { get; set; }
    }
    public class Recivedata
    {
        public int uid { get; set; }
        public string sort { get; set; }
        public string data { get; set; }
        public int rid { get; set; }
    }
    public class Modeldata
    {
        public string chatmsage { get; set; }

    }
    public enum action
    {
        connectioned,
        sendmessage
    }
}