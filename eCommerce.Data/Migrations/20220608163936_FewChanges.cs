using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Data.Migrations
{
    public partial class FewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCatoregories_SubCatoregoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "SubCatoregories");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCatoregoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCatoregoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserAdresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsValidated",
                table: "ShopOwners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ShopOwnerAdresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserAdresses");

            migrationBuilder.DropColumn(
                name: "IsValidated",
                table: "ShopOwners");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ShopOwnerAdresses");

            migrationBuilder.AddColumn<int>(
                name: "SubCatoregoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubCatoregories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImgSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCatoregories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCatoregories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCatoregoryId",
                table: "Products",
                column: "SubCatoregoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCatoregories_CategoryId",
                table: "SubCatoregories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCatoregories_SubCatoregoryId",
                table: "Products",
                column: "SubCatoregoryId",
                principalTable: "SubCatoregories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
