namespace OVR.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DataGridColumn
    {
        [Key]
        public int DataGridColumnID { get; set; }

        [StringLength(200)]
        public string DataGridName { get; set; }

        [StringLength(100)]
        public string HeaderText { get; set; }

        [StringLength(100)]
        public string DataField { get; set; }

        public string NavigateURL { get; set; }

        [StringLength(200)]
        public string NavigateURLDataField { get; set; }

        public int? SortID { get; set; }

        public int? ColumnTypeID { get; set; }

        public int? EnumTypeID { get; set; }

        public int? ColumnWidth { get; set; }

        [StringLength(100)]
        public string CSSClass { get; set; }

        public bool? IsReadOnly { get; set; }

        public bool? IsAllowHTMLEncode { get; set; }

        public int IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public int ModifiedBy { get; set; }
    }
}
