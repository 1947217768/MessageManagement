﻿// <auto-generated />
using System;
using Message.Entity.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Message.Entity.Migrations
{
    [DbContext(typeof(MessageManagementContext))]
    partial class MessageManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Message.Entity.Mapping.DataBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SdataBaseName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("TmodifyTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("DataBase");
                });

            modelBuilder.Entity("Message.Entity.Mapping.DataTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdataBaseId");

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<string>("StableName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("TmodifyTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdataBaseId");

                    b.ToTable("DataTable");
                });

            modelBuilder.Entity("Message.Entity.Mapping.DataType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<string>("StypeName");

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.HasKey("Id");

                    b.ToTable("DataType");
                });

            modelBuilder.Entity("Message.Entity.Mapping.FieldRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IforeignkeyId");

                    b.Property<int>("IprimarykeyId");

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.HasKey("Id");

                    b.HasIndex("IforeignkeyId", "IprimarykeyId");

                    b.ToTable("FieldRelation");
                });

            modelBuilder.Entity("Message.Entity.Mapping.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Bdisplay");

                    b.Property<int>("IparentId");

                    b.Property<int>("Isort");

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SiconUrl")
                        .HasMaxLength(128);

                    b.Property<string>("SlinkUrl")
                        .HasMaxLength(128);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sname")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("TmodifyTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_MENU")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Message.Entity.Mapping.MenuAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IactionId");

                    b.Property<int>("ImenuId");

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.HasKey("Id");

                    b.HasIndex("ImenuId", "IactionId");

                    b.ToTable("MenuAction");
                });

            modelBuilder.Entity("Message.Entity.Mapping.RoleMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ImenuId");

                    b.Property<int>("IroleId");

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("TmodifyTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IroleId", "ImenuId");

                    b.ToTable("RoleMenu");
                });

            modelBuilder.Entity("Message.Entity.Mapping.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<string>("SroleName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Message.Entity.Mapping.SystemAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bvalid");

                    b.Property<int>("IcontrollerId");

                    b.Property<string>("SactionName")
                        .HasMaxLength(200);

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<string>("SresultType");

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.HasKey("Id");

                    b.HasIndex("IcontrollerId");

                    b.ToTable("SystemAction");
                });

            modelBuilder.Entity("Message.Entity.Mapping.SystemController", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ScontrollerName")
                        .HasMaxLength(100);

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.HasKey("Id");

                    b.ToTable("SystemController");
                });

            modelBuilder.Entity("Message.Entity.Mapping.TableFiled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BisEmpty");

                    b.Property<int>("IdataTableId");

                    b.Property<int>("IdataTypeId");

                    b.Property<int>("ImaxLength");

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SfiledName");

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.HasKey("Id");

                    b.HasIndex("IdataTableId", "IdataTypeId");

                    b.ToTable("TableFiled");
                });

            modelBuilder.Entity("Message.Entity.Mapping.UploadFileInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Isize");

                    b.Property<string>("Screater")
                        .HasMaxLength(50);

                    b.Property<string>("SfileName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("SfilePath")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("SfileType")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Smodifier")
                        .HasMaxLength(50);

                    b.Property<string>("SoriginalFileName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("SrelativePath")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.Property<Guid>("Uid");

                    b.HasKey("Id");

                    b.HasIndex("Uid");

                    b.ToTable("UploadFileInfo");
                });

            modelBuilder.Entity("Message.Entity.Mapping.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("BisLock");

                    b.Property<int>("IfileInfoId");

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SloginLastIp")
                        .HasMaxLength(64);

                    b.Property<string>("SloginName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("SloginPwd")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<string>("SuserEmail")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SuserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("SuserPhone")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("TcreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("TloginLastTime");

                    b.Property<DateTime?>("TmodifyTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Message.Entity.Mapping.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IroleId");

                    b.Property<int>("IuserId");

                    b.Property<string>("Screater")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Smodifier")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sremarks")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("TcreateTime");

                    b.Property<DateTime?>("TmodifyTime");

                    b.HasKey("Id");

                    b.HasIndex("IroleId", "IuserId");

                    b.ToTable("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
