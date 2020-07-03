namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class web : DbContext
    {
        public web()
            : base("name=web1")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<BRAND> BRANDs { get; set; }
        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<COMPARE> COMPAREs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<NEWS> NEWS { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<SLIDER> SLIDERs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WAREHOUSE> WAREHOUSEs { get; set; }
        public virtual DbSet<WISHLIST> WISHLISTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.adminName)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.adminEmail)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.adminUser)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.adminPass)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<CART>()
                .Property(e => e.sld)
                .IsUnicode(false);

            modelBuilder.Entity<CART>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<CART>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<COMPARE>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<COMPARE>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.password0)
                .IsUnicode(false);

            modelBuilder.Entity<NEWS>()
                .Property(e => e.newsTitle)
                .IsUnicode(false);

            modelBuilder.Entity<NEWS>()
                .Property(e => e.newsImg)
                .IsUnicode(false);

            modelBuilder.Entity<NEWS>()
                .Property(e => e.newsType)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.product_Code)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.productQuantity)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.procduct_Soldout)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.product_Remain)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<SLIDER>()
                .Property(e => e.sliderName)
                .IsUnicode(false);

            modelBuilder.Entity<SLIDER>()
                .Property(e => e.slider_Image)
                .IsUnicode(false);

            modelBuilder.Entity<WAREHOUSE>()
                .Property(e => e.product_more_quantity)
                .IsUnicode(false);

            modelBuilder.Entity<WISHLIST>()
                .Property(e => e.productName)
                .IsUnicode(false);

            modelBuilder.Entity<WISHLIST>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<WISHLIST>()
                .Property(e => e.images)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<WebLinhPhuKienMayTinh.Models.RegiterModel> RegiterModels { get; set; }
    }
}
