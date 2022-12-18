using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskDistribution.Migrations
{
    /// <inheritdoc />
    public partial class userRoleIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleID",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleID",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Task_NM",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleID",
                table: "Users",
                column: "UserRoleID",
                principalTable: "UserRoles",
                principalColumn: "UserRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRoleID",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Task_NM",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRoleID",
                table: "Users",
                column: "UserRoleID",
                principalTable: "UserRoles",
                principalColumn: "UserRoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
