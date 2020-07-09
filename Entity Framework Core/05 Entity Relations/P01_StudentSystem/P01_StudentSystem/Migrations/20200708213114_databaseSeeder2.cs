using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class databaseSeeder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 7, 8, 21, 31, 14, 39, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "EndDate", "Name", "Price", "StartDate" },
                values: new object[] { 3, "Java Web Module", new DateTime(2020, 7, 8, 21, 31, 14, 39, DateTimeKind.Utc).AddTicks(8419), "Java Web", 500m, new DateTime(2020, 5, 19, 21, 31, 14, 39, DateTimeKind.Utc).AddTicks(8424) });

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1,
                column: "SubmissionTime",
                value: new DateTime(2020, 7, 8, 21, 31, 14, 39, DateTimeKind.Utc).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2,
                column: "SubmissionTime",
                value: new DateTime(2020, 7, 8, 21, 31, 14, 39, DateTimeKind.Utc).AddTicks(1284));

            migrationBuilder.InsertData(
                table: "HomeworkSubmissions",
                columns: new[] { "HomeworkId", "Content", "ContentType", "CourseId", "StudentId", "SubmissionTime" },
                values: new object[] { 3, "Some content here 3", 3, 2, 2, new DateTime(2020, 7, 8, 21, 31, 14, 39, DateTimeKind.Utc).AddTicks(1294) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2020, 7, 8, 21, 31, 14, 38, DateTimeKind.Utc).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "RegisteredOn",
                value: new DateTime(2020, 7, 8, 21, 31, 14, 38, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Birthday", "Name", "PhoneNumber", "RegisteredOn" },
                values: new object[] { 3, new DateTime(2019, 12, 21, 21, 31, 14, 38, DateTimeKind.Utc).AddTicks(1883), "Kiril", "0884034667", new DateTime(2020, 3, 30, 21, 31, 14, 38, DateTimeKind.Utc).AddTicks(1935) });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "ResourceId", "CourseId", "Name", "ResourceType", "Url" },
                values: new object[] { 3, 2, "Tech world and future technologies", 4, "techworldfuturetechnologies.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "ResourceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2020, 7, 8, 21, 25, 14, 299, DateTimeKind.Utc).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 1,
                column: "SubmissionTime",
                value: new DateTime(2020, 7, 8, 21, 25, 14, 298, DateTimeKind.Utc).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "HomeworkSubmissions",
                keyColumn: "HomeworkId",
                keyValue: 2,
                column: "SubmissionTime",
                value: new DateTime(2020, 7, 8, 21, 25, 14, 298, DateTimeKind.Utc).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "RegisteredOn",
                value: new DateTime(2020, 7, 8, 21, 25, 14, 297, DateTimeKind.Utc).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "RegisteredOn",
                value: new DateTime(2020, 7, 8, 21, 25, 14, 297, DateTimeKind.Utc).AddTicks(9361));
        }
    }
}
