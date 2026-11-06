using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeyondTheBarcode.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMachineMasterIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PlantName",
                table: "MachineMasters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MachineType",
                table: "MachineMasters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MachineCode",
                table: "MachineMasters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentStatus",
                table: "MachineMasters",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMasters_CurrentStatus",
                table: "MachineMasters",
                column: "CurrentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMasters_IsActive",
                table: "MachineMasters",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMasters_MachineCode",
                table: "MachineMasters",
                column: "MachineCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineMasters_MachineType",
                table: "MachineMasters",
                column: "MachineType");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMasters_NextMaintenanceDate",
                table: "MachineMasters",
                column: "NextMaintenanceDate");

            migrationBuilder.CreateIndex(
                name: "IX_MachineMasters_PlantName",
                table: "MachineMasters",
                column: "PlantName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MachineMasters_CurrentStatus",
                table: "MachineMasters");

            migrationBuilder.DropIndex(
                name: "IX_MachineMasters_IsActive",
                table: "MachineMasters");

            migrationBuilder.DropIndex(
                name: "IX_MachineMasters_MachineCode",
                table: "MachineMasters");

            migrationBuilder.DropIndex(
                name: "IX_MachineMasters_MachineType",
                table: "MachineMasters");

            migrationBuilder.DropIndex(
                name: "IX_MachineMasters_NextMaintenanceDate",
                table: "MachineMasters");

            migrationBuilder.DropIndex(
                name: "IX_MachineMasters_PlantName",
                table: "MachineMasters");

            migrationBuilder.AlterColumn<string>(
                name: "PlantName",
                table: "MachineMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MachineType",
                table: "MachineMasters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MachineCode",
                table: "MachineMasters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentStatus",
                table: "MachineMasters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
