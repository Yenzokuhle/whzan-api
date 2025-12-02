using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Whzan_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    IsPredefined = table.Column<bool>(type: "bit", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    isWatched = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favourite_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCurrency_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCurrency_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Watched",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watched", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watched_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTag_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "$", "US Dollar" },
                    { 2, "R", "Rand" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ImageURL" },
                values: new object[,]
                {
                    { 1, "https://media.takealot.com/covers_images/ada2654a1b6f49e298336ac8e5e4d156/s-zoom.file" },
                    { 2, "https://media.takealot.com/covers_images/d6849ec5f50a409aa6306255409957e3/s-zoom.file" },
                    { 3, "https://media.takealot.com/covers_images/52fc46b0248f471db459838937999eb3/s-zoom.file" },
                    { 4, "https://media.takealot.com/covers_images/3d3c187f5fef403e88a32d56f7e0647e/s-zoom.file" },
                    { 5, "https://media.takealot.com/covers_images/ff210e16d57f48c698034c35a8dee348/s-zoom.file" },
                    { 6, "https://media.takealot.com/covers_images/2827a86a69744e36a60a375b573e9be3/s-zoom.file" },
                    { 7, "https://media.takealot.com/covers_images/599c45b09a8b41df82d0f28a8cbddc5c/s-zoom.file" },
                    { 8, "https://media.takealot.com/covers_images/2e1d4ba85c1c4a69b31454ec03a464b8/s-zoom.file" },
                    { 9, "https://media.takealot.com/covers_images/0241de942b2a431c8d326f9a4ffdbb9a/s-zoom.file" },
                    { 10, "https://media.takealot.com/covers_images/f12610962a184b00a96870ca42f36507/s-zoom.file" },
                    { 11, "https://media.takealot.com/covers_images/434e43a10f504d30b44d5b1f23c32b07/s-zoom.file" },
                    { 12, "https://media.takealot.com/covers_images/cbab723c5d404752866fe30f8a5fbb36/s-zoom.file" },
                    { 13, "https://media.takealot.com/covers_images/68e38c6ded394787985de7f9583b408c/s-zoom.file" },
                    { 14, "https://media.takealot.com/covers_images/1314ce11ae994990bac2320c1ee607a9/s-zoom.file" },
                    { 15, "https://media.takealot.com/covers_images/5af2807dd6f84bdb88a30f647d083a6e/s-zoom.file" },
                    { 16, "https://media.takealot.com/covers_images/cd58f55bbb4b448f99e99fbcb555493c/s-zoom.file" },
                    { 17, "https://media.takealot.com/covers_images/dddd25a12747493eb8353b10c71576a7/s-zoom.file" },
                    { 18, "https://media.takealot.com/covers_images/61625c49992241acb65b9191e21de793/s-zoom.file" },
                    { 19, "https://media.takealot.com/covers_images/0c1c1ae3580148529088079267e18f8e/s-zoom.file" },
                    { 20, "https://media.takealot.com/covers_images/7e0a4b3692cb4895b45432e89e22f978/s-zoom.file" },
                    { 21, "https://media.takealot.com/covers_images/7a9d16396be5483e9a1f3bfdc5d23ecf/s-zoom.file" },
                    { 22, "https://media.takealot.com/covers_images/f66e2b0c7aa64e3ea18055c5d44580fb/s-zoom.file" },
                    { 23, "https://media.takealot.com/covers_images/072823ead7a24449aed85592e2fec96f/s-zoom.file" },
                    { 24, "https://media.takealot.com/covers_images/dd9e2c8f33034aefb5ae921f9adb592c/s-zoom.file" },
                    { 25, "https://media.takealot.com/covers_images/825e3017cbb84c779176fc5af7f5471d/s-zoom.file" },
                    { 26, "https://media.takealot.com/covers_images/e689bb5a45994ffa832cce32fddf2a67/s-zoom.file" },
                    { 27, "https://media.takealot.com/covers_images/a35456fce4034864a82bce57674d171a/s-zoom.file" },
                    { 28, "https://media.takealot.com/covers_images/a8734d0db2554a6381e5e31a4e11a2cc/s-zoom.file" },
                    { 29, "https://media.takealot.com/covers_images/b4359d3c59c042e5a6e52aa44e8e4575/s-zoom.file" },
                    { 30, "https://media.takealot.com/covers_images/5eb9ca39bcae47e591157b989d70927e/s-zoom.file" },
                    { 31, "https://media.takealot.com/covers_images/6c861aed47a34d549f7f17b0d81c4fd3/s-zoom.file" },
                    { 32, "https://media.takealot.com/covers_images/fc1000768be64c64b3a57ffdd0691b35/s-zoom.file" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Brand", "Currency", "Description", "ImageURL", "InStock", "IsFavourite", "IsPredefined", "Name", "Price", "Rating", "ReviewCount", "UpdatedAt", "isWatched" },
                values: new object[,]
                {
                    { 1, "JBL", "Rands", "JBL Live 770NC headphones deliver powerful JBL Signature Sound in a comfortable over-ear headband style.", null, true, false, true, "JBL Live 770NC Wireless Bluetooth Over-Ear Noise Cancelling Headphones", 1925m, 4.3m, 103, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), false },
                    { 2, "Timex", "Rands", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", null, true, false, true, "Timex Expedition Gallatin Solar-Powered (TW4B14500)", 2399m, 3.8m, 25, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), false },
                    { 3, "Soundcore", "Rands", "98.5% Noise Reduction. Adaptive Noise Cancelling. Hi-Res Sound. 50H Battery. Wireless Charging. Bluetooth 5.3", null, false, false, true, "Soundcore by Anker Liberty 4 NC Wireless Noise Cancelling Earbuds", 1299m, 4.5m, 32, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), false },
                    { 4, "Beyerdynamic", "Rands", "Beyerdynamic AVENTHO 100 features more than 60 hours playtime & up to 40 hours with ANC.", null, true, false, true, "Beyerdynamic AVENTHO 100 Wireless On-Ear Headphones With ANC - Cream", 4499m, 4.1m, 77, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), false },
                    { 5, "JBL", "Rands", "JBL Pro Sound, Dynamic Lightshow, 15H Playtime, Auracast Multi-Speaker Connection & Splashproof", null, true, false, true, "JBL PartyBox On-The-Go 2 Portable Bluetooth Party Speaker with Wireless Mic", 5999m, 4.2m, 61, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), false },
                    { 6, "Hisense", "Rands", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", null, true, false, true, "Hisense 65inch E7Q 4K UHD QLED Smart TV with Dolby Vision", 7999m, 4.8m, 22, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), false },
                    { 7, "Huawei", "Rands", "3-Hour Listening on 10-minute Charge | Long Press to Pair| Bluetooth5.4 Connect | IP54 Dust &Splash-Resistance", null, false, false, true, "HUAWEI FreeBuds SE 3 -Earphones/Wireless Earbuds|42-Hour Battery Life-Black", 999m, 4.5m, 87, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), false },
                    { 8, "Sennheiser", "Rands", "Wireless Over-Ear Noise Cancelling Headphones", null, true, false, true, "Sennheiser MOMENTUM 4 Wireless Over-Ear Noise Cancelling Headphones (Teal)", 5450m, 3.5m, 50, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), false }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "ImageId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 2 },
                    { 6, 6, 2 },
                    { 7, 7, 2 },
                    { 8, 8, 2 },
                    { 9, 9, 3 },
                    { 10, 10, 3 },
                    { 11, 11, 3 },
                    { 12, 12, 3 },
                    { 13, 13, 4 },
                    { 14, 14, 4 },
                    { 15, 15, 4 },
                    { 16, 16, 4 },
                    { 17, 17, 5 },
                    { 18, 18, 5 },
                    { 19, 19, 5 },
                    { 20, 20, 5 },
                    { 21, 21, 6 },
                    { 22, 22, 6 },
                    { 23, 23, 6 },
                    { 24, 24, 6 },
                    { 25, 25, 7 },
                    { 26, 26, 7 },
                    { 27, 27, 7 },
                    { 28, 28, 7 },
                    { 29, 29, 8 },
                    { 30, 30, 8 },
                    { 31, 31, 8 },
                    { 32, 32, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourite_ProductId",
                table: "Favourite",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCurrency_CurrencyId",
                table: "ProductCurrency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCurrency_ProductId",
                table: "ProductCurrency",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ImageId",
                table: "ProductImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_ProductId",
                table: "ProductTag",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagId",
                table: "ProductTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Watched_ProductId",
                table: "Watched",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourite");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductCurrency");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.DropTable(
                name: "Watched");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
