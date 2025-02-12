using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordHashToUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "ProfileImage" },
                values: new object[] { "91d490Jb5NsDadCa83psK5qD3qDlPnvVdBLksGDmB/c=", "https://i.pinimg.com/originals/dd/6e/03/dd6e032795a2b5c9c148fd0db0f88af3.jpg" });

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "91d490Jb5NsDadCa83psK5qD3qDlPnvVdBLksGDmB/c=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProfileImage",
                value: "https://ca.slack-edge.com/T6G3NJMK5-U02S94DBXLP-d199360ebd76-512");
        }
    }
}
