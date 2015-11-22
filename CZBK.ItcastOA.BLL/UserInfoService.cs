using CZBK.ItcastOA.IBLL;
using CZBK.ItcastOA.Model;
using CZBK.ItcastOA.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.BLL
{
    public partial class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {

        //public override void SetCurretnDal()
        //{
        //    CurrentDal=this.GetCurrentDbSession.UserInfoDal;
        //}

        //public void SetUserInfo()
        //{
        //    this.GetCurrentDbSession.UserInfoDal.AddEntity(userInfo);
        //    this.GetCurrentDbSession.OrderInfoDal.DeleteEntity(orderInfo);
        //    this.GetCurrentDbSession.SaveChanges();
        //}


        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list">要删除的记录的编号</param>
        /// <returns></returns>
        public bool DeleteEntities(List<int> list)
        {
            var userInfoList = this.GetCurrentDbSession.UserInfoDal.LoadEntities(c => list.Contains(c.ID));
            foreach (var userInfo in userInfoList)
            {
                this.GetCurrentDbSession.UserInfoDal.DeleteEntity(userInfo);
            }

            return this.GetCurrentDbSession.SaveChanges();
        }

        /// <summary>
        /// 多条件搜索用户信息
        /// </summary>
        /// <param name="userInfoSearchParam"></param>
        /// <returns></returns>
        public IQueryable<UserInfo> LoadSearchEntities(Model.SearchParam.UserInfoParam userInfoSearchParam)
        {
            short delFlag = (short)DelFlagEnum.Normarl;
            var temp = this.GetCurrentDbSession.UserInfoDal.LoadEntities(c => c.DelFlag == delFlag);
            if (!string.IsNullOrEmpty(userInfoSearchParam.UserName))
            {
                temp = temp.Where<UserInfo>(u => u.UName.Contains(userInfoSearchParam.UserName));
            }
            if (!string.IsNullOrEmpty(userInfoSearchParam.Remark))
            {
                temp = temp.Where<UserInfo>(u => u.Remark.Contains(userInfoSearchParam.Remark));
            }
            userInfoSearchParam.TotalCount = temp.Count();
            return temp.OrderBy<UserInfo, int>(u => u.ID).Skip<UserInfo>((userInfoSearchParam.PageIndex - 1) * userInfoSearchParam.PageSize).Take<UserInfo>(userInfoSearchParam.PageSize);

        }

        /// <summary>
        /// 为用户分配角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIdList"></param>
        /// <returns></returns>
        public bool SetUserOrderInfo(int userId, List<int> roleIdList)
        {
            var userInfo = this.GetCurrentDbSession.UserInfoDal.LoadEntities(u => u.ID == userId).FirstOrDefault();//获取用户
            if (userInfo != null)
            {
                //删除用户已有的角色.
                userInfo.RoleInfo.Clear();
                foreach (int roleId in roleIdList)
                {
                    var roleInfo = this.GetCurrentDbSession.RoleInfoDal.LoadEntities(r => r.ID == roleId).FirstOrDefault();
                    userInfo.RoleInfo.Add(roleInfo);//给用户分配角色
                }
                return this.GetCurrentDbSession.SaveChanges();
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 完成对用户权限的分配
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="actionId"></param>
        /// <param name="isPass"></param>
        /// <returns></returns>
        public bool SetUserActionInfo(int userId, int actionId, bool isPass)
        {
            var r_UserInfo_ActionInfo = this.GetCurrentDbSession.R_UserInfo_ActionInfoDal.LoadEntities(r => r.UserInfoID == userId && r.ActionInfoID == actionId).FirstOrDefault();
            if (r_UserInfo_ActionInfo == null)
            {
                R_UserInfo_ActionInfo r_userInfo_actionInfo = new R_UserInfo_ActionInfo();
                r_userInfo_actionInfo.ActionInfoID = actionId;
                r_userInfo_actionInfo.UserInfoID = userId;
                r_userInfo_actionInfo.IsPass = isPass;
                this.GetCurrentDbSession.R_UserInfo_ActionInfoDal.AddEntity(r_userInfo_actionInfo);
            }
            else
            {
                r_UserInfo_ActionInfo.IsPass = isPass;
            }
            return this.GetCurrentDbSession.SaveChanges();
        }
    }

}
