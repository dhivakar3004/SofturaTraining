using Microsoft.EntityFrameworkCore.Migrations;

namespace SBTransactionAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTrans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTrans", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTrans");
        }
    }
}
