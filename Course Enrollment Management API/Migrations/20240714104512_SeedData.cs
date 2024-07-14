using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Enrollment_Management_APi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"), 3, "Fundamental concepts of programming", "Introduction to Computer Science" },
                    { new Guid("85146c4f-7280-486e-89a1-05b7d325ef68"), 4, "Principles of database design and management", "Database Management" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085"), "john.doe@example.com", "John", "Doe" },
                    { new Guid("ef55f7eb-56cf-48f9-a37b-fab724f21061"), "jane.smith@example.com", "Jane", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "EnrollmentDate" },
                values: new object[] { new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"), new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085"), new DateTime(2024, 7, 14, 14, 45, 12, 461, DateTimeKind.Local).AddTicks(8977) });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "EnrollmentDate" },
                values: new object[] { new Guid("85146c4f-7280-486e-89a1-05b7d325ef68"), new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085"), new DateTime(2024, 7, 14, 14, 45, 12, 461, DateTimeKind.Local).AddTicks(8987) });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId", "EnrollmentDate" },
                values: new object[] { new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"), new Guid("ef55f7eb-56cf-48f9-a37b-fab724f21061"), new DateTime(2024, 7, 14, 14, 45, 12, 461, DateTimeKind.Local).AddTicks(8990) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"), new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("85146c4f-7280-486e-89a1-05b7d325ef68"), new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085") });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"), new Guid("ef55f7eb-56cf-48f9-a37b-fab724f21061") });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("72ecafc1-2f35-475c-893c-1ec5c732fecf"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("85146c4f-7280-486e-89a1-05b7d325ef68"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("aaa7b0b7-c327-47f8-a440-c1a35440e085"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ef55f7eb-56cf-48f9-a37b-fab724f21061"));
        }
    }
}
