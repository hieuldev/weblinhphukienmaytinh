namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLIDER")]
    public partial class SLIDER
    {
        [Key]
        public int sliderID { get; set; }

        [StringLength(255)]
        public string sliderName { get; set; }

        [StringLength(255)]
        public string slider_Image { get; set; }

        public int? type0 { get; set; }
    }
}
