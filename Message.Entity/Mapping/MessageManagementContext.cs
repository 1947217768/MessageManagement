using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Message.Entity.Mapping
{
    public partial class MessageManagementContext : DbContext
    {
        public MessageManagementContext() : base()
        {
        }
        public MessageManagementContext(DbContextOptions<MessageManagementContext> options) : base(options)
        {
        }
        public virtual DbSet<DataBase> DataBase { get; set; }
        public virtual DbSet<DataTable> DataTable { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<RoleMenu> RoleMenu { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UploadFileInfo> UploadFileInfo { get; set; }
        public virtual DbSet<SystemController> SystemController { get; set; }
        public virtual DbSet<SystemAction> SystemAction { get; set; }
        public virtual DbSet<MenuAction> MenuAction { get; set; }
        public virtual DbSet<DataType> DataType { get; set; }
        public virtual DbSet<TableFiled> TableFiled { get; set; }
        public virtual DbSet<FieldRelation> FieldRelation { get; set; }
        public virtual DbSet<Memo> Memo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataBase>(entity =>
            {
                entity.Property(e => e.Screater)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SdataBaseName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Smodifier)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sremarks).HasMaxLength(200);

                entity.Property(e => e.TcreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TmodifyTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<DataTable>(entity =>
            {
                entity.Property(e => e.Screater)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Smodifier)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sremarks).HasMaxLength(200);

                entity.Property(e => e.StableName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TcreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TmodifyTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_MENU")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Screater)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SiconUrl).HasMaxLength(128);

                entity.Property(e => e.SlinkUrl).HasMaxLength(128);

                entity.Property(e => e.Smodifier)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Sremarks).HasMaxLength(200);

                entity.Property(e => e.TcreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TmodifyTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.Property(e => e.Screater)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Smodifier)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TcreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TmodifyTime).HasColumnType("datetime");
                entity.HasIndex(e => new { e.IroleId, e.ImenuId });
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.Screater)
                   .IsRequired()
                   .HasMaxLength(50);

                entity.Property(e => e.Smodifier)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sremarks).HasMaxLength(200);

                entity.Property(e => e.TcreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TmodifyTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Roles>();
            modelBuilder.Entity<UserRole>().HasIndex(e => new { e.IroleId, e.IuserId });
            modelBuilder.Entity<UploadFileInfo>().HasIndex(e => new { e.Uid });
            modelBuilder.Entity<MenuAction>().HasIndex(e => new { e.ImenuId, e.IactionId });
            modelBuilder.Entity<SystemAction>().HasIndex(e => new { e.IcontrollerId });
            modelBuilder.Entity<TableFiled>().HasIndex(e => new { e.IdataTableId, e.IdataTypeId });
            modelBuilder.Entity<DataTable>().HasIndex(e => new { e.IdataBaseId });
            modelBuilder.Entity<FieldRelation>().HasIndex(e => new { e.IforeignkeyId, e.IprimarykeyId });
            modelBuilder.Entity<Memo>();
        }
    }
}
