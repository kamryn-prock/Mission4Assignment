using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    year = table.Column<short>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lent = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ApplicationId);
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 1, "Action/Adventure", "Tom", false, null, null, "PG-13", "Avengers, The", (short)2012 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 2, "Action/Adventure", "Zach", false, null, null, "PG-13", "Batman", (short)1989 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "ApplicationId", "category", "director", "edited", "lent", "notes", "rating", "title", "year" },
                values: new object[] { 3, "Action/Adventure", "Jake", false, null, null, "PG-13", "Batman & Robin", (short)1989 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
