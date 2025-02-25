using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class AddIsLoggedOnToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedOn",
                table: "UserProfiles",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsLoggedOn", "PasswordHash" },
                values: new object[] { null, "$2a$11$D/3.48yCOmVLV.gGkI/eyeX3Bgk6cVt16WFeUyika4PYd7d.aplu." });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsLoggedOn", "PasswordHash" },
                values: new object[] { null, "$2a$11$Xkp0bbduPh.Q1Wp9cQRAaeaUuT1KRVbFBrnXZNwhlTGOl6BU2qMC6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoggedOn",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$6BlTIbtlRPB6rdkq8jm.c.gjGzRe8dHhL.LrOP13GJp8sRopH9PRe");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$3tImz.tyXTiEK/Dnv0e.SelbyPzRKyNgYG0M3BUbzdQ5I9.v6xM4G");
        }
    }
}
