using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Payments");

            migrationBuilder.CreateTable(
                name: "Providers",
                schema: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProvidersConfiguration",
                schema: "Payments",
                columns: table => new
                {
                    ProviderId = table.Column<int>(nullable: false),
                    PropertyName = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersConfiguration", x => new { x.ProviderId, x.PropertyName });
                    table.ForeignKey(
                        name: "FK_ProvidersConfiguration_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "Payments",
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidersConfiguration",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "Providers",
                schema: "Payments");
        }
    }
}
