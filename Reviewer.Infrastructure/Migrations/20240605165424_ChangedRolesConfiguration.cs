using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reviewer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRolesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Persons_ActorId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ActorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "Movies",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ActorId",
                table: "Movies",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Persons_ActorId",
                table: "Movies",
                column: "ActorId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
