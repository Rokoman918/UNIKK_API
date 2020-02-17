using Microsoft.EntityFrameworkCore.Migrations;

namespace UNIKK_API.Migrations
{
    public partial class CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enterprices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Tax_Id = table.Column<short>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeUnities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeUnities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unitys",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    IdEnterprice = table.Column<int>(nullable: false),
                    IdtypeUnity = table.Column<int>(nullable: false),
                    enterpriceNavId = table.Column<int>(nullable: true),
                    typeUnityNavId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unitys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unitys_Enterprices_enterpriceNavId",
                        column: x => x.enterpriceNavId,
                        principalTable: "Enterprices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Unitys_TypeUnities_typeUnityNavId",
                        column: x => x.typeUnityNavId,
                        principalTable: "TypeUnities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UnityId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Unitys_UnityId",
                        column: x => x.UnityId,
                        principalTable: "Unitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    TypeNumber = table.Column<string>(nullable: true),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_UnityId",
                table: "People",
                column: "UnityId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonId",
                table: "PhoneNumbers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Unitys_enterpriceNavId",
                table: "Unitys",
                column: "enterpriceNavId");

            migrationBuilder.CreateIndex(
                name: "IX_Unitys_typeUnityNavId",
                table: "Unitys",
                column: "typeUnityNavId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Unitys");

            migrationBuilder.DropTable(
                name: "Enterprices");

            migrationBuilder.DropTable(
                name: "TypeUnities");
        }
    }
}
