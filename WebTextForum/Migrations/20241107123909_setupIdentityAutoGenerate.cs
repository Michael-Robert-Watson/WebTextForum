using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebTextForum.Migrations
{
    /// <inheritdoc />
    public partial class setupIdentityAutoGenerate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    BlogItemParentId = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "BlogItemLikes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    BlogItemId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogItemLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogItemLikes_BlogItems_BlogItemId",
                        column: x => x.BlogItemId,
                        principalTable: "BlogItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogItemTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    TagId = table.Column<string>(type: "TEXT", nullable: false),
                    BlogItemId = table.Column<string>(type: "TEXT", nullable: true)
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
                        name: "FK_BlogItemTags_BlogItems_BlogItemId",
                        column: x => x.BlogItemId,
                        principalTable: "BlogItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogItemTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bde21b8-da59-4cab-a137-067e929313b8", null, "User", "USER" },
                    { "782e4038-2251-4c3e-8865-bd216025d3f5", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "09ad6cdb-c0c1-4cdb-b5ce-08ff3117f781", 0, "d3d62e20-8f62-4016-859d-bc2fd519be68", "User2@mail.com", false, false, null, null, "USER2", "AQAAAAIAAYagAAAAECY1+kyyKBlVJ2WpP2wCfKIxuvLMXGAGJFKsbCRNMjzncEYZP8Q35A7FZYWmZsMVqQ==", null, false, "ff765305-1b85-4dc1-8289-da6f78a519c7", false, "User2" },
                    { "230d3eb3-b1ce-45ae-af7e-56d8a0e60aef", 0, "6cd71038-245a-40e9-8bc3-b26e24c53a08", "User1@mail.com", false, false, null, null, "USER1", "AQAAAAIAAYagAAAAELPWAR+OlNs1HXHOnupqcwWoGpQRu2p6PnshpBL1Jx9TfjWaKwY23dxIDq2KUsRlfg==", null, false, "f041a034-c02b-464e-ab63-37fd758c799f", false, "User1" },
                    { "8e167651-3eca-48a9-8665-05db9268765a", 0, "ce00b57d-a37b-4275-bc9a-b3cfb2ca63ac", "User4@mail.com", false, false, null, null, "USER4", "AQAAAAIAAYagAAAAEOS2lQkHgZ8WYukbGdc/D7XkpZEGdDCYcGkU5Fr+PD6xhmkBqQBxS+2yZSIXTeHDCw==", null, false, "f3c55408-d928-4d6f-9d06-069d6351a37e", false, "User4" },
                    { "e746f378-4199-4208-bdaf-3c22627b6b5c", 0, "472ab50d-288e-41c5-9b83-ccb47bcd44d9", "User3@mail.com", false, false, null, null, "USER3", "AQAAAAIAAYagAAAAEChwIzI4uSgPfsmdqtSAiehuZycmX+7TFycxutUgY0cZ7sTNm5rklI5Jv0s1dsOgaA==", null, false, "506d7807-67b6-4ebc-a5cb-8ce17f0a4b61", false, "User3" },
                    { "f5023016-8437-46a0-b825-c05530f3a7ea", 0, "c7aeaac5-a940-4992-808a-9b4229050c50", "Moderator1@mail.com", false, false, null, null, "MODERATOR", "AQAAAAIAAYagAAAAEOd+GKNkAuwruiqWgEcj1W/j0+O249a1Ke6eq2b2Bp5KWHciVPfTltBj4vH0N3uLmw==", null, false, "2e9a7d1a-fc07-4f77-a41a-9a29c9852002", false, "Moderator" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "59af8d90-c923-458b-ae86-c27f25ea5a69", "Code" },
                    { "8af690cf-0019-4fe6-9f71-07699a00707e", "Personal" },
                    { "ac65add2-97bc-415f-bce4-eaa5e9a39cb8", "News" },
                    { "be899515-7e6a-4217-b3a4-2354bf79c7cc", "Misleading or False Information" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3bde21b8-da59-4cab-a137-067e929313b8", "09ad6cdb-c0c1-4cdb-b5ce-08ff3117f781" },
                    { "3bde21b8-da59-4cab-a137-067e929313b8", "230d3eb3-b1ce-45ae-af7e-56d8a0e60aef" },
                    { "3bde21b8-da59-4cab-a137-067e929313b8", "8e167651-3eca-48a9-8665-05db9268765a" },
                    { "3bde21b8-da59-4cab-a137-067e929313b8", "e746f378-4199-4208-bdaf-3c22627b6b5c" },
                    { "782e4038-2251-4c3e-8865-bd216025d3f5", "f5023016-8437-46a0-b825-c05530f3a7ea" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogItemLikes_BlogItemId",
                table: "BlogItemLikes",
                column: "BlogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItems_BlogItemParentId",
                table: "BlogItems",
                column: "BlogItemParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItems_UserId",
                table: "BlogItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogItemTags_BlogItemId",
                table: "BlogItemTags",
                column: "BlogItemId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlogItemLikes");

            migrationBuilder.DropTable(
                name: "BlogItemTags");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BlogItems");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
