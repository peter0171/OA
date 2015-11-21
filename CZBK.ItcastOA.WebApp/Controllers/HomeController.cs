using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class HomeController :BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (LoginUser != null)
            {
                ViewData["userName"] = LoginUser.UName;
            }
            return View();
        }
        /// <summary>
        /// 传统布局模式
        /// </summary>
        /// <returns></returns>
        public ActionResult HomePage()
        {
            if (LoginUser != null)
            {
                ViewData["userName"] = LoginUser.UName;
            }
            return View();
        }

    }
}
