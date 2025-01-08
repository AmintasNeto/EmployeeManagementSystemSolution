using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerLibrary.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "CivilId",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "FileNumber",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "CivilId",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "FileNumber",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "CivilId",
                table: "Overtimes");

            migrationBuilder.DropColumn(
                name: "FileNumber",
                table: "Overtimes");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Overtimes");

            migrationBuilder.DropColumn(
                name: "CivilId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "FileNumber",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Other",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Pubishment",
                table: "Sanctions",
                newName: "Punishment");

            migrationBuilder.RenameColumn(
                name: "MedicalRecomendation",
                table: "Doctors",
                newName: "MedicalRecommendation");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Vacations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SanctionTypeId",
                table: "Sanctions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Sanctions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Overtimes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions",
                column: "SanctionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Sanctions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Overtimes");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Punishment",
                table: "Sanctions",
                newName: "Pubishment");

            migrationBuilder.RenameColumn(
                name: "MedicalRecommendation",
                table: "Doctors",
                newName: "MedicalRecomendation");

            migrationBuilder.AddColumn<string>(
                name: "CivilId",
                table: "Vacations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileNumber",
                table: "Vacations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Vacations",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SanctionTypeId",
                table: "Sanctions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CivilId",
                table: "Sanctions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileNumber",
                table: "Sanctions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Sanctions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CivilId",
                table: "Overtimes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileNumber",
                table: "Overtimes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Overtimes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CivilId",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileNumber",
                table: "Doctors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Other",
                table: "Doctors",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sanctions_SanctionTypes_SanctionTypeId",
                table: "Sanctions",
                column: "SanctionTypeId",
                principalTable: "SanctionTypes",
                principalColumn: "Id");
        }
    }
}
