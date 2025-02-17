﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Reviewer.Infrastructure;

#nullable disable

namespace Reviewer.Infrastructure.Migrations
{
    [DbContext(typeof(ReviewerDbContext))]
    [Migration("20240605165424_ChangedRolesConfiguration")]
    partial class ChangedRolesConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ActorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DirectorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("DirectorId")
                        .HasColumnType("uuid");

                    b.Property<TimeOnly>("Duration")
                        .HasColumnType("time without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Storyline")
                        .HasColumnType("text");

                    b.Property<string>("Tagline")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.MovieCountry", b =>
                {
                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.HasKey("CountryId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCountry");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.MovieDirector", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DirectorId")
                        .HasColumnType("uuid");

                    b.HasKey("MovieId", "DirectorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("MovieDirector");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.MovieGenre", b =>
                {
                    b.Property<Guid>("GenreId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.MovieLanguage", b =>
                {
                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.HasKey("LanguageId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieLanguage");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Persons", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("MovieId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Actor", b =>
                {
                    b.HasBaseType("Reviewer.Infrastructure.Models.Person");

                    b.HasDiscriminator().HasValue("Actor");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Director", b =>
                {
                    b.HasBaseType("Reviewer.Infrastructure.Models.Person");

                    b.HasDiscriminator().HasValue("Director");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Genre", b =>
                {
                    b.HasOne("Reviewer.Infrastructure.Models.Actor", null)
                        .WithMany("Genres")
                        .HasForeignKey("ActorId");

                    b.HasOne("Reviewer.Infrastructure.Models.Director", null)
                        .WithMany("Genres")
                        .HasForeignKey("DirectorId");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Movie", b =>
                {
                    b.HasOne("Reviewer.Infrastructure.Models.Director", null)
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.MovieCountry", b =>
                {
                    b.HasOne("Reviewer.Infrastructure.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reviewer.Infrastructure.Models.Movie", "Movie")
                        .WithMany("Countries")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.MovieDirector", b =>
                {
                    b.HasOne("Reviewer.Infrastructure.Models.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reviewer.Infrastructure.Models.Movie", "Movie")
                        .WithMany("Directors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.MovieGenre", b =>
                {
                    b.HasOne("Reviewer.Infrastructure.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reviewer.Infrastructure.Models.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.MovieLanguage", b =>
                {
                    b.HasOne("Reviewer.Infrastructure.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reviewer.Infrastructure.Models.Movie", "Movie")
                        .WithMany("Languages")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Role", b =>
                {
                    b.HasOne("Reviewer.Infrastructure.Models.Actor", "Actor")
                        .WithMany("Roles")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reviewer.Infrastructure.Models.Movie", "Movie")
                        .WithMany("Roles")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Movie", b =>
                {
                    b.Navigation("Countries");

                    b.Navigation("Directors");

                    b.Navigation("Genres");

                    b.Navigation("Languages");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Actor", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Reviewer.Infrastructure.Models.Director", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
