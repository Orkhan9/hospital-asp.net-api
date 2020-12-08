using System;
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
        public DbSet<ReplyToComment> ReplyToComments { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        
        
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //bio
            modelBuilder.Entity<Bio>().HasData(
                new Bio
                {
                    Id = 1, Email = "javidfd@code.edu.az",Phone = "+994555535373",Facebook = "www.facebook.com",
                    Address = "Baku city,Sabail district",LogoUrl = "01_logo.png"
                }
            );
            
            //about
            modelBuilder.Entity<About>().HasData(
                new About
                {
                    Id = 1, Title = "Welcome To Our Susa-Hospital",PhotoUrl = "01_about.jpg",
                    Description = "Susa-Hospital are a professional medical & health care services " +
                                  "provider institutions. Suitable for Hospitals Dentists Gynecologists Physiatrists " +
                                  "Lorem Ipsum is simply dummy text of the printing and typesetting " +
                                  "industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
                }
            );
            
            //role
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1, Name = "admin"
                },
                new Role
                {
                    Id = 2, Name = "member"
                }
            );
            
            //blog
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1, Title = "Medical & Dental Support ICU & CCU for Emergency Services",
                    PhotoUrl = "01_blog.jpg",Topic = "COVID -19 , Tips",
                    PublishTime = DateTime.Now,
                    Description = "Susa Ipsum is simply dummy text of the printing " +
                                  "and typesetting industry. Lorem Ipsum has been the industry's " +
                                  "standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum....... "
                                 
                },new Blog
                {
                    Id = 2, Title = "Patien Forum School patient Experience",
                    PhotoUrl = "02_blog.jpg",Topic = "Treatment , Tips",
                    PublishTime = DateTime.Now,
                    Description = "Xankendi Ipsum is simply dummy text of the printing" +
                                  " and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum......."
                },new Blog
                    
                {
                    Id = 3, Title = "How to protect myself & the spread of disease!",
                    PhotoUrl = "03_blog.jpg",Topic = "Medical , Tips",
                    PublishTime = DateTime.Now,
                    Description = "Xocali Ipsum is simply dummy text of the printing and " +
                                  "typesetting industry. Lorem Ipsum has been the industry's standard " +
                                  "dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum......."
                }
            );
            
           //department
            modelBuilder.Entity<Department>().HasData(
                 new Department
                 {
                     Id = 1,
                     Name = "Laboratory Test Department",IconClass = "item-icon flaticon-microscope",
                     Description = "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində," +
                                   " Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli " +
                                   "1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar"
            
                 },
                 new Department
                 {
                     Id = 2,
                     Name = "Dental Treat Department",IconClass = "item-icon flaticon-atomic",
                     Description = "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi," +
                                   " Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust " +
                                   "tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir"
                 },
                 new Department
                 {
                     Id = 3,
                     Name = "Neurology Department",IconClass = "item-icon flaticon-joint",
                     Description = "Xankəndi — Azərbaycan Respublikasındakı şəhər, 1991-ci il " +
                                   "dekabrın 26-da Ermənistan silahlı qüvvələri və Qarabağdakı " +
                                   "erməni separatçıları tərəfindən işğalından sonra yaradılan qondarma " +
                                   "quruma paytaxtlıq edir.[2] İnzibati cəhətdən Xankəndi şəhər əhatə dairəsinə Xankəndi şəhəri və Kərkicahan şəhər tipli qəsəbəsi daxildir. "
                 },
                 new Department
                 {
                     Id = 4,
                     Name = "Orthopedic Department",IconClass = "item-icon flaticon-microscope",
                     Description = "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində," +
                                   " Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli " +
                                   "1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar"
            
                 },
                 new Department
                 {
                     Id = 5,
                     Name = "Cardiology Department",IconClass = "item-icon flaticon-cardiogram-2",
                     Description = "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati " +
                                   "mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü" +
                                   " ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir"
            
                 },
                 new Department
                 {
                     Id = 6,
                     Name = "Gynecology Department",IconClass = "item-icon flaticon-pill",
                     Description = "Xankəndi — Azərbaycan Respublikasındakı şəhər, 1991-ci il dekabrın" +
                                   " 26-da Ermənistan silahlı qüvvələri və Qarabağdakı erməni separatçıları " +
                                   "tərəfindən işğalından sonra yaradılan qondarma quruma paytaxtlıq edir.[2] İnzibati cəhətdən Xankəndi şəhər əhatə dairəsinə Xankəndi şəhəri və Kərkicahan şəhər tipli qəsəbəsi daxildir. "
            
                 },
                 new Department
                 {
                     Id = 7,
                     Name = "Pulmonology Department",IconClass = "item-icon flaticon-lung",
                     Description = "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində," +
                                   " Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli " +
                                   "1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar"
            
                 },
                 new Department
                 {
                     Id = 8,
                     Name = "Eye Treat Department",IconClass = "item-icon flaticon-glasses",
                     Description = "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi," +
                                   " Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust " +
                                   "tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir"
            
                 }
             );
            
           //product
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
                    Price = 200m,
                    PictureUrl = "01_shop.jpg",
                    ProductBrandId = 1,
                    ProductTypeId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Box Aid",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 150m,
                    PictureUrl = "02_shop.jpg",
                    ProductBrandId = 1,
                    ProductTypeId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Doctor Tablet",
                    Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 180m,
                    PictureUrl = "03_shop.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Natural tablets",
                    Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 300m,
                    PictureUrl = "01_shop.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "Green tea",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 250m,
                    PictureUrl = "02_shop.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 6,
                    Name = "Pampers",
                    Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                    Price = 120m,
                    PictureUrl = "03_shop.jpg",
                    ProductTypeId = 1,
                    ProductBrandId = 5
                },
                new Product
                {
                    Id = 7,
                    Name = "Core Blue Hat",
                    Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 10m,
                    PictureUrl = "01_shop.jpg",
                    ProductTypeId = 2,
                    ProductBrandId = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "Green React Woolen Hat",
                    Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 8m,
                    PictureUrl = "02_shop.jpg",
                    ProductTypeId = 2,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 9,
                    Name = "Purple React Woolen Hat",
                    Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 15m,
                    PictureUrl = "03_shop.jpg",
                    ProductTypeId = 2,
                    ProductBrandId = 4
                },
                new Product
                {
                    Id = 10,
                    Name = "Green Code Gloves",
                    Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 15m,
                    PictureUrl = "01_shop.jpg",
                    ProductTypeId = 4,
                    ProductBrandId = 3
                },
                new Product
                {
                    Id = 11,
                    Name = "Purple React Gloves",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                    Price = 16m,
                    PictureUrl = "02_shop.jpg",
                    ProductTypeId = 4,
                    ProductBrandId = 4
                }

            );
            
            //doctor
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() {Id = 1,Name = "Dr. Javid Dadashov", Profession = "Lab Test",Facebook = "www.facebook.com",
                    Description = "Susa Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 1, PhotoUrl = "01_doctors.jpg"
                },
                new Doctor() {Id = 2,Name = "Dr. Jeyhun Huseynov", Profession = "Dental",Facebook = "www.facebook.com",
                    Description = "Xankendi Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 1, PhotoUrl = "02_doctors.jpg"
                },
                new Doctor() {Id = 3,Name = "Dr. Kamil Hasanov", Profession = "Neurology",Facebook = "www.facebook.com",
                    Description = "Agdam Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 2, PhotoUrl = "03_doctors.jpg"
                },
                new Doctor() {Id = 4,Name = "Dr.  Zahid Gasimli", Profession = "Orthopedics",Facebook = "www.facebook.com",
                    Description = "Qubadli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 2, PhotoUrl = "01_doctors.jpg"
                },
                new Doctor() {Id = 5,Name = "Dr.  Hasan Hasanli", Profession = "Cardiology",Facebook = "www.facebook.com",
                    Description = "Zengilan Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 3, PhotoUrl = "02_doctors.jpg"
                },
                new Doctor() {Id = 6,Name = "Dr. Kamil Mammadov", Profession = "Gynecology",Facebook = "www.facebook.com",
                    Description = "Fizuli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 3, PhotoUrl = "03_doctors.jpg"
                },
                new Doctor() {Id = 7,Name = "Dr. Ulvi Majidov", Profession = "Pulmonology",Facebook = "www.facebook.com",
                    Description = "Xocali Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 4, PhotoUrl = "01_doctors.jpg"
                },
                new Doctor() {Id = 8,Name = "Dr. Orkhan Mammadli", Profession = "Eye Treat",Facebook = "www.facebook.com",
                    Description = "Kelbecer Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 4, PhotoUrl = "02_doctors.jpg"
                },
                new Doctor() {Id = 9,Name = "Dr. Hasan Hasanbayli", Profession = "Lab Test",Facebook = "www.facebook.com",
                    Description = "Susa Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 5, PhotoUrl = "01_doctors.jpg"
                },
                new Doctor() {Id = 10,Name = "Dr. Misir Esgerov", Profession = "Dental",Facebook = "www.facebook.com",
                    Description = "Xankendi Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 5, PhotoUrl = "02_doctors.jpg"
                },
                new Doctor() {Id = 11,Name = "Dr. Akshin Musazade", Profession = "Neurology",Facebook = "www.facebook.com",
                    Description = "Agdam Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 6, PhotoUrl = "03_doctors.jpg"
                },
                new Doctor() {Id = 12,Name = "Dr. Khagani Abbasov", Profession = "Orthopedics",Facebook = "www.facebook.com",
                    Description = "Qubadli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 6, PhotoUrl = "01_doctors.jpg"
                },
                new Doctor() {Id = 13,Name = "Dr.  Abbas Muradzada", Profession = "Cardiology",Facebook = "www.facebook.com",
                    Description = "Zengilan Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 7, PhotoUrl = "02_doctors.jpg"
                },
                new Doctor() {Id = 14,Name = "Dr. Shukufa Abdullayeva", Profession = "Gynecology",Facebook = "www.facebook.com",
                    Description = "Fizuli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 7, PhotoUrl = "03_doctors.jpg"
                },
                new Doctor() {Id = 15,Name = "Dr. Narmin Aliyeva", Profession = "Pulmonology",Facebook = "www.facebook.com",
                    Description = "Xocali Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 8, PhotoUrl = "01_doctors.jpg"
                },
                new Doctor() {Id = 16,Name = "Dr.  Ulkar Hasanova", Profession = "Eye Treat",Facebook = "www.facebook.com",
                    Description = "Kelbecer Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.",
                    DepartmentId = 8, PhotoUrl = "02_doctors.jpg"
                }
            );
            
            //service
             modelBuilder.Entity<Service>().HasData(
                 new Service
                 {
                     Id = 1,
                     Name = "Qulified Doctors",
                     IconClass = "item-icon flaticon-doctor",
                     ShortDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                     Description = "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists."+
            
                     "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."+
            
                     "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages."+
            
                     "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur."
                 },
                 new Service
                 {
                     Id = 2,
                     Name = "24 Hours Services",
                     IconClass = "item-icon flaticon-emergency-call-1",
                     ShortDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                     Description = "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages."+
            
                                   "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur."
                 },
                 new Service
                 {
                     Id = 3,
                     Name = "Blood Test",
                     IconClass = "item-icon flaticon-blood-donation-1",
                     ShortDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                     Description = "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages."+
            
                                   "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur."
                 },
                 new Service
                 {
                     Id = 4,
                     Name = "24/7 Ambulance",
                     IconClass = "item-icon flaticon-ambulance-3",
                     ShortDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                     Description = "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages."+
            
                                   "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur."
                 },
                 new Service
                 {
                     Id = 5,
                     Name = "Medical Counselling",
                     IconClass = "item-icon flaticon-medical",
                     ShortDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                     Description = "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages."+
            
                                   "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur."
                 },
                 new Service
                 {
                     Id = 6,
                     Name = "Transplant Services",
                     IconClass = "item-icon flaticon-treatment",
                     ShortDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                     Description = "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages."+
            
                                   "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur."
                 },
                 new Service
                 {
                     Id = 7,
                     Name = "Rehabilitation",
                     IconClass = "item-icon flaticon-bed",
                     ShortDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                     Description = "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."+
            
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages."+
            
                                   "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur."
                 },
                 new Service
                 {
                     Id = 8,
                     Name = "Outdoor Checkup",
                     IconClass = "item-icon flaticon-list",
                     ShortDesc = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.",
                     Description = "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists."+
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."+
                                   "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages."+
                                   "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur."
                 }
             );
        }
    }
}