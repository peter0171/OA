using CZBK.ItcastOA.Model;
using CZBK.ItcastOA.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CZBK.ItcastOA.WebApp.Controllers
{
    public class RoleInfoController : Controller
    {
        //
        // GET: /RoleInfo/

        // GET: /RoleInfo/
        IBLL.IRoleInfoService RoleInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取角色信息
        public ActionResult GetRoleInfo()
        {
            int pageIndex = Request["page"] != null ? int.Parse(Request["page"]) : 1;
            int pageSize = Request["rows"] != null ? int.Parse(Request["rows"]) : 5;
            int totalCount;
            short delFlag = (short)DelFlagEnum.Normarl;
            var roleInfoList = RoleInfoService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, r => r.DelFlag == delFlag, r => r.ID, true);
            var temp = from r in roleInfoList
                       select new { ID = r.ID, RoleName = r.RoleName, Sort = r.Sort, SubTime = r.SubTime, Remark = r.Remark };
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 角色添加
        public ActionResult AddRoleInfo(RoleInfo roleInfo)
        {
            roleInfo.DelFlag = 0;
            roleInfo.ModifiedOn = DateTime.Now;
            roleInfo.SubTime = DateTime.Now;
            RoleInfoService.AddEntity(roleInfo);
            return Content("ok");

        }
        #endregion

        #region 展示要修改的角色数据
        public ActionResult ShowEditInfo()
        {
            int id = int.Parse(Request["id"]);
            var roleInfo = RoleInfoService.LoadEntities(r => r.ID == id).FirstOrDefault();
            ViewData.Model = roleInfo;
            return View();
        }
        #endregion

        #region 完成角色修改
        public ActionResult EditRoleInfo(RoleInfo roleInfo)
        {
            if (RoleInfoService.EditEntity(roleInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region 删除角色信息
        public ActionResult DeleteRoleInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (string id in strIds)
            {
                list.Add(int.Parse(id));
            }
            if (RoleInfoService.DeleteEntities(list))
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
