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
    
    public partial class Department
    {
        public Department()
        {
            this.ActionInfo = new HashSet<ActionInfo>();
            this.UserInfo = new HashSet<UserInfo>();
        }
    
        public int ID { get; set; }
        public string DepName { get; set; }
        public int ParentId { get; set; }
        public string TreePath { get; set; }
        public int Level { get; set; }
        public bool IsLeaf { get; set; }
    
        public virtual ICollection<ActionInfo> ActionInfo { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
