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
   public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
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
            var userInfoList = this.GetCurrentDbSession.UserInfoDal.LoadEntities(c=>list.Contains(c.ID));
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
            short delFlag=(short)DelFlagEnum.Normarl;
            var temp = this.GetCurrentDbSession.UserInfoDal.LoadEntities(c => c.DelFlag == delFlag);
            if (!string.IsNullOrEmpty(userInfoSearchParam.UserName))
            {
                temp = temp.Where<UserInfo>(u=>u.UName.Contains(userInfoSearchParam.UserName));
            }
            if (!string.IsNullOrEmpty(userInfoSearchParam.Remark))
            {
                temp = temp.Where<UserInfo>(u=>u.Remark.Contains(userInfoSearchParam.Remark));
            }
            userInfoSearchParam.TotalCount = temp.Count();
            return temp.OrderBy<UserInfo, int>(u => u.ID).Skip<UserInfo>((userInfoSearchParam.PageIndex - 1) * userInfoSearchParam.PageSize).Take<UserInfo>(userInfoSearchParam.PageSize);

        }
    }
   
}
