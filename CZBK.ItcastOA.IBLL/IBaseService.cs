using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.IBLL
{
   public interface IBaseService<T>where T:class,new()
    {
       IDAL.IDBSession GetCurrentDbSession { get; }
       IDAL.IBaseDal<T> CurrentDal { get; set; }
       IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
       IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc);
       bool DeleteEntity(T entity);
       bool EditEntity(T entity);
       T AddEntity(T entity);

    }
}
