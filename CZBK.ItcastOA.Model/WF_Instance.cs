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
    
    public partial class WF_Instance
    {
        public WF_Instance()
        {
            this.WF_StepInfo = new HashSet<WF_StepInfo>();
        }
    
        public int ID { get; set; }
        public string InstanceName { get; set; }
        public System.DateTime SubTime { get; set; }
        public int StartedBy { get; set; }
        public short Level { get; set; }
        public string SubForm { get; set; }
        public short Status { get; set; }
        public short Result { get; set; }
        public int WF_TempID { get; set; }
        public System.Guid ApplicationId { get; set; }
    
        public virtual ICollection<WF_StepInfo> WF_StepInfo { get; set; }
        public virtual WF_Temp WF_Temp { get; set; }
    }
}
