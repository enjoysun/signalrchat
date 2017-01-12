using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public readonly ChatDbContext dbcontext = new ChatDbContext();
        public ActionResult Index()
        {
            ViewBag.sort = Enum.GetValues(typeof(Roomsort)).Cast<Roomsort>();
            return View();
        }
        [HttpPost]
        public ActionResult Index(RoomInfo room)
        {
            room.ID = dbcontext.roominfo.ToList().Count + 1;
            room.Master = Convert.ToInt32(Request.QueryString["uid"]);
            dbcontext.roominfo.Add(room);
            dbcontext.SaveChanges();
            return RedirectToAction("Index", "SignalRdemo", room);
        }
    }
}