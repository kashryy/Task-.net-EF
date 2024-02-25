using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp9.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaskModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "NewTask");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "NewTask",
                newName: "Deadline");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "NewTask",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewTask",
                table: "NewTask",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewTask",
                table: "NewTask");

            migrationBuilder.RenameTable(
                name: "NewTask",
                newName: "Customers");

            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "Customers",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");
        }
    }
}
