using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class BaseController : Controller
    {
       

 
        // GET: /Base/
        public UserInfo LoginUser { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {                                                                                                    
            base.OnActionExecuting(filterContext);
            bool isExt = false;
            //  if (Session["userInfo"] == null)
            if (Request.Cookies["sessionId"] != null)
            {
                string sessionId = Request.Cookies["sessionId"].Value;//接收从Cookie中传递过来的Memcache的key
                object obj = Common.MemcacheHelper.Get(sessionId);//根据key从Memcache中获取用户的信息
                if (obj != null)
                {
                    UserInfo userInfo = Common.SerializerHelper.DeserializeToObject<UserInfo>(obj.ToString());
                    LoginUser = userInfo;
                    isExt = true;
                    //Common.MemcacheHelper.Set(sessionId, obj.ToString(), DateTime.Now.AddMinutes(20));//模拟滑动过期时间
                }

                                                                                                                                        
            }
            if (!isExt)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
                return;
            }

        }

    }
}
