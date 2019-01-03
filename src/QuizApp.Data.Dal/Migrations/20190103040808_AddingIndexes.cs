using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Data.Dal.Migrations
{
    public partial class AddingIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Quiz",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Choice",
                table: "Answers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402b9b75-2f6d-4f40-8d59-26ef95c51744",
                column: "ConcurrencyStamp",
                value: "4925ef11-daeb-488a-b52a-e7156506a6cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0dabe9b-f8b7-48f4-b74a-6a6671130765",
                column: "ConcurrencyStamp",
                value: "0605d53d-441d-456d-88d0-757a6a7427ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "009dc675-6328-4f92-b206-b3311908e306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb73e6f2-af0c-4a33-8cf8-b13a418b3f31", "AQAAAAEAACcQAAAAEDnC1Amp8ycZ5lgd4GtZL1VgoSbZXiQz3QCq8QK4f677ebCaSv1SOw9I/MX5Ig8ssg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5713835-f70b-4fbb-ab7e-6e6320bb59ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d08eebb7-eb14-43c2-b5fa-6a830a1a239d", "AQAAAAEAACcQAAAAEDm9Tb+BtBxFjAxyqa4saT1YmHPlVOPs3Lhqdc4mhr+ueR5u3ry8Soard1R5vV9zRg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_EventId",
                table: "Quiz",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_Title",
                table: "Quiz",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_Title",
                table: "Questions",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_Choice",
                table: "Answers",
                column: "Choice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quiz_EventId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_Title",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Questions_Title",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Answers_Choice",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Quiz",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Choice",
                table: "Answers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402b9b75-2f6d-4f40-8d59-26ef95c51744",
                column: "ConcurrencyStamp",
                value: "181472d2-0206-444c-8f46-bccb52e32d7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0dabe9b-f8b7-48f4-b74a-6a6671130765",
                column: "ConcurrencyStamp",
                value: "b6c78664-a268-46f7-90d7-d5f818a8d0c2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "009dc675-6328-4f92-b206-b3311908e306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2480f79e-0409-4335-8a7e-79305585af3e", "AQAAAAEAACcQAAAAECe+snrGN3ZjVNllOi2VxQauE7dlvIr4xCa+34tVYPGQ+At5gp7Rko2WFRzfhJj5/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5713835-f70b-4fbb-ab7e-6e6320bb59ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab6fc3d2-3fad-41fb-8dcf-d4c50986e84c", "AQAAAAEAACcQAAAAELsF4mjvwCj5ioDtDApARojiLbsIrRt1bdiiOuo0/Z2LKoqQsmlS4SrtQR+Yc243SQ==" });
        }
    }
}
