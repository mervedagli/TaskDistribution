using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskDistribution.Migrations
{
    /// <inheritdoc />
    public partial class addTakTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskTypeID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    TaskTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTypeNM = table.Column<string>(name: "TaskType_NM", type: "nvarchar(max)", nullable: true),
                    TaskTypeNO = table.Column<int>(name: "TaskType_NO", type: "int", nullable: false),
                    IsDeletedFL = table.Column<bool>(name: "IsDeleted_FL", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.TaskTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeID",
                table: "Tasks",
                column: "TaskTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeID",
                table: "Tasks",
                column: "TaskTypeID",
                principalTable: "TaskTypes",
                principalColumn: "TaskTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskTypeID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskTypeID",
                table: "Tasks");
        }
    }
}
