 

using CZBK.ItcastOA.DAL;
using CZBK.ItcastOA.IDAL;
using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.DALFactory
{
	public partial class DBSession : IDBSession
    {
	
		private IActionInfoDal _ActionInfoDal;
        public IActionInfoDal ActionInfoDal
        {
            get
            {
                if(_ActionInfoDal == null)
                {
                   // _ActionInfoDal = new ActionInfoDal();
				    _ActionInfoDal =AbstractFactory.CreateActionInfoDal();
                }
                return _ActionInfoDal;
            }
            set { _ActionInfoDal = value; }
        }
	
		private IBooksDal _BooksDal;
        public IBooksDal BooksDal
        {
            get
            {
                if(_BooksDal == null)
                {
                   // _BooksDal = new BooksDal();
				    _BooksDal =AbstractFactory.CreateBooksDal();
                }
                return _BooksDal;
            }
            set { _BooksDal = value; }
        }
	
		private IDepartmentDal _DepartmentDal;
        public IDepartmentDal DepartmentDal
        {
            get
            {
                if(_DepartmentDal == null)
                {
                   // _DepartmentDal = new DepartmentDal();
				    _DepartmentDal =AbstractFactory.CreateDepartmentDal();
                }
                return _DepartmentDal;
            }
            set { _DepartmentDal = value; }
        }
	
		private IFileInfoDal _FileInfoDal;
        public IFileInfoDal FileInfoDal
        {
            get
            {
                if(_FileInfoDal == null)
                {
                   // _FileInfoDal = new FileInfoDal();
				    _FileInfoDal =AbstractFactory.CreateFileInfoDal();
                }
                return _FileInfoDal;
            }
            set { _FileInfoDal = value; }
        }
	
		private IKeyWordsRankDal _KeyWordsRankDal;
        public IKeyWordsRankDal KeyWordsRankDal
        {
            get
            {
                if(_KeyWordsRankDal == null)
                {
                   // _KeyWordsRankDal = new KeyWordsRankDal();
				    _KeyWordsRankDal =AbstractFactory.CreateKeyWordsRankDal();
                }
                return _KeyWordsRankDal;
            }
            set { _KeyWordsRankDal = value; }
        }
	
		private IR_UserInfo_ActionInfoDal _R_UserInfo_ActionInfoDal;
        public IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal
        {
            get
            {
                if(_R_UserInfo_ActionInfoDal == null)
                {
                   // _R_UserInfo_ActionInfoDal = new R_UserInfo_ActionInfoDal();
				    _R_UserInfo_ActionInfoDal =AbstractFactory.CreateR_UserInfo_ActionInfoDal();
                }
                return _R_UserInfo_ActionInfoDal;
            }
            set { _R_UserInfo_ActionInfoDal = value; }
        }
	
		private IRoleInfoDal _RoleInfoDal;
        public IRoleInfoDal RoleInfoDal
        {
            get
            {
                if(_RoleInfoDal == null)
                {
                   // _RoleInfoDal = new RoleInfoDal();
				    _RoleInfoDal =AbstractFactory.CreateRoleInfoDal();
                }
                return _RoleInfoDal;
            }
            set { _RoleInfoDal = value; }
        }
	
		private ISearchDetailsDal _SearchDetailsDal;
        public ISearchDetailsDal SearchDetailsDal
        {
            get
            {
                if(_SearchDetailsDal == null)
                {
                   // _SearchDetailsDal = new SearchDetailsDal();
				    _SearchDetailsDal =AbstractFactory.CreateSearchDetailsDal();
                }
                return _SearchDetailsDal;
            }
            set { _SearchDetailsDal = value; }
        }
	
		private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if(_UserInfoDal == null)
                {
                   // _UserInfoDal = new UserInfoDal();
				    _UserInfoDal =AbstractFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set { _UserInfoDal = value; }
        }
	
		private IWF_InstanceDal _WF_InstanceDal;
        public IWF_InstanceDal WF_InstanceDal
        {
            get
            {
                if(_WF_InstanceDal == null)
                {
                   // _WF_InstanceDal = new WF_InstanceDal();
				    _WF_InstanceDal =AbstractFactory.CreateWF_InstanceDal();
                }
                return _WF_InstanceDal;
            }
            set { _WF_InstanceDal = value; }
        }
	
		private IWF_StepInfoDal _WF_StepInfoDal;
        public IWF_StepInfoDal WF_StepInfoDal
        {
            get
            {
                if(_WF_StepInfoDal == null)
                {
                   // _WF_StepInfoDal = new WF_StepInfoDal();
				    _WF_StepInfoDal =AbstractFactory.CreateWF_StepInfoDal();
                }
                return _WF_StepInfoDal;
            }
            set { _WF_StepInfoDal = value; }
        }
	
		private IWF_TempDal _WF_TempDal;
        public IWF_TempDal WF_TempDal
        {
            get
            {
                if(_WF_TempDal == null)
                {
                   // _WF_TempDal = new WF_TempDal();
				    _WF_TempDal =AbstractFactory.CreateWF_TempDal();
                }
                return _WF_TempDal;
            }
            set { _WF_TempDal = value; }
        }
	}	
}