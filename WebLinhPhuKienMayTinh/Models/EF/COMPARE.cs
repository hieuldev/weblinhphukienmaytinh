namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMPARE")]
    public partial class COMPARE
    {
        public int id { get; set; }

        public int? customer_id { get; set; }

        public int? productId { get; set; }

        [StringLength(255)]
        public string productName { get; set; }

        [StringLength(255)]
        public string price { get; set; }

        [StringLength(255)]
        public string images { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
