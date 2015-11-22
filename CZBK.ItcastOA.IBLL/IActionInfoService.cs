using CZBK.ItcastOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IBLL
{
    public partial interface IActionInfoService : IBaseService<ActionInfo>
    {
        bool SetActionRoleInfo(int actionId, List<int> roleIdList);
    }
}
