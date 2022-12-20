using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskDistribution.Migrations
{
    /// <inheritdoc />
    public partial class conf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaskDifficultTypes",
                columns: new[] { "TaskDifficultTypeID", "IsDeleted_FL", "TaskDifficultType_NM", "TaskDifficultType_NO" },
                values: new object[,]
                {
                    { 1, false, "Kolay", 1 },
                    { 2, false, "Orta", 2 },
                    { 3, false, "Zor", 3 }
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "TaskTypeID", "IsDeleted_FL", "TaskType_NM", "TaskType_NO" },
                values: new object[,]
                {
                    { 1, false, "BugFix", 1 },
                    { 2, false, "Test", 2 },
                    { 3, false, "Geliştirme", 3 },
                    { 4, false, "Veritabanı İşlemleri", 4 },
                    { 5, false, "Frontend Geliştirme", 5 },
                    { 6, false, "Refactor", 6 },
                    { 7, false, "Güvenlik taraması", 7 },
                    { 8, false, "Analiz", 8 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleID", "IsDeleted_FL", "UserRole_NM" },
                values: new object[,]
                {
                    { 1, false, "Software Analyst" },
                    { 2, false, "User" },
                    { 3, false, "Software Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsDeleted_FL", "Password_TXT", "UserRoleID", "User_NM" },
                values: new object[,]
                {
                    { 1, false, "1234", 1, "Cansu" },
                    { 2, false, "1234", 2, "Merve" },
                    { 3, false, "1234", 3, "Yasemin" },
                    { 4, false, "1234", 2, "Betül" },
                    { 5, false, "1234", 2, "Murat" },
                    { 6, false, "1234", 2, "Zeynep" },
                    { 7, false, "1234", 2, "Dilan" },
                    { 8, false, "1234", 2, "Aysu" },
                    { 9, false, "1234", 2, "Melisa" },
                    { 10, false, "1234", 2, "Hilal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskDifficultTypes",
                keyColumn: "TaskDifficultTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskDifficultTypes",
                keyColumn: "TaskDifficultTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskDifficultTypes",
                keyColumn: "TaskDifficultTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleID",
                keyValue: 3);
        }
    }
}
