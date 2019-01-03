using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Data.Dal.Migrations
{
    public partial class AddQuizIdToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quiz_QuizId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402b9b75-2f6d-4f40-8d59-26ef95c51744",
                column: "ConcurrencyStamp",
                value: "0517a9be-52fe-42a3-b3bd-814c1f5d3675");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0dabe9b-f8b7-48f4-b74a-6a6671130765",
                column: "ConcurrencyStamp",
                value: "32834587-8707-4f6f-b84e-8682e3eb3b75");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "009dc675-6328-4f92-b206-b3311908e306",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e5e7e30-d6e0-4fe9-8667-892efe7cb6a5", "AQAAAAEAACcQAAAAEMFQaqRPjv5+nHQxlfO6nXF/iie0e1v/xTfGofEKP+vglnxiJSikCGF8x+L+t85+gA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5713835-f70b-4fbb-ab7e-6e6320bb59ee",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3697f0dd-8697-4f91-b570-8935f550e577", "AQAAAAEAACcQAAAAEN9ej5zGXsqozK72G32ErmJyfxVFOodyGiPTd60vKMSPnMDZCuTlhKKE1Yr8xq6t+w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quiz_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quiz_QuizId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "QuizId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quiz_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
