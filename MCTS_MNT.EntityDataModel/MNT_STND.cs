//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MCTS_MNT.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class MNT_STND
    {
        public short WORK_CODE { get; set; }
        public string COMPLETION_CODE { get; set; }
        public string COMPLETION_CODE_A { get; set; }
        public string FLEET_CODE { get; set; }
        public decimal STANDARD_TIME { get; set; }
        public string STANDARD_ESTIMATE { get; set; }
        public short NUMBER_OF_MECHANICS { get; set; }
    
        public virtual MNT_FLET MNT_FLET { get; set; }
    }
}
