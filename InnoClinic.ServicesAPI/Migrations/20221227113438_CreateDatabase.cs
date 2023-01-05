using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoClinic.ServicesAPI.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TimeSlotSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiceCategories_ServiceCategoryId",
                        column: x => x.ServiceCategoryId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id", "CategoryName", "TimeSlotSize" },
                values: new object[] { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "SomeCategoryName", 0 });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { new Guid("acc08d75-50ea-4689-84cc-bc4b41138301"), "SpecName1", true });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Price", "ServiceCategoryId", "ServiceName", "SpecializationId" },
                values: new object[,]
                {
                    { new Guid("0d6b7dc6-b351-4b72-ab6a-08dad78540c0"), 60m, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "SomeName5", new Guid("acc08d75-50ea-4689-84cc-bc4b41138301") },
                    { new Guid("24d92a89-a088-4687-9947-08dac62592e6"), 90m, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "SomeName2", new Guid("acc08d75-50ea-4689-84cc-bc4b41138301") },
                    { new Guid("3a31f073-c35d-4a5c-072f-08dad37b7a49"), 80m, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "SomeName3", new Guid("acc08d75-50ea-4689-84cc-bc4b41138301") },
                    { new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"), 100m, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "SomeName1", new Guid("acc08d75-50ea-4689-84cc-bc4b41138301") },
                    { new Guid("d46f387f-86a2-4775-238b-08dad77cc06d"), 70m, new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "SomeName4", new Guid("acc08d75-50ea-4689-84cc-bc4b41138301") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceCategoryId",
                table: "Services",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SpecializationId",
                table: "Services",
                column: "SpecializationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
