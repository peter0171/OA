 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IDAL
{
	public partial interface IDBSession
    {

	
		IActionInfoDal ActionInfoDal{get;set;}
	
		IBooksDal BooksDal{get;set;}
	
		IDepartmentDal DepartmentDal{get;set;}
	
		IFileInfoDal FileInfoDal{get;set;}
	
		IKeyWordsRankDal KeyWordsRankDal{get;set;}
	
		IR_UserInfo_ActionInfoDal R_UserInfo_ActionInfoDal{get;set;}
	
		IRoleInfoDal RoleInfoDal{get;set;}
	
		ISearchDetailsDal SearchDetailsDal{get;set;}
	
		IUserInfoDal UserInfoDal{get;set;}
	
		IWF_InstanceDal WF_InstanceDal{get;set;}
	
		IWF_StepInfoDal WF_StepInfoDal{get;set;}
	
		IWF_TempDal WF_TempDal{get;set;}
	}	
}