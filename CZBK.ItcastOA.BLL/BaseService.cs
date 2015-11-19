using CZBK.ItcastOA.DALFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.BLL
{
   public abstract class BaseService<T>where T:class,new()
    {
       public IDAL.IDBSession GetCurrentDbSession
       {
          get
           {
              // return new DBSession();//暂时
               return DALFactory.DBSessionFactory.CreateDbSession();
           }
            
       }
       public IDAL.IBaseDal<T> CurrentDal { get; set; }
       public abstract void SetCurretnDal();
       public BaseService()
       {
           SetCurretnDal();
       }
       /// <summary>
       /// 查询
       /// </summary>
       /// <param name="whereLambda"></param>
       /// <returns></returns>
       public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
       {
           return CurrentDal.LoadEntities(whereLambda);
       }
      /// <summary>
      /// 分页
      /// </summary>
      /// <typeparam name="s"></typeparam>
      /// <param name="pageIdex"></param>
      /// <param name="pageSize"></param>
      /// <param name="toalCount"></param>
      /// <param name="whereLambda"></param>
      /// <param name="orderbyLambda"></param>
      /// <param name="isAsc"></param>
      /// <returns></returns>
       public IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc)
       {
           return CurrentDal.LoadPageEntities<s>(pageIdex,pageSize,out toalCount,whereLambda,orderbyLambda,isAsc);
       }
       public bool DeleteEntity(T entity)
       {
            CurrentDal.DeleteEntity(entity);
            return this.GetCurrentDbSession.SaveChanges();
       }
       public bool EditEntity(T entity)
       {
           CurrentDal.EditEntity(entity);
           return this.GetCurrentDbSession.SaveChanges();
       }
       public T AddEntity(T entity)
       {
           CurrentDal.AddEntity(entity);
           this.GetCurrentDbSession.SaveChanges();
           return entity;
       }

    }
}
