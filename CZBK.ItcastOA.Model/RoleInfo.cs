//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CZBK.ItcastOA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleInfo
    {
        public RoleInfo()
        {
            this.ActionInfo = new HashSet<ActionInfo>();
            this.UserInfo = new HashSet<UserInfo>();
        }
    
        public int ID { get; set; }
        public string RoleName { get; set; }
        public short DelFlag { get; set; }
        public System.DateTime SubTime { get; set; }
        public string Remark { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public string Sort { get; set; }
    
        public virtual ICollection<ActionInfo> ActionInfo { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
