using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.Model.Enum
{
   public enum DelFlagEnum
    {
       /// <summary>
       /// 正常
       /// </summary>
       Normarl=0,
       /// <summary>
       /// 逻辑删除
       /// </summary>
       LogicDelete=1,

       /// <summary>
       /// 物理删除
       /// </summary>
       PhyicDelete=2

    }
}
