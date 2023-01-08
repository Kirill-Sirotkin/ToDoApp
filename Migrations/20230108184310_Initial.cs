using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(name: "_email", type: "text", nullable: false),
                    passwordHash = table.Column<string>(name: "_passwordHash", type: "text", nullable: false),
                    salt = table.Column<byte[]>(name: "_salt", type: "bytea", nullable: false),
                    createdTimestamp = table.Column<DateTimeOffset>(name: "_createdTimestamp", type: "timestamp with time zone", nullable: false),
                    updatedTimestamp = table.Column<DateTimeOffset>(name: "_updatedTimestamp", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(name: "_name", type: "text", nullable: false),
                    description = table.Column<string>(name: "_description", type: "text", nullable: true),
                    createdTimestamp = table.Column<DateTimeOffset>(name: "_createdTimestamp", type: "timestamp with time zone", nullable: false),
                    updatedTimestamp = table.Column<DateTimeOffset>(name: "_updatedTimestamp", type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(name: "_status", type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UserId",
                table: "ToDos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
