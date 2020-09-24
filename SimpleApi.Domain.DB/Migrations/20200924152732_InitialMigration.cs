using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SimpleApi.Domain.DB.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    FullDescription = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    SubscriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsItems_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("00000000-aaaa-0000-0000-000000000000"), "Free subscription", 0m },
                    { new Guid("00000000-bbbb-0000-0000-000000000000"), "Full subscription", 100m }
                });

            migrationBuilder.InsertData(
                table: "NewsItems",
                columns: new[] { "Id", "Author", "Created", "FullDescription", "ShortDescription", "SubscriptionId", "Title", "Updated", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "Greatest journalist ever", new DateTime(2020, 9, 24, 18, 27, 31, 560, DateTimeKind.Local).AddTicks(7542), "Old lady from village 'Milk farm' found a huge bomb instead of eggplant!", "Old lady from village 'Milk farm' found a huge bomb instead of eggplant!", new Guid("00000000-aaaa-0000-0000-000000000000"), "First news", new DateTime(2020, 9, 24, 18, 27, 31, 560, DateTimeKind.Local).AddTicks(7542), new Guid("c9a305fc-cd0a-4f98-b381-954dab0ba6f1") },
                    { 2L, "Only for money author", new DateTime(2020, 9, 24, 18, 27, 31, 560, DateTimeKind.Local).AddTicks(7542), "Great news!", "Great news!", new Guid("00000000-bbbb-0000-0000-000000000000"), "Paid news", new DateTime(2020, 9, 24, 18, 27, 31, 560, DateTimeKind.Local).AddTicks(7542), new Guid("19eee026-44cc-4d5a-a5ba-16a07abf069e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_SubscriptionId",
                table: "NewsItems",
                column: "SubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsItems");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
