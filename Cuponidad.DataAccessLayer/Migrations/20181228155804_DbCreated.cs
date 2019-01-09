using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cuponidad.DataAccessLayer.Migrations
{
    public partial class DbCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryLevels",
                columns: table => new
                {
                    CategoryLevelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelNumber = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLevels", x => x.CategoryLevelID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phone = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "DropDownListBydays",
                columns: table => new
                {
                    DaysOpenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropDownListBydays", x => x.DaysOpenID);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FamilyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FamilyID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryLevelID = table.Column<int>(nullable: false),
                    FamilyID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_CategoryLevels_CategoryLevelID",
                        column: x => x.CategoryLevelID,
                        principalTable: "CategoryLevels",
                        principalColumn: "CategoryLevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Families_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "Families",
                        principalColumn: "FamilyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    DaysOpenID = table.Column<int>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Prize = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Terms = table.Column<string>(nullable: true),
                    DayUse = table.Column<string>(nullable: true),
                    Conditions = table.Column<string>(nullable: true),
                    QuantitySold = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_DropDownListBydays_DaysOpenID",
                        column: x => x.DaysOpenID,
                        principalTable: "DropDownListBydays",
                        principalColumn: "DaysOpenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RightBanners",
                columns: table => new
                {
                    RightBannerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightBanners", x => x.RightBannerID);
                    table.ForeignKey(
                        name: "FK_RightBanners_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoryLevels",
                columns: new[] { "CategoryLevelID", "Color", "LevelNumber" },
                values: new object[,]
                {
                    { 1, null, 1 },
                    { 2, null, 2 },
                    { 3, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "Direction", "Phone" },
                values: new object[,]
                {
                    { 1, "Company 1", "11515455" },
                    { 2, "Company 2", "65685448" },
                    { 3, "Company 3", "45487877" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Name" },
                values: new object[,]
                {
                    { 1, "Department 1" },
                    { 2, "Department 2" },
                    { 3, "Department 3" }
                });

            migrationBuilder.InsertData(
                table: "Families",
                columns: new[] { "FamilyID", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 8, "images/b2.png", "Belleza" },
                    { 7, "images/sinreservaicov2.png", "Sin Reserva" },
                    { 6, "images/entre2c.png", "Entretenimiento" },
                    { 5, "images/menucyberday2018v3.png", "Cyber Days " },
                    { 1, "images/a2.png", "Productos" },
                    { 3, "images/d2.png", "Salud" },
                    { 2, "images/f2.png", "Viajes" },
                    { 9, "images/buffet2c.png", "Restaurantes" },
                    { 4, "images/e2.png", "Servicios" },
                    { 10, "images/g2.png", "Cines" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryLevelID", "FamilyID", "Name" },
                values: new object[,]
                {
                    { 1, 2, 1, "Accesorios Para Auto" },
                    { 2, 2, 1, "Camping" },
                    { 3, 2, 2, "Año Nuevo" },
                    { 4, 2, 2, "Hoteles" },
                    { 9, 3, 4, "Fotografia" },
                    { 6, 3, 6, "Actividades Familiares" },
                    { 7, 3, 6, "Teatro" },
                    { 8, 3, 8, "Maquillaje y Extensiones" },
                    { 5, 3, 9, "Buffets" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductID",
                table: "Carts",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_CategoryLevelID",
                table: "Categories",
                column: "CategoryLevelID");

            migrationBuilder.CreateIndex(
                name: "Index_FamilyID",
                table: "Categories",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyID",
                table: "Products",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DaysOpenID",
                table: "Products",
                column: "DaysOpenID");

            migrationBuilder.CreateIndex(
                name: "IX_RightBanners_ProductID",
                table: "RightBanners",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "RightBanners");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "DropDownListBydays");

            migrationBuilder.DropTable(
                name: "CategoryLevels");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
