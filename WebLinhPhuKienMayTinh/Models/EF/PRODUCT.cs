namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            CARTs = new HashSet<CART>();
            COMPAREs = new HashSet<COMPARE>();
            ORDERS = new HashSet<ORDER>();
            WAREHOUSEs = new HashSet<WAREHOUSE>();
            WISHLISTs = new HashSet<WISHLIST>();
        }

        public int productId { get; set; }

        [StringLength(255)]
        public string productName { get; set; }

        [StringLength(255)]
        public string product_Code { get; set; }

        [StringLength(255)]
        public string productQuantity { get; set; }

        [StringLength(255)]
        public string procduct_Soldout { get; set; }

        [StringLength(255)]
        public string product_Remain { get; set; }

        public int? catId { get; set; }

        public int? brandId { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string product_Desc { get; set; }

        public int? types { get; set; }

        [StringLength(255)]
        public string price { get; set; }

        [StringLength(255)]
        public string images { get; set; }

        public virtual BRAND BRAND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART> CARTs { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPARE> COMPAREs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WAREHOUSE> WAREHOUSEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WISHLIST> WISHLISTs { get; set; }
    }
}
