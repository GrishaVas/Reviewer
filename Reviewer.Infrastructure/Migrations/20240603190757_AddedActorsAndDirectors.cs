using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reviewer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedActorsAndDirectors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Movies_MovieId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Persons_PersonId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "MoviePerson");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PersonId",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Role",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_MovieId",
                table: "Role",
                newName: "IX_Role_MovieId");

            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "Movies",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DirectorId",
                table: "Movies",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "Genres",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DirectorId",
                table: "Genres",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirector",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uuid", nullable: false),
                    DirectorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirector", x => new { x.MovieId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_MovieDirector_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirector_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ActorId",
                table: "Movies",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Name",
                table: "Movies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ActorId",
                table: "Genres",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_DirectorId",
                table: "Genres",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_ActorId",
                table: "Role",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirector_DirectorId",
                table: "MovieDirector",
                column: "DirectorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Movies_MovieId",
                table: "Role",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Actors_ActorId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Directors_DirectorId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_ActorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Actors_ActorId",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Movies_MovieId",
                table: "Role");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "MovieDirector");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ActorId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Name",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Genres_ActorId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_DirectorId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_ActorId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_Name",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Roles",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Role_MovieId",
                table: "Roles",
                newName: "IX_Roles_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SecondName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviePerson",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePerson", x => new { x.MovieId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_MoviePerson_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PersonId",
                table: "Roles",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviePerson_PersonId",
                table: "MoviePerson",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Movies_MovieId",
                table: "Roles",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Persons_PersonId",
                table: "Roles",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
