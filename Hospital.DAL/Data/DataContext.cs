using Hospital.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        
        
        
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductBrand>().HasData(
                new ProductBrand{Id = 1, Name = "Angular"},
                new ProductBrand{Id = 2, Name = "NetCore"},
                new ProductBrand{Id = 3, Name = "VS Code"},
                new ProductBrand{Id = 4, Name = "React"},
                new ProductBrand{Id = 5, Name = "Typescript"},
                new ProductBrand{Id = 6, Name = "Redis"}
            );
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType{ Id = 1, Name = "Boards"},
                new ProductType{ Id = 2, Name = "Hats"},
                new ProductType{ Id = 3, Name = "Boots"},
                new ProductType{ Id = 4, Name = "Gloves"}
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Syringia",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 200,
                    PictureUrl = "images/products/sb-ang1.png",
                    ProductBrandId = 1,
                    ProductTypeId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Box Aid",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 150,
                    PictureUrl = "images/products/sb-ang2.png",
                    ProductBrandId = 1,
                    ProductTypeId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Doctor Tablet",
                    Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 180,
                    PictureUrl = "images/products/sb-core1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Natural tablets",
                    Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 300,
                    PictureUrl = "images/products/sb-core2.png",
                    ProductTypeId = 1,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "Green tea",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 250,
                    PictureUrl = "images/products/sb-react1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 6,
                    Name = "Pampers",
                    Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                    Price = 120,
                    PictureUrl = "images/products/sb-ts1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 5
                },
                new Product
                {
                    Id = 7,
                    Name = "Core Blue Hat",
                    Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 10,
                    PictureUrl = "images/products/hat-core1.png",
                    ProductTypeId = 2,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "Green React Woolen Hat",
                    Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 8,
                    PictureUrl = "images/products/hat-react1.png",
                    ProductTypeId = 2,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 9,
                    Name = "Purple React Woolen Hat",
                    Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 15,
                    PictureUrl = "images/products/hat-react2.png",
                    ProductTypeId = 2,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 10,
                    Name = "Green Code Gloves",
                    Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 15,
                    PictureUrl = "images/products/glove-code2.png",
                    ProductTypeId = 4,
                    ProductBrandId = 3
                },
                new Product
                {
                    Id = 11,
                    Name = "Purple React Gloves",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                    Price = 16,
                    PictureUrl = "images/products/glove-react1.png",
                    ProductTypeId = 4,
                    ProductBrandId = 4
                }

            );
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Doctor>().HasData(
        //         new Doctor() {Name = "lorem", Profession = "lorem",Facebook = "lorem@",Description = "ghhjj",DepartmentId = 4}
        //     );
        // }
        
        
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Department>().HasData(
        //         new Department
        //         {
        //             Id = 1,
        //             Name = "Laboratory Test Department",
        //             Description = "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar"
        //
        //         },
        //         new Department
        //         {
        //             Id = 2,
        //             Name = "Dental Treat Department",
        //             Description = "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir"
        //         },
        //         new Department
        //         {
        //             Id = 3,
        //             Name = "Neurology Department",
        //             Description = "Xankəndi — Azərbaycan Respublikasındakı şəhər, 1991-ci il dekabrın 26-da Ermənistan silahlı qüvvələri və Qarabağdakı erməni separatçıları tərəfindən işğalından sonra yaradılan qondarma quruma paytaxtlıq edir.[2] İnzibati cəhətdən Xankəndi şəhər əhatə dairəsinə Xankəndi şəhəri və Kərkicahan şəhər tipli qəsəbəsi daxildir. "
        //         },
        //         new Department
        //         {
        //             Id = 4,
        //             Name = "Orthopedic Department",
        //             Description = "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar"
        //
        //         },
        //         new Department
        //         {
        //             Id = 5,
        //             Name = "Cardiology Department",
        //             Description = "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir"
        //
        //         },
        //         new Department
        //         {
        //             Id = 6,
        //             Name = "Gynecology Department",
        //             Description = "Xankəndi — Azərbaycan Respublikasındakı şəhər, 1991-ci il dekabrın 26-da Ermənistan silahlı qüvvələri və Qarabağdakı erməni separatçıları tərəfindən işğalından sonra yaradılan qondarma quruma paytaxtlıq edir.[2] İnzibati cəhətdən Xankəndi şəhər əhatə dairəsinə Xankəndi şəhəri və Kərkicahan şəhər tipli qəsəbəsi daxildir. "
        //
        //         },
        //         new Department
        //         {
        //             Id = 7,
        //             Name = "Pulmonology Department",
        //             Description = "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar"
        //
        //         },
        //         new Department
        //         {
        //             Id = 8,
        //             Name = "Eye Treat Department",
        //             Description = "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir"
        //
        //         }
        //     );
        //}
    }
}