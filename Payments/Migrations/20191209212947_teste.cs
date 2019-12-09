using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Migrations
{
    public partial class teste : Migration
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProvidersTranslations",
                schema: "Payments",
                columns: table => new
                {
                    ProvidersId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersTranslations", x => new { x.ProvidersId, x.LanguageId });
                });

            migrationBuilder.CreateTable(
                name: "ProvidersConfiguration",
                schema: "Payments",
                columns: table => new
                {
                    ProviderId = table.Column<int>(nullable: false),
                    PropertyName = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "ProvidersTranslations",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "Providers",
                schema: "Payments");
        }
    }
}
