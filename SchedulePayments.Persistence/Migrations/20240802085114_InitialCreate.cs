using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulePayments.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchedulePayments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BeneficiaryAccountNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderAccount = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUpdated = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulePayments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchedulePayments");
        }
    }
}
