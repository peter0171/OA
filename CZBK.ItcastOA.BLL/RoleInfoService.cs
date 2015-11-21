using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.BLL
{
   public partial class RoleInfoService:BaseService<RoleInfo>,IRoleInfoService
    {
       /// <summary>
       /// 删除角色
       /// </summary>
       /// <param name="RoleIdList"></param>
       /// <returns></returns>

        public bool DeleteEntities(List<int> RoleIdList)
        {
            var roleInfoList = this.GetCurrentDbSession.RoleInfoDal.LoadEntities(r=>RoleIdList.Contains(r.ID));
            foreach (var roleInfo in roleInfoList)
            {
                //roleInfo.UserInfo.Clear();
                //roleInfo.ActionInfo.Clear();
                this.GetCurrentDbSession.RoleInfoDal.DeleteEntity(roleInfo);
            }
           return this.GetCurrentDbSession.SaveChanges();
        }
    }
}
