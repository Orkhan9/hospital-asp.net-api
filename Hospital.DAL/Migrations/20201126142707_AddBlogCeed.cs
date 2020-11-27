using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.DAL.Migrations
{
    public partial class AddBlogCeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Description", "PhotoUrl", "PublishTime", "Title", "Topic" },
                values: new object[] { 1, "Susa Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum....... ", "01_blog.jpg", new DateTime(2020, 11, 26, 18, 27, 6, 676, DateTimeKind.Local).AddTicks(5192), "Medical & Dental Support ICU & CCU for Emergancy Services", "COVID -19 , Tips" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Description", "PhotoUrl", "PublishTime", "Title", "Topic" },
                values: new object[] { 2, "Xankendi Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.......", "02_blog.jpg", new DateTime(2020, 11, 26, 18, 27, 6, 676, DateTimeKind.Local).AddTicks(5418), "Patien Forum School patient Experience", "Treatment , Tips" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Description", "PhotoUrl", "PublishTime", "Title", "Topic" },
                values: new object[] { 3, "Xocali Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.......", "03_blog.jpg", new DateTime(2020, 11, 26, 18, 27, 6, 676, DateTimeKind.Local).AddTicks(5425), "How to protect myself & the spread of disease!", "Medical , Tips" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
