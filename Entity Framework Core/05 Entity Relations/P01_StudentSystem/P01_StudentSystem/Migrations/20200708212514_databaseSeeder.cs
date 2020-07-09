using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class databaseSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "EndDate", "Name", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2010, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algorithms", 250.40m, new DateTime(2020, 7, 8, 21, 25, 14, 299, DateTimeKind.Utc).AddTicks(3024) },
                    { 2, null, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algorithms", 200m, new DateTime(2009, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Birthday", "Name", "PhoneNumber", "RegisteredOn" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1968), "Pesho", "0888565656", new DateTime(2020, 7, 8, 21, 25, 14, 297, DateTimeKind.Utc).AddTicks(7886) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1956), "Dimitar", "0888565656", new DateTime(2020, 7, 8, 21, 25, 14, 297, DateTimeKind.Utc).AddTicks(9361) }
                });

            migrationBuilder.InsertData(
                table: "HomeworkSubmissions",
                columns: new[] { "HomeworkId", "Content", "ContentType", "CourseId", "StudentId", "SubmissionTime" },
                values: new object[,]
                {
                    { 1, "Some content here", 1, 1, 1, new DateTime(2020, 7, 8, 21, 25, 14, 298, DateTimeKind.Utc).AddTicks(7712) },
                    { 2, "Some content here 2", 2, 2, 1, new DateTime(2020, 7, 8, 21, 25, 14, 298, DateTimeKind.Utc).AddTicks(8243) }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "CourseId", "Name", "ResourceType", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Youtube", 1, null },
                    { 2, 2, "Wikipedia", 3, null }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentCourses",
                keyColumns: new[] { "StudentId", "CourseId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);
        }
    }
}
