using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AutoPartsStore.Models.DB
{
    public partial class AutoPartsStoreContext : DbContext
    {
        public AutoPartsStoreContext()
        {
        }

        public AutoPartsStoreContext(DbContextOptions<AutoPartsStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applications> Applications { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CellsStocks> CellsStocks { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<DefectiveGoods> DefectiveGoods { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<Models> Models { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SpareParts> SpareParts { get; set; }
        public virtual DbSet<SparePartStock> SparePartStock { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Supplies> Supplies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=AutoPartsStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applications>(entity =>
            {
                entity.HasKey(e => e.IdApplication);

                entity.ToTable("applications");

                entity.Property(e => e.IdApplication).HasColumnName("id_application");

                entity.Property(e => e.FkIdClient).HasColumnName("fk_id_client");

                entity.Property(e => e.FkIdSparePart).HasColumnName("fk_id_spare_part");

                entity.HasOne(d => d.FkIdClientNavigation)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.FkIdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_applications_clients");

                entity.HasOne(d => d.FkIdSparePartNavigation)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.FkIdSparePart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_applications_spare_parts");
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.IdBrand);

                entity.ToTable("brands");

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("categories");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CellsStocks>(entity =>
            {
                entity.HasKey(e => e.IdCell);

                entity.ToTable("cells_stocks");

                entity.Property(e => e.IdCell).HasColumnName("id_cell");

                entity.Property(e => e.Capacity)
                    .HasColumnName("capacity")
                    .HasDefaultValueSql("((15))");

                entity.Property(e => e.FkIdStock).HasColumnName("fk_id_stock");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.HasOne(d => d.FkIdStockNavigation)
                    .WithMany(p => p.CellsStocks)
                    .HasForeignKey(d => d.FkIdStock)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cells_stocks_stock");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("clients");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("fio")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DefectiveGoods>(entity =>
            {
                entity.HasKey(e => e.IdDefect);

                entity.ToTable("defective_goods");

                entity.Property(e => e.IdDefect).HasColumnName("id_defect");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.FkIdSupplies).HasColumnName("fk_id_supplies");

                entity.HasOne(d => d.FkIdSuppliesNavigation)
                    .WithMany(p => p.DefectiveGoods)
                    .HasForeignKey(d => d.FkIdSupplies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_defective_goods_supplies");
            });

            modelBuilder.Entity<Manufacturers>(entity =>
            {
                entity.HasKey(e => e.IdManufacturer);

                entity.ToTable("manufacturers");

                entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Models>(entity =>
            {
                entity.HasKey(e => e.IdModel);

                entity.ToTable("models");

                entity.Property(e => e.IdModel).HasColumnName("id_model");

                entity.Property(e => e.FkIdBrand).HasColumnName("fk_id_brand");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkIdBrandNavigation)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.FkIdBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_models_brands");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("products");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.IdSale);

                entity.ToTable("sales");

                entity.Property(e => e.IdSale).HasColumnName("id_sale");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkIdClient).HasColumnName("fk_id_client");

                entity.Property(e => e.FkIdSparePart).HasColumnName("fk_id_spare_part");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.FkIdClientNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.FkIdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_clients");

                entity.HasOne(d => d.FkIdSparePartNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.FkIdSparePart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_spare_parts");
            });

            modelBuilder.Entity<SpareParts>(entity =>
            {
                entity.HasKey(e => e.IdSparePart);

                entity.ToTable("spare_parts");

                entity.Property(e => e.IdSparePart).HasColumnName("id_sparePart");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FkIdCategory).HasColumnName("fk_id_category");

                entity.Property(e => e.FkIdManuf).HasColumnName("fk_id_manuf");

                entity.Property(e => e.FkIdModel).HasColumnName("fk_id_model");

                entity.Property(e => e.FkIdProduct).HasColumnName("fk_id_product");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.FkIdCategoryNavigation)
                    .WithMany(p => p.SpareParts)
                    .HasForeignKey(d => d.FkIdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_spare_parts_categories");

                entity.HasOne(d => d.FkIdManufNavigation)
                    .WithMany(p => p.SpareParts)
                    .HasForeignKey(d => d.FkIdManuf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_spare_parts_manufacturers");

                entity.HasOne(d => d.FkIdModelNavigation)
                    .WithMany(p => p.SpareParts)
                    .HasForeignKey(d => d.FkIdModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_spare_parts_models");

                entity.HasOne(d => d.FkIdProductNavigation)
                    .WithMany(p => p.SpareParts)
                    .HasForeignKey(d => d.FkIdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_spare_parts_products");
            });

            modelBuilder.Entity<SparePartStock>(entity =>
            {
                entity.HasKey(e => e.IdSpStock);

                entity.ToTable("spare_part_stock");

                entity.Property(e => e.IdSpStock).HasColumnName("id_sp_stock");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.FkIdCell).HasColumnName("fk_id_cell");

                entity.Property(e => e.FkIdSparePart).HasColumnName("fk_id_spare_part");

                entity.HasOne(d => d.FkIdCellNavigation)
                    .WithMany(p => p.SparePartStock)
                    .HasForeignKey(d => d.FkIdCell)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_spare_part_stock_cells_stocks");

                entity.HasOne(d => d.FkIdSparePartNavigation)
                    .WithMany(p => p.SparePartStock)
                    .HasForeignKey(d => d.FkIdSparePart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_spare_part_stock_spare_parts");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.IdStock);

                entity.ToTable("stock");

                entity.Property(e => e.IdStock).HasColumnName("id_stock");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Number).HasColumnName("number");
            });

            modelBuilder.Entity<Supplies>(entity =>
            {
                entity.HasKey(e => e.IdSupply);

                entity.ToTable("supplies");

                entity.Property(e => e.IdSupply).HasColumnName("id_supply");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.FkIdSparePart).HasColumnName("fk_id_spare_part");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.FkIdSparePartNavigation)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.FkIdSparePart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_supplies_spare_parts");
            });
        }
    }
}
