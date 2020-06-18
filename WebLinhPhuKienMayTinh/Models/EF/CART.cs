namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CART")]
    public partial class CART
    {
        public int cartId { get; set; }

        public int? productId { get; set; }

        [StringLength(15)]
        public string sld { get; set; }

        [StringLength(50)]
        public string productName { get; set; }

        [StringLength(15)]
        public string price { get; set; }

        public int? quantity { get; set; }

        [StringLength(15)]
        public string images { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
