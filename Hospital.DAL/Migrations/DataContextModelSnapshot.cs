﻿// <auto-generated />
using System;
using Hospital.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("Hospital.DAL.Entities.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Bio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bios");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Context")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductBrandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductBrandId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            Name = "Angular Speedster Board 2000",
                            PictureUrl = "images/products/sb-ang1.png",
                            Price = 200m,
                            ProductBrandId = 1,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                            Name = "Green Angular Board 3000",
                            PictureUrl = "images/products/sb-ang2.png",
                            Price = 150m,
                            ProductBrandId = 1,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            Name = "Core Board Speed Rush 3",
                            PictureUrl = "images/products/sb-core1.png",
                            Price = 180m,
                            ProductBrandId = 2,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                            Name = "Net Core Super Board",
                            PictureUrl = "images/products/sb-core2.png",
                            Price = 300m,
                            ProductBrandId = 2,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            Name = "React Board Super Whizzy Fast",
                            PictureUrl = "images/products/sb-react1.png",
                            Price = 250m,
                            ProductBrandId = 4,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                            Name = "Typescript Entry Board",
                            PictureUrl = "images/products/sb-ts1.png",
                            Price = 120m,
                            ProductBrandId = 5,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 7,
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            Name = "Core Blue Hat",
                            PictureUrl = "images/products/hat-core1.png",
                            Price = 10m,
                            ProductBrandId = 2,
                            ProductTypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                            Name = "Green React Woolen Hat",
                            PictureUrl = "images/products/hat-react1.png",
                            Price = 8m,
                            ProductBrandId = 4,
                            ProductTypeId = 2
                        },
                        new
                        {
                            Id = 9,
                            Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                            Name = "Purple React Woolen Hat",
                            PictureUrl = "images/products/hat-react2.png",
                            Price = 15m,
                            ProductBrandId = 4,
                            ProductTypeId = 2
                        },
                        new
                        {
                            Id = 10,
                            Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                            Name = "Green Code Gloves",
                            PictureUrl = "images/products/glove-code2.png",
                            Price = 15m,
                            ProductBrandId = 3,
                            ProductTypeId = 4
                        },
                        new
                        {
                            Id = 11,
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                            Name = "Purple React Gloves",
                            PictureUrl = "images/products/glove-react1.png",
                            Price = 16m,
                            ProductBrandId = 4,
                            ProductTypeId = 4
                        });
                });

            modelBuilder.Entity("Hospital.DAL.Entities.ProductBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductBrands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Angular"
                        },
                        new
                        {
                            Id = 2,
                            Name = "NetCore"
                        },
                        new
                        {
                            Id = 3,
                            Name = "VS Code"
                        },
                        new
                        {
                            Id = 4,
                            Name = "React"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Typescript"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Redis"
                        });
                });

            modelBuilder.Entity("Hospital.DAL.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Boards"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Hats"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Boots"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Gloves"
                        });
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Appointment", b =>
                {
                    b.HasOne("Hospital.DAL.Entities.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Comment", b =>
                {
                    b.HasOne("Hospital.DAL.Entities.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Doctor", b =>
                {
                    b.HasOne("Hospital.DAL.Entities.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Product", b =>
                {
                    b.HasOne("Hospital.DAL.Entities.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.DAL.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductBrand");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.User", b =>
                {
                    b.HasOne("Hospital.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Blog", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Department", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Hospital.DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
