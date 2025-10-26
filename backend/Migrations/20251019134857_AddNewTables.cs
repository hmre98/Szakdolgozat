using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDuration_Services_ServiceId",
                table: "ServiceDuration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceDuration",
                table: "ServiceDuration");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ServicesProvided");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PriceActual",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "ServiceDuration",
                newName: "ServiceDurations");

            migrationBuilder.RenameColumn(
                name: "DurationMinutes",
                table: "Services",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDuration_ServiceId",
                table: "ServiceDurations",
                newName: "IX_ServiceDurations_ServiceId");

            migrationBuilder.AddColumn<int>(
                name: "ChosenMaterialId",
                table: "ServicesBooked",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Services",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscountValidUntil",
                table: "Services",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Services",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Services",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MaterialCost",
                table: "Services",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceDurations",
                table: "ServiceDurations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    InInventory = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    MaterialId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceMaterials_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesBooked_ChosenMaterialId",
                table: "ServicesBooked",
                column: "ChosenMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceMaterials_MaterialId",
                table: "ServiceMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceMaterials_ServiceId",
                table: "ServiceMaterials",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDurations_Services_ServiceId",
                table: "ServiceDurations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceCategories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesBooked_Materials_ChosenMaterialId",
                table: "ServicesBooked",
                column: "ChosenMaterialId",
                principalTable: "Materials",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDurations_Services_ServiceId",
                table: "ServiceDurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceCategories_CategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesBooked_Materials_ChosenMaterialId",
                table: "ServicesBooked");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "ServiceMaterials");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_ServicesBooked_ChosenMaterialId",
                table: "ServicesBooked");

            migrationBuilder.DropIndex(
                name: "IX_Services_CategoryId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceDurations",
                table: "ServiceDurations");

            migrationBuilder.DropColumn(
                name: "ChosenMaterialId",
                table: "ServicesBooked");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DiscountValidUntil",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MaterialCost",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "ServiceDurations",
                newName: "ServiceDuration");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Services",
                newName: "DurationMinutes");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDurations_ServiceId",
                table: "ServiceDuration",
                newName: "IX_ServiceDuration_ServiceId");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ServicesProvided",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceActual",
                table: "Appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceDuration",
                table: "ServiceDuration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDuration_Services_ServiceId",
                table: "ServiceDuration",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
