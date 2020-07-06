// This file isn't generated, but this comment is necessary to exclude it from StyleCop analysis. // <auto-generated/>
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevAdventCalendarCompetition.Repository.Migrations
{
    public partial class CorrectId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCorrectAnswers_AspNetUsers_UserId",
                table: "TestCorrectAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestWrongAnswers_AspNetUsers_UserId",
                table: "TestWrongAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestWrongAnswers",
                table: "TestWrongAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCorrectAnswers",
                table: "TestCorrectAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TestWrongAnswers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TestWrongAnswers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TestCorrectAnswers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TestCorrectAnswers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestWrongAnswers",
                table: "TestWrongAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCorrectAnswers",
                table: "TestCorrectAnswers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TestWrongAnswers_TestId",
                table: "TestWrongAnswers",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestCorrectAnswers_TestId",
                table: "TestCorrectAnswers",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCorrectAnswers_AspNetUsers_UserId",
                table: "TestCorrectAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestWrongAnswers_AspNetUsers_UserId",
                table: "TestWrongAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCorrectAnswers_AspNetUsers_UserId",
                table: "TestCorrectAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestWrongAnswers_AspNetUsers_UserId",
                table: "TestWrongAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestWrongAnswers",
                table: "TestWrongAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TestWrongAnswers_TestId",
                table: "TestWrongAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestCorrectAnswers",
                table: "TestCorrectAnswers");

            migrationBuilder.DropIndex(
                name: "IX_TestCorrectAnswers_TestId",
                table: "TestCorrectAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TestWrongAnswers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TestWrongAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TestCorrectAnswers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TestCorrectAnswers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestWrongAnswers",
                table: "TestWrongAnswers",
                columns: new[] { "TestId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestCorrectAnswers",
                table: "TestCorrectAnswers",
                columns: new[] { "TestId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TestCorrectAnswers_AspNetUsers_UserId",
                table: "TestCorrectAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestWrongAnswers_AspNetUsers_UserId",
                table: "TestWrongAnswers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
