using CZBK.ItcastOA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.DALFactory
{
    /// <summary>
    /// 抽象工厂：与工厂本质是一样的，都解决对象的创建问题。区别在创建对象的方式不一样，抽象工厂是通过反射的方式创建类的实例。
    /// </summary>
   public class AbstractFactory
    {
       private static readonly string DalAssemblyPath = ConfigurationManager.AppSettings["DalAssemblyPath"];
       private static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
       /// <summary>
       /// 创建UserInfo的实例
       /// </summary>
       /// <returns></returns>
       public static IUserInfoDal CreateUserInfoDal()
       {
           string fullClassName = NameSpace + ".UserInfoDal";//构建类的全名称.
         return  CreateInstance(fullClassName) as IUserInfoDal;
       }
      /// <summary>
      /// 反射
      /// </summary>
      /// <param name="fullClassName"></param>
       public static object  CreateInstance(string fullClassName)
       {
          var assembly= Assembly.Load(DalAssemblyPath);//加载程序集
          return assembly.CreateInstance(fullClassName);
       }

    }
}
