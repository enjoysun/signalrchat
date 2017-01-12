using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SignalRdemoController : Controller
    {
        // GET: SignalRdemo
        public readonly ChatDbContext dbcontext = new ChatDbContext();
        public ActionResult Index(UserInfo userinfo)
        {
            ViewBag.uid = userinfo.ID;
            var room = dbcontext.roominfo.ToList();
            return View(room);
        }
    }
}