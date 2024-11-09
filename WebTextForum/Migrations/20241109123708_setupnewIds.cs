using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebTextForum.Migrations
{
    /// <inheritdoc />
    public partial class setupnewIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3bde21b8-da59-4cab-a137-067e929313b8", "09ad6cdb-c0c1-4cdb-b5ce-08ff3117f781" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3bde21b8-da59-4cab-a137-067e929313b8", "230d3eb3-b1ce-45ae-af7e-56d8a0e60aef" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3bde21b8-da59-4cab-a137-067e929313b8", "8e167651-3eca-48a9-8665-05db9268765a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3bde21b8-da59-4cab-a137-067e929313b8", "e746f378-4199-4208-bdaf-3c22627b6b5c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "782e4038-2251-4c3e-8865-bd216025d3f5", "f5023016-8437-46a0-b825-c05530f3a7ea" });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "59af8d90-c923-458b-ae86-c27f25ea5a69");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "8af690cf-0019-4fe6-9f71-07699a00707e");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "ac65add2-97bc-415f-bce4-eaa5e9a39cb8");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "be899515-7e6a-4217-b3a4-2354bf79c7cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bde21b8-da59-4cab-a137-067e929313b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "782e4038-2251-4c3e-8865-bd216025d3f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09ad6cdb-c0c1-4cdb-b5ce-08ff3117f781");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "230d3eb3-b1ce-45ae-af7e-56d8a0e60aef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e167651-3eca-48a9-8665-05db9268765a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e746f378-4199-4208-bdaf-3c22627b6b5c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5023016-8437-46a0-b825-c05530f3a7ea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "644eccda-38c0-46f7-bb1b-a98b27cab0d7", null, "Moderator", "MODERATOR" },
                    { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1067d34e-dabe-4647-8394-4153fdd40ea9", 0, "aad79c50-dd23-452e-bb85-51aa0efd5b1a", "User1@mail.com", false, false, null, null, "USER1", "AQAAAAIAAYagAAAAEOXZKTBLkrSdKMav2cOepQvAAgcqFwqMLUxLjtqEKRt65vDd/fALirvS8JLk1/8Pfg==", null, false, "2317d47c-81a6-447b-8980-86745e98d2bd", false, "User1" },
                    { "52b3b000-3e20-4aba-98df-01a0664b7dd6", 0, "a8996d11-8e57-42f2-bda4-17e7172db596", "Moderator1@mail.com", false, false, null, null, "MODERATOR", "AQAAAAIAAYagAAAAEHXlUh7l9hDzHYCvc8hlxm1/glL7Mgfk8FYpH/OripSzjABqO6AuUh7SoEtjcwiiTw==", null, false, "4b9794cb-f0f0-4ac6-8a98-5fcb85e3c8e8", false, "Moderator" },
                    { "64b42dc6-5e1a-4273-a747-6394a7251e2c", 0, "2e72efa6-0d08-48a2-9894-5a2cdc7756f4", "User3@mail.com", false, false, null, null, "USER3", "AQAAAAIAAYagAAAAEFAONf0MrcBK5NrBH6W+k0dklWjP5Byn2PXnTOZbYOF44WBmZ9MBNf9QAVodmeOfKw==", null, false, "82bcc7b8-dca2-4b78-ac66-63590c9faa64", false, "User3" },
                    { "655bba26-12aa-494e-abf6-c53783668562", 0, "b40bc222-c043-4ad9-a4ab-03866b26fc4a", "User2@mail.com", false, false, null, null, "USER2", "AQAAAAIAAYagAAAAEEUzfGkQ+RFvmIQ1qyAcEnTaBNaUOrBBUEeHEhXvDkXP+7jVWeDINFy4UV6D4RDpiw==", null, false, "6e5d0b7f-edcd-49fe-9c9c-657d60c128e1", false, "User2" },
                    { "fab38226-76e7-413d-a8b1-deb8a704c955", 0, "66614a17-9c7b-4cf7-9988-bb6bdd1c988e", "User4@mail.com", false, false, null, null, "USER4", "AQAAAAIAAYagAAAAEEy7i2qwM7O4rjJRyahyg3zRIjY1jQwWUWcs76EnYY2C62uDlRcXVlulh6i0ZXDfAw==", null, false, "07c6c9b4-94d4-4f96-8e3e-5d64f5a7d90a", false, "User4" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0", "Misleading or False Information" },
                    { "41df3503-c3fc-4812-bffa-b8e9feef03fe", "Code" },
                    { "6076b6c1-51bb-475e-8a4c-2dab7ab7ad5c", "Personal" },
                    { "9f79a189-76aa-4469-bb1e-82ec6e09b403", "News" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", "1067d34e-dabe-4647-8394-4153fdd40ea9" },
                    { "644eccda-38c0-46f7-bb1b-a98b27cab0d7", "52b3b000-3e20-4aba-98df-01a0664b7dd6" },
                    { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", "64b42dc6-5e1a-4273-a747-6394a7251e2c" },
                    { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", "655bba26-12aa-494e-abf6-c53783668562" },
                    { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", "fab38226-76e7-413d-a8b1-deb8a704c955" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", "1067d34e-dabe-4647-8394-4153fdd40ea9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "644eccda-38c0-46f7-bb1b-a98b27cab0d7", "52b3b000-3e20-4aba-98df-01a0664b7dd6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", "64b42dc6-5e1a-4273-a747-6394a7251e2c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", "655bba26-12aa-494e-abf6-c53783668562" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0", "fab38226-76e7-413d-a8b1-deb8a704c955" });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "0");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "41df3503-c3fc-4812-bffa-b8e9feef03fe");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "6076b6c1-51bb-475e-8a4c-2dab7ab7ad5c");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "9f79a189-76aa-4469-bb1e-82ec6e09b403");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "644eccda-38c0-46f7-bb1b-a98b27cab0d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e29d1a8c-37f0-4c8f-8507-a6e1d721b9e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1067d34e-dabe-4647-8394-4153fdd40ea9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52b3b000-3e20-4aba-98df-01a0664b7dd6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64b42dc6-5e1a-4273-a747-6394a7251e2c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "655bba26-12aa-494e-abf6-c53783668562");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fab38226-76e7-413d-a8b1-deb8a704c955");

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
        }
    }
}
