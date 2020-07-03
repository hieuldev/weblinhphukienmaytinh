namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        public int id { get; set; }

        public int? productId { get; set; }

        [StringLength(50)]
        public string productName { get; set; }

        public int? customer_id { get; set; }

        public int? quantity { get; set; }

        [StringLength(255)]
        public string price { get; set; }

        [StringLength(255)]
        public string images { get; set; }

        public int? statuss { get; set; }

        public DateTime? dateorder { get; set; }
    }
}
