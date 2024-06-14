using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reviewer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDiscriminatorToPersons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Actors_ActorId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Directors_DirectorId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirector_Directors_DirectorId",
                table: "MovieDirector");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_ActorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Actors_ActorId",
                table: "Role");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directors",
                table: "Directors");

            migrationBuilder.RenameTable(
                name: "Directors",
                newName: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Name",
                table: "Persons",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Persons_ActorId",
                table: "Genres",
                column: "ActorId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Persons_DirectorId",
                table: "Genres",
                column: "DirectorId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirector_Persons_DirectorId",
                table: "MovieDirector",
                column: "DirectorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Persons_ActorId",
                table: "Movies",
                column: "ActorId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Persons_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Persons_ActorId",
                table: "Role",
                column: "ActorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Persons_ActorId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Persons_DirectorId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDirector_Persons_DirectorId",
                table: "MovieDirector");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Persons_ActorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Persons_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Persons_ActorId",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_Name",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Directors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directors",
                table: "Directors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Actors_ActorId",
                table: "Genres",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Directors_DirectorId",
                table: "Genres",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDirector_Directors_DirectorId",
                table: "MovieDirector",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_ActorId",
                table: "Movies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Actors_ActorId",
                table: "Role",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
