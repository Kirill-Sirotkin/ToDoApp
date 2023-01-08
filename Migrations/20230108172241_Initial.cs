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
                name: "_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(name: "_email", type: "nvarchar(max)", nullable: false),
                    passwordHash = table.Column<string>(name: "_passwordHash", type: "nvarchar(max)", nullable: false),
                    salt = table.Column<byte[]>(name: "_salt", type: "varbinary(max)", nullable: false),
                    createdTimestamp = table.Column<DateTimeOffset>(name: "_createdTimestamp", type: "datetimeoffset", nullable: false),
                    updatedTimestamp = table.Column<DateTimeOffset>(name: "_updatedTimestamp", type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_users");
        }
    }
}
