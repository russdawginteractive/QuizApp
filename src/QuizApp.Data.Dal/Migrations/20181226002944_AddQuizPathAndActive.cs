using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Data.Dal.Migrations
{
    public partial class AddQuizPathAndActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Quiz",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PathToQuizReference",
                table: "Quiz",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402b9b75-2f6d-4f40-8d59-26ef95c51744",
                column: "ConcurrencyStamp",
                value: "3afa03dd-0671-4ab1-91fb-9d293b3bc104");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0dabe9b-f8b7-48f4-b74a-6a6671130765",
                column: "ConcurrencyStamp",
                value: "022f9848-0088-40e6-ad63-fc7c548a2e8a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "009dc675-6328-4f92-b206-b3311908e306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fdc23e0b-2eb6-4d6a-9e64-dc417517d973", "AQAAAAEAACcQAAAAEB6MOFv//EXBF8klgcSPyAvR5K9zbBer1t+WmorvqTnIDpVPGUdN6kG7oDfDGiHzIA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5713835-f70b-4fbb-ab7e-6e6320bb59ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99d7b7dc-c212-477c-84f7-5a57fa2d0efd", "AQAAAAEAACcQAAAAEH3KZnjY9JQFkDP7cULL9h/U2cFDqHwpvqOnec0UUZVeOsocx2y8vlbwzjl20dN+7g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "PathToQuizReference",
                table: "Quiz");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402b9b75-2f6d-4f40-8d59-26ef95c51744",
                column: "ConcurrencyStamp",
                value: "3d5ffb6e-cd35-419f-8395-a7337ea4a0d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0dabe9b-f8b7-48f4-b74a-6a6671130765",
                column: "ConcurrencyStamp",
                value: "02c49f2d-9f52-4aec-acc5-9bbf810ea581");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "009dc675-6328-4f92-b206-b3311908e306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ecaffbce-be75-40a9-83cc-3e261b758bbf", "AQAAAAEAACcQAAAAEMJV/zX/jcBXZy92JW1e6OFmBf6WxmZ9sEi1WyUM+C/cMkTAnr9BwfVG3FIiEAgWwg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5713835-f70b-4fbb-ab7e-6e6320bb59ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "463cd7b5-aba5-4769-a543-10285944ee5b", "AQAAAAEAACcQAAAAENQiEqpQ577mJUuAWyn9a46O8aqJpx9pOJ9RJzHeIl5LF/Frt7h1N3e+Ep5SOJ3OAA==" });
        }
    }
}
