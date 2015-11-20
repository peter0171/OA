using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        IBLL.IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            //CheckCookieInfo();
            return View();
        }
        #region 校验用户的登录信息
        public ActionResult CheckLogin()
        {
            //1:判断验证码是否正确
            string validateCode = Session["validateCode"] == null ? string.Empty : Session["validateCode"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:验证码错误!!");
            }
            Session["validateCode"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:验证码错误!!");
            }
            //2:判断用户输入的用户名与密码
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            UserInfo userInfo = UserInfoService.LoadEntities(u => u.UName == userName && u.UPwd == userPwd).FirstOrDefault();
            if (userInfo != null)
            {
                //Session["userInfo"] = userInfo;
                string sessionId = Guid.NewGuid().ToString();//作为Memcache的key
                Common.MemcacheHelper.Set(sessionId, Common.SerializerHelper.SerializeToString(userInfo), DateTime.Now.AddMinutes(20));//使用Memcache代替Session解决数据在不同Web服务器之间共享的问题。
                Response.Cookies["sessionId"].Value = sessionId;//将Memcache的key以cookie的形式返回到浏览器端的内存中，当用户再次请求其它的页面请求报文中会以Cookie将该值再次发送服务端。
                //记住我
                if (!string.IsNullOrEmpty(Request["checkMe"]))
                {
                    HttpCookie cookie1 = new HttpCookie("cp1", userInfo.UName);
                    HttpCookie cookie2 = new HttpCookie("cp2", Common.WebCommon.GetMd5String(Common.WebCommon.GetMd5String(userInfo.UPwd)));
                    cookie1.Expires = DateTime.Now.AddDays(3);
                    cookie2.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie1);
                    Response.Cookies.Add(cookie2);
                }

                return Content("ok:登录成功!!");
            }
            else
            {
                return Content("no:用户名或密码错误!!");
            }

        }
        #endregion

        #region 展示验证码
        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["validateCode"] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);
            return File(buffer, "image/jpeg");
        }
        #endregion

        #region 判断Cookie信息
        private void CheckCookieInfo()
        {
            if (Request.Cookies["cp1"] != null && Request.Cookies["cp2"] != null)
            {
                string userName = Request.Cookies["cp1"].Value;
                string userPwd = Request.Cookies["cp2"].Value;
                //判断Cookie中存储的用户密码和用户名是否正确.
                var userInfo = UserInfoService.LoadEntities(u => u.UName == userName).FirstOrDefault();

                if (userInfo != null)
                {
                    //注意：将用户的密码保存到数据库时一定要加密。
                    //由于数据库中存储的密码是明文，所以这里需要将数据库中存储的密码两次MD5运算以后在进行比较。
                    if (Common.WebCommon.GetMd5String(Common.WebCommon.GetMd5String(userInfo.UPwd)) == userPwd)
                    {
                        string sessionId = Guid.NewGuid().ToString();//作为Memcache的key
                        Common.MemcacheHelper.Set(sessionId, Common.SerializerHelper.SerializeToString(userInfo), DateTime.Now.AddMinutes(20));//使用Memcache代替Session解决数据在不同Web服务器之间共享的问题。
                        Response.Cookies["sessionId"].Value = sessionId;//将Memcache的key以cookie的形式返回到浏览器端的内存中，当用户再次请求其它的页面请求报文中会以Cookie将该值再次发送服务端。
                        Response.Redirect("/Home/Index");

                    }
                }
                Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        #endregion
        #region 退出登录
        public ActionResult Logout()
        {
            if (Request.Cookies["sessionId"] != null)
            {
                string key = Request.Cookies["sessionId"].Value;
                Common.MemcacheHelper.Delete(key);
                Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
            }
            return Redirect("/Login/Index");
        }
        #endregion

    }
}

