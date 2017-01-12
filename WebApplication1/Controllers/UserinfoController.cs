using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserinfoController : Controller
    {
        // GET: Userinfo
        public readonly ChatDbContext dbcontext = new ChatDbContext();
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                int id = dbcontext.userinfo.Select(c => c.ID).ToList().Count + 1;
                dbcontext.userinfo.Add(new UserInfo()
                {
                    ID = id,
                    Nickname = userinfo.Nickname,
                    Realname = userinfo.Realname
                });
                userinfo.ID = id;
                dbcontext.SaveChanges();
                return RedirectToAction("Index", "SignalRdemo", userinfo);
            }
            return View();
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                var user = dbcontext.userinfo.Where(c => c.Nickname == userinfo.Nickname).FirstOrDefault();
                if (user != null)
                {
                    if (user.Realname == userinfo.Realname)
                    {
                        userinfo.ID = user.ID;
                        return RedirectToAction("Index", "SignalRdemo", userinfo);
                    }
                }
                return View();
            }
            return View();
        }
    }
}