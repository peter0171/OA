using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IDAL
{
    /// <summary>
    /// 封装的公共方法。
    /// </summary>
   public interface IBaseDal<T>where T:class,new()
    {
       IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
       IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc);
       bool DeleteEntity(T entity);
       bool EditEntity(T entity);
       T AddEntity(T entity);
    }
}
