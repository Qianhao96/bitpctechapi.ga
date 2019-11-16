using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bitpctechapi.Migrations
{
    public partial class ImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PcParts");

            migrationBuilder.AddColumn<int>(
                name: "ImagesId",
                table: "PcParts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImagesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image1 = table.Column<string>(nullable: false),
                    Image2 = table.Column<string>(nullable: false),
                    Image3 = table.Column<string>(nullable: false),
                    Image4 = table.Column<string>(nullable: false),
                    Image5 = table.Column<string>(nullable: false),
                    Image6 = table.Column<string>(nullable: true),
                    Image7 = table.Column<string>(nullable: true),
                    Image8 = table.Column<string>(nullable: true),
                    Image9 = table.Column<string>(nullable: true),
                    Image10 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImagesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PcParts_ImagesId",
                table: "PcParts",
                column: "ImagesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PcParts_Images_ImagesId",
                table: "PcParts",
                column: "ImagesId",
                principalTable: "Images",
                principalColumn: "ImagesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PcParts_Images_ImagesId",
                table: "PcParts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_PcParts_ImagesId",
                table: "PcParts");

            migrationBuilder.DropColumn(
                name: "ImagesId",
                table: "PcParts");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "PcParts",
                nullable: false,
                defaultValue: "");
        }
    }
}
