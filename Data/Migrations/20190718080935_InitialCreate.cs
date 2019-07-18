using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XlsxFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XlsxFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Xlsx1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Col1 = table.Column<string>(nullable: true),
                    Col2 = table.Column<string>(nullable: true),
                    Col3 = table.Column<string>(nullable: true),
                    Col4 = table.Column<string>(nullable: true),
                    Col5 = table.Column<string>(nullable: true),
                    Col6 = table.Column<string>(nullable: true),
                    Col7 = table.Column<string>(nullable: true),
                    Col8 = table.Column<string>(nullable: true),
                    Col9 = table.Column<string>(nullable: true),
                    Col10 = table.Column<string>(nullable: true),
                    Col11 = table.Column<string>(nullable: true),
                    Col12 = table.Column<string>(nullable: true),
                    Col13 = table.Column<string>(nullable: true),
                    Col14 = table.Column<string>(nullable: true),
                    Col15 = table.Column<string>(nullable: true),
                    Col16 = table.Column<string>(nullable: true),
                    Col17 = table.Column<string>(nullable: true),
                    Col18 = table.Column<string>(nullable: true),
                    Col19 = table.Column<string>(nullable: true),
                    Col120 = table.Column<string>(nullable: true),
                    FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xlsx1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xlsx1_XlsxFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "XlsxFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xlsx2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Col1 = table.Column<string>(nullable: true),
                    Col2 = table.Column<string>(nullable: true),
                    Col3 = table.Column<string>(nullable: true),
                    Col4 = table.Column<string>(nullable: true),
                    Col5 = table.Column<string>(nullable: true),
                    Col6 = table.Column<string>(nullable: true),
                    Col7 = table.Column<string>(nullable: true),
                    Col8 = table.Column<string>(nullable: true),
                    Col9 = table.Column<string>(nullable: true),
                    Col10 = table.Column<string>(nullable: true),
                    Col11 = table.Column<string>(nullable: true),
                    Col12 = table.Column<string>(nullable: true),
                    Col13 = table.Column<string>(nullable: true),
                    Col14 = table.Column<string>(nullable: true),
                    Col15 = table.Column<string>(nullable: true),
                    Col16 = table.Column<string>(nullable: true),
                    Col17 = table.Column<string>(nullable: true),
                    Col18 = table.Column<string>(nullable: true),
                    Col19 = table.Column<string>(nullable: true),
                    Col120 = table.Column<string>(nullable: true),
                    FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xlsx2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xlsx2_XlsxFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "XlsxFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Xlsx1_FileId",
                table: "Xlsx1",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Xlsx2_FileId",
                table: "Xlsx2",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Xlsx1");

            migrationBuilder.DropTable(
                name: "Xlsx2");

            migrationBuilder.DropTable(
                name: "XlsxFiles");
        }
    }
}
