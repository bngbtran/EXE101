using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceHouse.Migrations
    {
           public partial class addDormTable : Migration
                {
                    protected override void Up(MigrationBuilder migrationBuilder)
                        {
                            migrationBuilder.AddColumn<int>(
                                name: "DormitoryId",
                                table: "RoomTypes",
                                type: "int",
                                nullable: true);

                            migrationBuilder.AddColumn<int>(
                                name: "DormitoryId",
                                table: "Rooms",
                                type: "int",
                                nullable: true);

                            migrationBuilder.CreateTable(
                                name: "Dormitories",
                                columns: table => new
                                    {
                                        Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                                        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                                        Type = table.Column<int>(type: "int", nullable: false),
                                        Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                                        Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                                        MaxRoomPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                                        MinRoomPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                                        NumberOfPeople = table.Column<int>(type: "int", nullable: false)
                                    },
                                constraints: table =>
                                    {
                                        table.PrimaryKey("PK_Dormitories", x => x.Id);
                                    });

                            migrationBuilder.CreateTable(
                                name: "DormitoryImages",
                                columns: table => new
                                    {
                                        Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                                        Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                        DormitoryId = table.Column<int>(type: "int", nullable: false)
                                    },
                                constraints: table =>
                                    {
                                        table.PrimaryKey("PK_DormitoryImages", x => x.Id);
                                        table.ForeignKey(
                                            name: "FK_DormitoryImages_Dormitories_DormitoryId",
                                            column: x => x.DormitoryId,
                                            principalTable: "Dormitories",
                                            principalColumn: "Id",
                                            onDelete: ReferentialAction.Cascade);
                                    });

                            migrationBuilder.CreateIndex(
                                name: "IX_RoomTypes_DormitoryId",
                                table: "RoomTypes",
                                column: "DormitoryId");

                            migrationBuilder.CreateIndex(
                                name: "IX_Rooms_DormitoryId",
                                table: "Rooms",
                                column: "DormitoryId");

                            migrationBuilder.CreateIndex(
                                name: "IX_DormitoryImages_DormitoryId",
                                table: "DormitoryImages",
                                column: "DormitoryId");

                            migrationBuilder.AddForeignKey(
                                name: "FK_Rooms_Dormitories_DormitoryId",
                                table: "Rooms",
                                column: "DormitoryId",
                                principalTable: "Dormitories",
                                principalColumn: "Id");

                            migrationBuilder.AddForeignKey(
                                name: "FK_RoomTypes_Dormitories_DormitoryId",
                                table: "RoomTypes",
                                column: "DormitoryId",
                                principalTable: "Dormitories",
                                principalColumn: "Id");
                        }

//------------------------------------------------------------------------------

                    protected override void Down(MigrationBuilder migrationBuilder)
                        {
                            migrationBuilder.DropForeignKey(name: "FK_Rooms_Dormitories_DormitoryId", table: "Rooms");
                            migrationBuilder.DropForeignKey(name: "FK_RoomTypes_Dormitories_DormitoryId", table: "RoomTypes");
                            migrationBuilder.DropTable(name: "DormitoryImages");
                            migrationBuilder.DropTable(name: "Dormitories");
                            migrationBuilder.DropIndex(name: "IX_RoomTypes_DormitoryId", table: "RoomTypes");
                            migrationBuilder.DropIndex(name: "IX_Rooms_DormitoryId", table: "Rooms");
                            migrationBuilder.DropColumn(name: "DormitoryId", table: "RoomTypes");
                            migrationBuilder.DropColumn(name: "DormitoryId", table: "Rooms");
                        }
                }
    }