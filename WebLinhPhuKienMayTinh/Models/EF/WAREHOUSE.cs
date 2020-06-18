namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WAREHOUSE")]
    public partial class WAREHOUSE
    {
        [Key]
        public int id_warehouse { get; set; }

        public int? productId { get; set; }

        [StringLength(255)]
        public string product_more_quantity { get; set; }

        [Column(TypeName = "datetime")]      
        public DateTime? sl_Ngaynhap { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
