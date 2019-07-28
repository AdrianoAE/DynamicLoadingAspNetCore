using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPay.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EasyPay");

            migrationBuilder.CreateTable(
                name: "BoletoBancarioPayments",
                schema: "EasyPay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoletoBancarioPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebitoDiretoPayments",
                schema: "EasyPay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitoDiretoPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MBWayPayments",
                schema: "EasyPay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBWayPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MultibancoPayments",
                schema: "EasyPay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: false),
                    Entity = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultibancoPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisaMastercardPayments",
                schema: "EasyPay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaMastercardPayments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoletoBancarioPayments",
                schema: "EasyPay");

            migrationBuilder.DropTable(
                name: "DebitoDiretoPayments",
                schema: "EasyPay");

            migrationBuilder.DropTable(
                name: "MBWayPayments",
                schema: "EasyPay");

            migrationBuilder.DropTable(
                name: "MultibancoPayments",
                schema: "EasyPay");

            migrationBuilder.DropTable(
                name: "VisaMastercardPayments",
                schema: "EasyPay");
        }
    }
}
