using CZBK.ItcastOA.Model;
using CZBK.ItcastOA.Model.Enum;
using CZBK.ItcastOA.Model.SearchParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        IBLL.IUserInfoService UserInfoService = new BLL.UserInfoService();
        public ActionResult Index()
        {
          
            return View();
        }
        #region 获取用户数据
        public ActionResult GetUserInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            string name = Request["name"];
            string remark = Request["remark"];
            //构建搜索条件
            int totalCount=0;
            UserInfoParam userInfoParam = new UserInfoParam() {
            
             PageIndex=pageIndex,
             PageSize=pageSize,
             TotalCount=totalCount,
             UserName=name,
             Remark=remark
            };
           
           // short delFlag = (short)DelFlagEnum.Normarl;
           //var userInfoList=UserInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, c => c.DelFlag == delFlag, c => c.ID, true);

            var userInfoList = UserInfoService.LoadSearchEntities(userInfoParam);
           var temp = from u in userInfoList
                      select new { ID = u.ID, UserName = u.UName, UserPass = u.UPwd, Remark = u.Remark, RegTime = u.SubTime };
           return Json(new { rows = temp, total = userInfoParam.TotalCount }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 删除用户数据
        public ActionResult DeleteUserInfo()
        {
            string strId=Request["strId"];
           string[]strIds=strId.Split(',');
           List<int> list = new List<int>();
           foreach (string id in strIds)
           {
               list.Add(int.Parse(id));
           }
           if (UserInfoService.DeleteEntities(list))
           {
               return Content("ok");
           }
           else
           {
               return Content("no");
           }
              
        }
        #endregion

        #region 添加用户信息
        public ActionResult AddUserInfo(UserInfo userInfo)
        {
            userInfo.DelFlag = 0;
            userInfo.ModifiedOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            UserInfoService.AddEntity(userInfo);
            return Content("ok");
        }
        #endregion

        #region 查询要修改的数据
        public ActionResult GetUserInfoModel()
        {
            int id = int.Parse(Request["id"]);
           UserInfo userInfo=UserInfoService.LoadEntities(u=>u.ID==id).FirstOrDefault();
           if (userInfo != null)
           {
               return Json(new{serverData=userInfo,msg="ok"}, JsonRequestBehavior.AllowGet);
           }
           else
           {
               return Json(new {msg="no"},JsonRequestBehavior.AllowGet);
           }
        }
        #endregion

        #region 完成用户信息的修改
        public ActionResult EditUserInfo(UserInfo userInfo)
        {
            userInfo.ModifiedOn = DateTime.Now;
            if (UserInfoService.EditEntity(userInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion
    }
}
