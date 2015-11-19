using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastOA.SpringNet
{
    class UserInfoService:IUserInfoService
    {
        public string UserName { get; set; }
        public Person Person { get; set; }

        public string ShowMsg()
        {
            return "hello world"+UserName+"age :"+Person.Age;
        }
    }
}
