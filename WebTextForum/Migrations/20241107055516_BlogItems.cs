using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebTextForum.Migrations
{
    /// <inheritdoc />
    public partial class BlogItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser<string>");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c7c2a0a-e24b-4880-b519-56226468779f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e98eeb40-6d93-417d-9233-51738034bf0a");

            migrationBuilder.CreateTable(
                name: "BlogItemLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItemLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    BlogItemParentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogItems_BlogItems_BlogItemParentId",
                        column: x => x.BlogItemParentId,
                        principalTable: "BlogItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogItemTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItemTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogItemTags_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogItemTags_BlogItemTags_TagId",
                        column: x => x.TagId,
                        principalTable: "BlogItemTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05507b6f-3d69-4b68-b53f-80a0128f56a8", null, "Moderator", "MODERATOR" },
                    { "4fc03002-6ae6-4030-84b4-4048cd4c4422", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04628fcb-8950-43ca-892d-cbb12188a3ce", 0, "c941bdb5-7731-488d-915c-68369d93f827", "Moderator1@mail.com", false, false, null, null, "MODERATOR", "AQAAAAIAAYagAAAAEMN+VlSNOhgfgApe86Cnh8nbMtanSBRd7f1j+xkhknjx0HuXVVPa6WTKwhzK7g5nQQ==", null, false, "a6363ff1-87fa-48da-90a6-523ef553546e", false, "Moderator" },
                    { "0639fdf2-e318-4362-bcb3-ada6d381081a", 0, "6b50badb-fc7e-425a-aa71-b5a9924c6990", "User3@mail.com", false, false, null, null, "USER3", "AQAAAAIAAYagAAAAECK4R9dmaij91atlj7Zrs2OxDH6Lf+2OcuJMJH2hGfVfgHxWH/9G8+DerslQkbDrrg==", null, false, "8d1bf58e-9598-40dc-b7aa-072293d6a51b", false, "User3" },
                    { "456241b5-dbbd-4cb4-84f2-f8648a7a9932", 0, "28dcf23d-5281-4ea6-926e-79787872189b", "User4@mail.com", false, false, null, null, "USER4", "AQAAAAIAAYagAAAAEO1wmhCnSNNO7P6evtBASkqgRHb+XWr5+UmM7/vFYXsuRPmJm5oVUJld5XlFt1R5RQ==", null, false, "930c2a30-2d13-4470-8484-a3da76ec00c1", false, "User4" },
                    { "5bb0ee5a-4a6d-4233-aa05-5fb1b49e0c6b", 0, "93338151-9ec2-43aa-b8bd-3e2e2f8d47e8", "User2@mail.com", false, false, null, null, "USER2", "AQAAAAIAAYagAAAAEMKev3Sc0Te1oFGlPB55Xo7nlJdCwez13OwcRtSD/BZCC5JIes2YFiqWZjW2wHT1rA==", null, false, "f6687675-ff27-4f80-b5ca-3c39e3e1e138", false, "User2" },
                    { "a2e4511d-1d6a-4364-8761-0cf74828e790", 0, "8999439b-e4c9-479e-9808-3256f17cc8bf", "User1@mail.com", false, false, null, null, "USER1", "AQAAAAIAAYagAAAAEFBWg6nDvsn6mJjy7Ra4cIQItA+FOmewiIMOKKMwgbnoMSiM2lhxBV5eBZ2Es0/b7Q==", null, false, "6f827187-0d89-45cc-9564-4a965d6104f4", false, "User1" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Misleading or False Information" },
                    { 2, "News" },
                    { 3, "Personal" },
                    { 4, "Code" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "05507b6f-3d69-4b68-b53f-80a0128f56a8", "04628fcb-8950-43ca-892d-cbb12188a3ce" },
                    { "4fc03002-6ae6-4030-84b4-4048cd4c4422", "0639fdf2-e318-4362-bcb3-ada6d381081a" },
                    { "4fc03002-6ae6-4030-84b4-4048cd4c4422", "456241b5-dbbd-4cb4-84f2-f8648a7a9932" },
                    { "4fc03002-6ae6-4030-84b4-4048cd4c4422", "5bb0ee5a-4a6d-4233-aa05-5fb1b49e0c6b" },
                    { "4fc03002-6ae6-4030-84b4-4048cd4c4422", "a2e4511d-1d6a-4364-8761-0cf74828e790" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogItems_BlogItemParentId",
                table: "BlogItems",
                column: "BlogItemParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItems_UserId",
                table: "BlogItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItemTags_TagId",
                table: "BlogItemTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItemTags_UserId",
                table: "BlogItemTags",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogItemLikes");

            migrationBuilder.DropTable(
                name: "BlogItems");

            migrationBuilder.DropTable(
                name: "BlogItemTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "05507b6f-3d69-4b68-b53f-80a0128f56a8", "04628fcb-8950-43ca-892d-cbb12188a3ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4fc03002-6ae6-4030-84b4-4048cd4c4422", "0639fdf2-e318-4362-bcb3-ada6d381081a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4fc03002-6ae6-4030-84b4-4048cd4c4422", "456241b5-dbbd-4cb4-84f2-f8648a7a9932" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4fc03002-6ae6-4030-84b4-4048cd4c4422", "5bb0ee5a-4a6d-4233-aa05-5fb1b49e0c6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4fc03002-6ae6-4030-84b4-4048cd4c4422", "a2e4511d-1d6a-4364-8761-0cf74828e790" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05507b6f-3d69-4b68-b53f-80a0128f56a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fc03002-6ae6-4030-84b4-4048cd4c4422");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04628fcb-8950-43ca-892d-cbb12188a3ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0639fdf2-e318-4362-bcb3-ada6d381081a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "456241b5-dbbd-4cb4-84f2-f8648a7a9932");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bb0ee5a-4a6d-4233-aa05-5fb1b49e0c6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2e4511d-1d6a-4364-8761-0cf74828e790");

            migrationBuilder.CreateTable(
                name: "IdentityUser<string>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser<string>", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c7c2a0a-e24b-4880-b519-56226468779f", null, "User", "USER" },
                    { "e98eeb40-6d93-417d-9233-51738034bf0a", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "IdentityUser<string>",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "713596b9-b4d0-426d-9b98-fd93b53b5fe1", 0, "912d703d-137d-4e41-8b00-ee7cf20d3fd6", null, false, false, null, null, "User4", "AQAAAAIAAYagAAAAEOm1ssZU/T8Xs/XOFkuzyZ5puJjbpBgWSzgATd05h7BXseM7HM+1xBSLVOznWV5YHQ==", null, false, null, false, "User4" },
                    { "884b38aa-ed0b-43b6-a8eb-ef26a0491442", 0, "64d856ed-373b-4ece-9ecd-6524453f7361", null, false, false, null, null, "Moderator", "AQAAAAIAAYagAAAAEPFo+niX54/SLM56GzVRJHbh3tus/PbyQX7M+Pz2MImC3q9F3LmnnOfGiucMAinuhw==", null, false, null, false, "Moderator" },
                    { "aece1d40-bead-46e7-8399-35e50403b208", 0, "93ecb377-7b4c-4047-84db-27c6773651c8", null, false, false, null, null, "User1", "AQAAAAIAAYagAAAAEAGxHKJxVSf673aFOxkVDhJxFA5zDIQTO3nKGeIjL81E39oGgNGrCRm0VothLZqRYw==", null, false, null, false, "User1" },
                    { "b2a3be59-1360-4a74-9efd-dd76ce216f4c", 0, "f40f99bb-c1d5-46d9-8a29-d7a96df18d6e", null, false, false, null, null, "User3", "AQAAAAIAAYagAAAAEHIscuaLzdbV4oCmtGRaKU24saUHsbFj9MGmp5wGItKQhNMYCY5ageRABCuyw3b49g==", null, false, null, false, "User3" },
                    { "b56d09df-77b7-4102-b83f-ce8de438d4cf", 0, "a88cb3df-eebb-4e57-b207-a3baab9b3e35", null, false, false, null, null, "User2", "AQAAAAIAAYagAAAAENJzJFpI4tMZjqKc96x4wJjLgUUD3v0RudarwhQdKnQOdMK44uVW++xgeFU5UzjP9A==", null, false, null, false, "User2" }
                });
        }
    }
}
