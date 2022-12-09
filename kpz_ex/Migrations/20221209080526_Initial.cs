using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kpzex.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(name: "Book_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(name: "Book_Name", type: "nvarchar(max)", nullable: true),
                    BookAuthor = table.Column<string>(name: "Book_Author", type: "nvarchar(max)", nullable: true),
                    BookQuantity = table.Column<int>(name: "Book_Quantity", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
