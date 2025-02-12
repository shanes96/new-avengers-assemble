using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComics_UserProfiles_UserProfileId",
                table: "UserComics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_UserProfiles_UserProfileId",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_UserProfileId",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserComics_UserProfileId",
                table: "UserComics");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserComics");

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "Extension", "Picture", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "jpg", "http://i.annihil.us/u/prod/marvel/i/mg/c/80/5e3d7536c8ada", 10.99m, "Marvel Previews (2017)" },
                    { 2, "jpg", "http://i.annihil.us/u/prod/marvel/i/mg/b/c0/639a7b035cbaa", 21.99m, "Iron Man (2022) #1" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Bio", "Email", "Name", "ProfileImage", "UserLosses", "UserWins" },
                values: new object[,]
                {
                    { 1, "I can do this all day", "steverodgers@avengers.com", "Steve Rodgers", "https://ca.slack-edge.com/T6G3NJMK5-U02S94DBXLP-d199360ebd76-512", 2, 10 },
                    { 2, "Genius, billionaire, playboy, philanthropist", "tonystark@avengers.com", "Tony Stark", "https://media1.popsugar-assets.com/files/thumbor/ZCWD9YXxqYzk9riO2WR2OrxzWUw/721x0:1801x1080/fit-in/2048xorig/filters:format_auto-!!-:strip_icc-!!-/2019/07/01/098/n/46207611/5d2cc4f65d1ab1d1992803.52716266_/i/Why-Tony-Stark-Best-Marvel-Character.jpg", 1, 3000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComics_UserId",
                table: "UserComics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComics_UserProfiles_UserId",
                table: "UserComics",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_UserProfiles_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComics_UserProfiles_UserId",
                table: "UserComics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_UserProfiles_UserId",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserComics_UserId",
                table: "UserComics");

            migrationBuilder.DeleteData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "UserMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "UserComics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_UserProfileId",
                table: "UserMovies",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComics_UserProfileId",
                table: "UserComics",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComics_UserProfiles_UserProfileId",
                table: "UserComics",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_UserProfiles_UserProfileId",
                table: "UserMovies",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
