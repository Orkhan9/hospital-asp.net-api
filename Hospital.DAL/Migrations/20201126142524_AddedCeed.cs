using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.DAL.Migrations
{
    public partial class AddedCeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Description", "PhotoUrl", "Title" },
                values: new object[] { 1, "Susa-Hospital are a professional medical & health care services provider institutions. Suitable for Hospitals Dentists Gynecologists Physiatrists Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", "01_about.png", "Welcome To Our Susa-Hospital" });

            migrationBuilder.InsertData(
                table: "Bios",
                columns: new[] { "Id", "Address", "Email", "Facebook", "LogoUrl", "Phone" },
                values: new object[] { 1, "Baku city,Sabail district", "javidfd@code.edu.az", "www.facebook.com", "01_logo.png", "+994555535373" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar", "Laboratory Test Department" },
                    { 2, "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir", "Dental Treat Department" },
                    { 3, "Xankəndi — Azərbaycan Respublikasındakı şəhər, 1991-ci il dekabrın 26-da Ermənistan silahlı qüvvələri və Qarabağdakı erməni separatçıları tərəfindən işğalından sonra yaradılan qondarma quruma paytaxtlıq edir.[2] İnzibati cəhətdən Xankəndi şəhər əhatə dairəsinə Xankəndi şəhəri və Kərkicahan şəhər tipli qəsəbəsi daxildir. ", "Neurology Department" },
                    { 4, "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar", "Orthopedic Department" },
                    { 5, "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir", "Cardiology Department" },
                    { 6, "Xankəndi — Azərbaycan Respublikasındakı şəhər, 1991-ci il dekabrın 26-da Ermənistan silahlı qüvvələri və Qarabağdakı erməni separatçıları tərəfindən işğalından sonra yaradılan qondarma quruma paytaxtlıq edir.[2] İnzibati cəhətdən Xankəndi şəhər əhatə dairəsinə Xankəndi şəhəri və Kərkicahan şəhər tipli qəsəbəsi daxildir. ", "Gynecology Department" },
                    { 7, "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar", "Pulmonology Department" },
                    { 8, "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir", "Eye Treat Department" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Member" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DepartmentId", "Description", "Facebook", "Name", "PhotoUrl", "Profession" },
                values: new object[,]
                {
                    { 1, 1, "Susa Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Javid Dadashov", "01_doctors.jpg", "Lab Test" },
                    { 2, 2, "Xankendi Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Misir Esgerov", "02_doctors.jpg", "Dental" },
                    { 3, 3, "Agdam Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Hasan Hasanbayli", "03_doctors.jpg", "Neurology" },
                    { 4, 4, "Qubadli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Zahid Gasimli", "01_doctors.jpg", "Orthopedics" },
                    { 5, 5, "Zengilan Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Hasan Hasanli", "02_doctors.jpg", "Cardiology" },
                    { 6, 6, "Fizuli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Kamil Mammadov", "03_doctors.jpg", "Gynecology" },
                    { 7, 7, "Xocali Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Ulvi Majidov", "01_doctors.jpg", "Pulmonology" },
                    { 8, 8, "Kelbecer Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Orkhan Mammadli", "02_doctors.jpg", "Eye Treat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
