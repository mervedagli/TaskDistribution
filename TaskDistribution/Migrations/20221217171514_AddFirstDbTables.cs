using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskDistribution.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstDbTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskDifficultTypes",
                columns: table => new
                {
                    TaskDifficultTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskDifficultTypeNM = table.Column<string>(name: "TaskDifficultType_NM", type: "nvarchar(max)", nullable: true),
                    TaskDifficultTypeNO = table.Column<int>(name: "TaskDifficultType_NO", type: "int", nullable: false),
                    IsDeletedFL = table.Column<bool>(name: "IsDeleted_FL", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDifficultTypes", x => x.TaskDifficultTypeID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleNM = table.Column<string>(name: "UserRole_NM", type: "nvarchar(max)", nullable: true),
                    IsDeletedFL = table.Column<bool>(name: "IsDeleted_FL", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNM = table.Column<string>(name: "User_NM", type: "nvarchar(max)", nullable: true),
                    PasswordTXT = table.Column<string>(name: "Password_TXT", type: "nvarchar(max)", nullable: true),
                    UserRoleID = table.Column<int>(type: "int", nullable: false),
                    IsDeletedFL = table.Column<bool>(name: "IsDeleted_FL", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskNM = table.Column<string>(name: "Task_NM", type: "nvarchar(max)", nullable: true),
                    TaskDSC = table.Column<string>(name: "Task_DSC", type: "nvarchar(max)", nullable: true),
                    TaskDifficultTypeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    IsDeletedFL = table.Column<bool>(name: "IsDeleted_FL", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskDifficultTypes_TaskDifficultTypeID",
                        column: x => x.TaskDifficultTypeID,
                        principalTable: "TaskDifficultTypes",
                        principalColumn: "TaskDifficultTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskDifficultTypeID",
                table: "Tasks",
                column: "TaskDifficultTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserID",
                table: "Tasks",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleID",
                table: "Users",
                column: "UserRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskDifficultTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
