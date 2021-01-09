using Microsoft.EntityFrameworkCore.Migrations;

namespace Dobie_Bianca_Proiect_Tel.Migrations
{
    public partial class PhoneCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerID",
                table: "Phone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhoneCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneCategory_Phone_PhoneID",
                        column: x => x.PhoneID,
                        principalTable: "Phone",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_SellerID",
                table: "Phone",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCategory_CategoryID",
                table: "PhoneCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneCategory_PhoneID",
                table: "PhoneCategory",
                column: "PhoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Seller_SellerID",
                table: "Phone",
                column: "SellerID",
                principalTable: "Seller",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Seller_SellerID",
                table: "Phone");

            migrationBuilder.DropTable(
                name: "PhoneCategory");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Phone_SellerID",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Phone");
        }
    }
}
