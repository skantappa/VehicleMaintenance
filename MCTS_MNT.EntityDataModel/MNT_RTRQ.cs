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
    
    public partial class MNT_RTRQ
    {
        public int BUS_NUMBER { get; set; }
        public string WHEEL_POSITION { get; set; }
        public System.DateTime DATE_96 { get; set; }
        public int MILEAGE_CURRENT { get; set; }
        public int MILEAGE_LIFE { get; set; }
        public int MILEAGE_DUE { get; set; }
        public Nullable<int> MILEAGE_LIFE_DUE { get; set; }
        public string ORIG_MECH_BADGE { get; set; }
        public string ORIG_MECH_NAME { get; set; }
        public Nullable<System.DateTime> ORIG_ENTRY_DATE { get; set; }
        public Nullable<int> ORIG_ENTRY_USERID { get; set; }
        public Nullable<System.DateTime> RETRQ_DATE { get; set; }
        public Nullable<int> RETRQ_HUB_MILEAGE { get; set; }
        public Nullable<int> RETRQ_LIFE_MILEAGE { get; set; }
        public string RETRQ_MECH_BADGE { get; set; }
        public string RETRQ_MECH_NAME { get; set; }
        public Nullable<System.DateTime> RETRQ_ENTRY_DATE { get; set; }
        public Nullable<int> RETRQ_ENTRY_USERID { get; set; }
        public string RETRQ_REQUIRED { get; set; }
        public string STATUS { get; set; }
    }
}
