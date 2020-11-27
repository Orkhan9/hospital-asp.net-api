using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.DAL.Migrations
{
    public partial class AddTablesCeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishTime",
                value: new DateTime(2020, 11, 26, 18, 51, 57, 322, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishTime",
                value: new DateTime(2020, 11, 26, 18, 51, 57, 322, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishTime",
                value: new DateTime(2020, 11, 26, 18, 51, 57, 322, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "DepartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "DepartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "DepartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "DepartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DepartmentId", "Description", "Facebook", "Name", "PhotoUrl", "Profession" },
                values: new object[,]
                {
                    { 15, 8, "Xocali Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Ulvi Majidov", "01_doctors.jpg", "Pulmonology" },
                    { 14, 7, "Fizuli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Kamil Mammadov", "03_doctors.jpg", "Gynecology" },
                    { 13, 7, "Zengilan Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Hasan Hasanli", "02_doctors.jpg", "Cardiology" },
                    { 12, 6, "Qubadli Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Zahid Gasimli", "01_doctors.jpg", "Orthopedics" },
                    { 11, 6, "Agdam Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Hasan Hasanbayli", "03_doctors.jpg", "Neurology" },
                    { 10, 5, "Xankendi Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Misir Esgerov", "02_doctors.jpg", "Dental" },
                    { 16, 8, "Kelbecer Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr.  Orkhan Mammadli", "02_doctors.jpg", "Eye Treat" },
                    { 9, 5, "Susa Dovlet Tibb Universiteti mezunudur.Hal-hazirda orda professor vezifesinde calisir.", "www.facebook.com", "Dr. Javid Dadashov", "01_doctors.jpg", "Lab Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishTime",
                value: new DateTime(2020, 11, 26, 18, 43, 5, 79, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishTime",
                value: new DateTime(2020, 11, 26, 18, 43, 5, 79, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishTime",
                value: new DateTime(2020, 11, 26, 18, 43, 5, 79, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "DepartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                column: "DepartmentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                column: "DepartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                column: "DepartmentId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8,
                column: "DepartmentId",
                value: 8);
        }
    }
}
