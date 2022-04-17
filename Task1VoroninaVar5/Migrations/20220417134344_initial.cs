using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1VoroninaVar5.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    flatNum = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    streetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Streets_streetId",
                        column: x => x.streetId,
                        principalTable: "Streets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Streets",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Michurina" });

            migrationBuilder.InsertData(
                table: "Streets",
                columns: new[] { "Id", "Name" },
                values: new object[] { 55, "Veselaya" });

            migrationBuilder.InsertData(
                table: "Streets",
                columns: new[] { "Id", "Name" },
                values: new object[] { 541, "Rakhova" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "flatNum", "streetId", "year" },
                values: new object[,]
                {
                    { "100-л", 800, 55, 2022 },
                    { "14", 90, 541, 1955 },
                    { "17-б", 466, 55, 1980 },
                    { "1789-у", 10, 55, 1988 },
                    { "3-a", 2000, 11, 2000 },
                    { "4-б", 36, 11, 1976 },
                    { "43", 50, 541, 1910 },
                    { "55", 66, 541, 1999 },
                    { "75-с", 355, 11, 2010 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_streetId",
                table: "Houses",
                column: "streetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Streets");
        }
    }
}
