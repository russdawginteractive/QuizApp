using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizApp.Data.Dal.Migrations
{
    public partial class RequireAnswerChoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Choice",
                table: "Answers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Choice",
                table: "Answers",
                nullable: true,
                oldClrType: typeof(string));

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
        }
    }
}
