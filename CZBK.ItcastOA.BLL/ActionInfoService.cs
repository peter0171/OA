using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.BLL
{
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService
    {
        /// <summary>
        /// 为权限分配角色
        /// </summary>
        /// <param name="actionId"></param>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        public bool SetActionRoleInfo(int actionId, List<int> roleIdList)
        {
            var actionInfo = this.GetCurrentDbSession.ActionInfoDal.LoadEntities(a => a.ID == actionId).FirstOrDefault();
            if (actionInfo != null)
            {
                actionInfo.RoleInfo.Clear();
                foreach (int roleId in roleIdList)
                {
                    var roleInfo = this.GetCurrentDbSession.RoleInfoDal.LoadEntities(r => r.ID == roleId).FirstOrDefault();
                    actionInfo.RoleInfo.Add(roleInfo);
                }
                return this.GetCurrentDbSession.SaveChanges();
            }
            else
            {
                return false;
            }
        }
    }
}
