using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Newbuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesBooked_AspNetUsers_ApplicationUserId",
                table: "ServicesBooked");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesBooked_Materials_ChosenMaterialId",
                table: "ServicesBooked");

            migrationBuilder.DropIndex(
                name: "IX_ServicesBooked_ApplicationUserId",
                table: "ServicesBooked");

            migrationBuilder.DropIndex(
                name: "IX_ServicesBooked_ChosenMaterialId",
                table: "ServicesBooked");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ServicesBooked");

            migrationBuilder.DropColumn(
                name: "ChosenMaterialId",
                table: "ServicesBooked");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ServicesProvided",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DurationId1",
                table: "ServicesBooked",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelectable",
                table: "Materials",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ServiceBookedMaterialId",
                table: "Materials",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Appointments",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceBookedMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceBookedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBookedMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceBookedMaterial_ServicesBooked_ServiceBookedId",
                        column: x => x.ServiceBookedId,
                        principalTable: "ServicesBooked",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesBooked_DurationId1",
                table: "ServicesBooked",
                column: "DurationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ServiceBookedMaterialId",
                table: "Materials",
                column: "ServiceBookedMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBookedMaterial_ServiceBookedId",
                table: "ServiceBookedMaterial",
                column: "ServiceBookedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_ServiceBookedMaterial_ServiceBookedMaterialId",
                table: "Materials",
                column: "ServiceBookedMaterialId",
                principalTable: "ServiceBookedMaterial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesBooked_ServiceDurations_DurationId1",
                table: "ServicesBooked",
                column: "DurationId1",
                principalTable: "ServiceDurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_ServiceBookedMaterial_ServiceBookedMaterialId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesBooked_ServiceDurations_DurationId1",
                table: "ServicesBooked");

            migrationBuilder.DropTable(
                name: "ServiceBookedMaterial");

            migrationBuilder.DropIndex(
                name: "IX_ServicesBooked_DurationId1",
                table: "ServicesBooked");

            migrationBuilder.DropIndex(
                name: "IX_Materials_ServiceBookedMaterialId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServicesProvided");

            migrationBuilder.DropColumn(
                name: "DurationId1",
                table: "ServicesBooked");

            migrationBuilder.DropColumn(
                name: "IsSelectable",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ServiceBookedMaterialId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ServicesBooked",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChosenMaterialId",
                table: "ServicesBooked",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicesBooked_ApplicationUserId",
                table: "ServicesBooked",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesBooked_ChosenMaterialId",
                table: "ServicesBooked",
                column: "ChosenMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesBooked_AspNetUsers_ApplicationUserId",
                table: "ServicesBooked",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesBooked_Materials_ChosenMaterialId",
                table: "ServicesBooked",
                column: "ChosenMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");
        }
    }
}
