using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceHouse.Migrations
    {
        public partial class init : Migration
            {
                protected override void Up(MigrationBuilder migrationBuilder)
                    {
                        migrationBuilder.CreateTable(
                            name: "Hotels",
                            columns: table => new
                                {
                                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                    MinRoomPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                                    MaxRoomPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                                },
                            constraints: table =>
                                {
                                    table.PrimaryKey("PK_Hotels", x => x.Id);
                                });

                        migrationBuilder.CreateTable(
                            name: "HotelImages",
                            columns: table => new
                                {
                                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                                    HotelId = table.Column<int>(type: "int", nullable: false),
                                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                                },
                            constraints: table =>
                                {
                                    table.PrimaryKey("PK_HotelImages", x => x.Id);
                                    table.ForeignKey(
                                        name: "FK_HotelImages_Hotels_HotelId",
                                        column: x => x.HotelId,
                                        principalTable: "Hotels",
                                        principalColumn: "Id",
                                        onDelete: ReferentialAction.Cascade);
                                });

                        migrationBuilder.CreateTable(
                            name: "RoomTypes",
                            columns: table => new
                                {
                                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                    HotelId = table.Column<int>(type: "int", nullable: false),
                                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                                    NumberOfBeds = table.Column<int>(type: "int", nullable: false)
                                },
                            constraints: table =>
                                {
                                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                                    table.ForeignKey(
                                        name: "FK_RoomTypes_Hotels_HotelId",
                                        column: x => x.HotelId,
                                        principalTable: "Hotels",
                                        principalColumn: "Id",
                                        onDelete: ReferentialAction.Restrict);
                                });

                        migrationBuilder.CreateTable(
                            name: "Rooms",
                            columns: table => new
                                {
                                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                                    HotelId = table.Column<int>(type: "int", nullable: false),
                                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                                },
                            constraints: table =>
                                {
                                    table.PrimaryKey("PK_Rooms", x => x.Id);
                                    table.ForeignKey(
                                        name: "FK_Rooms_Hotels_HotelId",
                                        column: x => x.HotelId,
                                        principalTable: "Hotels",
                                        principalColumn: "Id",
                                        onDelete: ReferentialAction.Cascade);
                                    table.ForeignKey(
                                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                                        column: x => x.RoomTypeId,
                                        principalTable: "RoomTypes",
                                        principalColumn: "Id",
                                        onDelete: ReferentialAction.Cascade);
                                });

                        migrationBuilder.CreateTable(
                            name: "RoomTypeImages",
                            columns: table => new
                                {
                                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                                },
                            constraints: table =>
                                {
                                    table.PrimaryKey("PK_RoomTypeImages", x => x.Id);
                                    table.ForeignKey(
                                        name: "FK_RoomTypeImages_RoomTypes_RoomTypeId",
                                        column: x => x.RoomTypeId,
                                        principalTable: "RoomTypes",
                                        principalColumn: "Id",
                                        onDelete: ReferentialAction.Cascade);
                                });

                        migrationBuilder.CreateIndex(
                            name: "IX_HotelImages_HotelId",
                            table: "HotelImages",
                            column: "HotelId");

                        migrationBuilder.CreateIndex(
                            name: "IX_Rooms_HotelId",
                            table: "Rooms",
                            column: "HotelId");

                        migrationBuilder.CreateIndex(
                            name: "IX_Rooms_RoomTypeId",
                            table: "Rooms",
                            column: "RoomTypeId");

                        migrationBuilder.CreateIndex(
                            name: "IX_RoomTypeImages_RoomTypeId",
                            table: "RoomTypeImages",
                            column: "RoomTypeId");

                        migrationBuilder.CreateIndex(
                            name: "IX_RoomTypes_HotelId",
                            table: "RoomTypes",
                            column: "HotelId");
                    }

//------------------------------------------------------------------------------

                protected override void Down(MigrationBuilder migrationBuilder)
                    {
                        migrationBuilder.DropTable(name: "HotelImages");
                        migrationBuilder.DropTable(name: "Rooms");
                        migrationBuilder.DropTable(name: "RoomTypeImages");
                        migrationBuilder.DropTable(name: "RoomTypes");
                        migrationBuilder.DropTable(name: "Hotels");
                    }
            }
    }