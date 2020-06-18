namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        public int adminId { get; set; }

        [StringLength(255)]
        public string adminName { get; set; }

        [StringLength(255)]
        public string adminEmail { get; set; }

        [StringLength(255)]
        public string adminUser { get; set; }

        [StringLength(255)]
        public string adminPass { get; set; }

        public int? level0 { get; set; }

        [StringLength(10)]
        public string Status { get; set; }
    }
}
