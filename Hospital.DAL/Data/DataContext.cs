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
        public DbSet<Product> Products { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

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