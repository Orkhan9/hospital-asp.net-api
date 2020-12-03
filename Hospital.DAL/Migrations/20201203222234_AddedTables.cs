using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.DAL.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconClass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplyToComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyToComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyToComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Description", "PhotoUrl", "Title" },
                values: new object[] { 1, "Susa-Hospital are a professional medical & health care services provider institutions. Suitable for Hospitals Dentists Gynecologists Physiatrists Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", "01_about.jpg", "Welcome To Our Susa-Hospital" });

            migrationBuilder.InsertData(
                table: "Bios",
                columns: new[] { "Id", "Address", "Email", "Facebook", "LogoUrl", "Phone" },
                values: new object[] { 1, "Baku city,Sabail district", "javidfd@code.edu.az", "www.facebook.com", "01_logo.png", "+994555535373" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Description", "PhotoUrl", "PublishTime", "Title", "Topic" },
                values: new object[,]
                {
                    { 1, "Susa Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum....... ", "01_blog.jpg", new DateTime(2020, 12, 4, 2, 22, 34, 311, DateTimeKind.Local).AddTicks(1303), "Medical & Dental Support ICU & CCU for Emergency Services", "COVID -19 , Tips" },
                    { 2, "Xankendi Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.......", "02_blog.jpg", new DateTime(2020, 12, 4, 2, 22, 34, 311, DateTimeKind.Local).AddTicks(8549), "Patien Forum School patient Experience", "Treatment , Tips" },
                    { 3, "Xocali Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.......", "03_blog.jpg", new DateTime(2020, 12, 4, 2, 22, 34, 311, DateTimeKind.Local).AddTicks(8583), "How to protect myself & the spread of disease!", "Medical , Tips" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IconClass", "Name" },
                values: new object[,]
                {
                    { 1, "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar", "item-icon flaticon-microscope", "Laboratory Test Department" },
                    { 2, "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir", "item-icon flaticon-atomic", "Dental Treat Department" },
                    { 3, "Xankəndi — Azərbaycan Respublikasındakı şəhər, 1991-ci il dekabrın 26-da Ermənistan silahlı qüvvələri və Qarabağdakı erməni separatçıları tərəfindən işğalından sonra yaradılan qondarma quruma paytaxtlıq edir.[2] İnzibati cəhətdən Xankəndi şəhər əhatə dairəsinə Xankəndi şəhəri və Kərkicahan şəhər tipli qəsəbəsi daxildir. ", "item-icon flaticon-joint", "Neurology Department" },
                    { 4, "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar", "item-icon flaticon-microscope", "Orthopedic Department" },
                    { 5, "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir", "item-icon flaticon-cardiogram-2", "Cardiology Department" },
                    { 6, "Xankəndi — Azərbaycan Respublikasındakı şəhər, 1991-ci il dekabrın 26-da Ermənistan silahlı qüvvələri və Qarabağdakı erməni separatçıları tərəfindən işğalından sonra yaradılan qondarma quruma paytaxtlıq edir.[2] İnzibati cəhətdən Xankəndi şəhər əhatə dairəsinə Xankəndi şəhəri və Kərkicahan şəhər tipli qəsəbəsi daxildir. ", "item-icon flaticon-pill", "Gynecology Department" },
                    { 7, "Şuşa — Azərbaycan Respublikasının Dağlıq Qarabağ bölgəsində, Şuşa şəhər inzibati ərazi dairəsində şəhər.[2]. Şəhərin təməli 1752-ci ildə Qarabağ hökmdarı Pənahəli xan tərəfindən qoyulub və ilk çağlarda şəhəri Şuşa adı ilə yanaşı xanın şərəfinə Pənahabad adlandırırdılar", "item-icon flaticon-lung", "Pulmonology Department" },
                    { 8, "Qubadlı şəhəri — Azərbaycanın Qubadlı rayonunun inzibati mərkəzi, Qubadlı şəhər inzibati ərazi dairəsində şəhər 1993-cü ilin 31 avqust tarixində Ermənistan Silahlı Qüvvələri tərəfindən işğal edilmişdir. 2020-ci il 25 oktyabr tarixində Azərbaycan Silahlı Qüvvələri tərəfindən işğaldan azad edilmişdir", "item-icon flaticon-glasses", "Eye Treat Department" }
                });

            migrationBuilder.InsertData(
                table: "ProductBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Redis" },
                    { 5, "Typescript" },
                    { 4, "React" },
                    { 2, "NetCore" },
                    { 1, "Angular" },
                    { 3, "VS Code" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Boards" },
                    { 2, "Hats" },
                    { 3, "Boots" },
                    { 4, "Gloves" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Member" },
                    { 1, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "IconClass", "Name", "ShortDesc" },
                values: new object[,]
                {
                    { 6, "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur.", "item-icon flaticon-treatment", "Transplant Services", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
                    { 5, "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur.", "item-icon flaticon-medical", "Medical Counselling", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
                    { 4, "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur.", "item-icon flaticon-ambulance-3", "24/7 Ambulance", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
                    { 7, "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur.", "item-icon flaticon-bed", "Rehabilitation", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
                    { 2, "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur.", "item-icon flaticon-emergency-call-1", "24 Hours Services", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
                    { 1, "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur.", "item-icon flaticon-doctor", "Qulified Doctors", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
                    { 3, "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur.", "item-icon flaticon-blood-donation-1", "Blood Test", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." },
                    { 8, "Al-Anwar Are A Professional Medical & Health Care Services Provider Institutions. Suitable For Hospitals, Dentists, Gynecologists, Physiatrists.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur.", "item-icon flaticon-list", "Outdoor Checkup", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s." }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DepartmentId", "Description", "Facebook", "Name", "PhotoUrl", "Profession" },
                values: new object[,]
                {
                    { 1, 1, "Susa Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Javid Dadashov", "01_doctors.jpg", "Lab Test" },
                    { 16, 8, "Kelbecer Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Ulkar Hasanova", "02_doctors.jpg", "Eye Treat" },
                    { 15, 8, "Xocali Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Narmin Aliyeva", "01_doctors.jpg", "Pulmonology" },
                    { 13, 7, "Zengilan Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Abbas Muradzada", "02_doctors.jpg", "Cardiology" },
                    { 12, 6, "Qubadli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Khagani Abbasov", "01_doctors.jpg", "Orthopedics" },
                    { 11, 6, "Agdam Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Akshin Musazade", "03_doctors.jpg", "Neurology" },
                    { 10, 5, "Xankendi Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Misir Esgerov", "02_doctors.jpg", "Dental" },
                    { 9, 5, "Susa Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Hasan Hasanbayli", "01_doctors.jpg", "Lab Test" },
                    { 14, 7, "Fizuli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Shukufa Abdullayeva", "03_doctors.jpg", "Gynecology" },
                    { 7, 4, "Xocali Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Ulvi Majidov", "01_doctors.jpg", "Pulmonology" },
                    { 6, 3, "Fizuli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Kamil Mammadov", "03_doctors.jpg", "Gynecology" },
                    { 5, 3, "Zengilan Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Hasan Hasanli", "02_doctors.jpg", "Cardiology" },
                    { 4, 2, "Qubadli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Zahid Gasimli", "01_doctors.jpg", "Orthopedics" },
                    { 3, 2, "Agdam Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Kamil Hasanov", "03_doctors.jpg", "Neurology" },
                    { 2, 1, "Xankendi Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Jeyhun Huseynov", "02_doctors.jpg", "Dental" },
                    { 8, 4, "Kelbecer Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Orkhan Mammadli", "02_doctors.jpg", "Eye Treat" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Price", "ProductBrandId", "ProductTypeId" },
                values: new object[,]
                {
                    { 9, "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Purple React Woolen Hat", "03_shop.jpg", 15m, 4, 2 },
                    { 8, "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Green React Woolen Hat", "02_shop.jpg", 8m, 4, 2 },
                    { 7, "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Core Blue Hat", "01_shop.jpg", 10m, 2, 2 },
                    { 6, "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.", "Pampers", "03_shop.jpg", 120m, 5, 1 },
                    { 2, "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "Box Aid", "02_shop.jpg", 150m, 1, 1 },
                    { 4, "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Natural tablets", "01_shop.jpg", 300m, 2, 1 },
                    { 3, "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "Doctor Tablet", "03_shop.jpg", 180m, 2, 1 },
                    { 1, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Syringia", "01_shop.jpg", 200m, 1, 1 },
                    { 10, "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.", "Green Code Gloves", "01_shop.jpg", 15m, 3, 4 },
                    { 5, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "Green tea", "02_shop.jpg", 250m, 4, 1 },
                    { 11, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.", "Purple React Gloves", "02_shop.jpg", 16m, 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyToComments_CommentId",
                table: "ReplyToComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Bios");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ReplyToComments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
