 
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
	
	public partial class ActionInfoService :BaseService<ActionInfo>,IActionInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.ActionInfoDal;
        }
    }   
	
	public partial class BooksService :BaseService<Books>,IBooksService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.BooksDal;
        }
    }   
	
	public partial class DepartmentService :BaseService<Department>,IDepartmentService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.DepartmentDal;
        }
    }   
	
	public partial class FileInfoService :BaseService<FileInfo>,IFileInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.FileInfoDal;
        }
    }   
	
	public partial class KeyWordsRankService :BaseService<KeyWordsRank>,IKeyWordsRankService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.KeyWordsRankDal;
        }
    }   
	
	public partial class R_UserInfo_ActionInfoService :BaseService<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.R_UserInfo_ActionInfoDal;
        }
    }   
	
	public partial class RoleInfoService :BaseService<RoleInfo>,IRoleInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.RoleInfoDal;
        }
    }   
	
	public partial class SearchDetailsService :BaseService<SearchDetails>,ISearchDetailsService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.SearchDetailsDal;
        }
    }   
	
	public partial class UserInfoService :BaseService<UserInfo>,IUserInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.UserInfoDal;
        }
    }   
	
	public partial class WF_InstanceService :BaseService<WF_Instance>,IWF_InstanceService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.WF_InstanceDal;
        }
    }   
	
	public partial class WF_StepInfoService :BaseService<WF_StepInfo>,IWF_StepInfoService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.WF_StepInfoDal;
        }
    }   
	
	public partial class WF_TempService :BaseService<WF_Temp>,IWF_TempService
    {
        public override void SetCurretnDal()
        {
            CurrentDal = this.GetCurrentDbSession.WF_TempDal;
        }
    }   
	
}