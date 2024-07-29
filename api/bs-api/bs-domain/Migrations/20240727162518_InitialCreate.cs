using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bs_data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Publisher = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Edition = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PriceTable",
                columns: table => new
                {
                    Code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTable", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Code = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookCode = table.Column<long>(type: "bigint", nullable: false),
                    AuthorCode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.BookCode, x.AuthorCode });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Author_AuthorCode",
                        column: x => x.AuthorCode,
                        principalTable: "Author",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Book_BookCode",
                        column: x => x.BookCode,
                        principalTable: "Book",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookPriceTable",
                columns: table => new
                {
                    BookCode = table.Column<long>(type: "bigint", nullable: false),
                    PriceTableCode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPriceTable", x => new { x.BookCode, x.PriceTableCode });
                    table.ForeignKey(
                        name: "FK_BookPriceTable_Book_BookCode",
                        column: x => x.BookCode,
                        principalTable: "Book",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPriceTable_PriceTable_PriceTableCode",
                        column: x => x.PriceTableCode,
                        principalTable: "PriceTable",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSubject",
                columns: table => new
                {
                    BookCode = table.Column<long>(type: "bigint", nullable: false),
                    SubjectCode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubject", x => new { x.BookCode, x.SubjectCode });
                    table.ForeignKey(
                        name: "FK_BookSubject_Book_BookCode",
                        column: x => x.BookCode,
                        principalTable: "Book",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSubject_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorCode",
                table: "BookAuthor",
                column: "AuthorCode");

            migrationBuilder.CreateIndex(
                name: "IX_BookPriceTable_PriceTableCode",
                table: "BookPriceTable",
                column: "PriceTableCode");

            migrationBuilder.CreateIndex(
                name: "IX_BookSubject_SubjectCode",
                table: "BookSubject",
                column: "SubjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "BookPriceTable");

            migrationBuilder.DropTable(
                name: "BookSubject");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "PriceTable");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
