﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Studio.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20241113133445_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Album", b =>
                {
                    b.Property<int>("AlbumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AlbumID"));

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("AlbumID");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("AlbumAuthor", b =>
                {
                    b.Property<int>("AlbumsAlbumID")
                        .HasColumnType("int");

                    b.Property<int>("AuthorsAuthorID")
                        .HasColumnType("int");

                    b.HasKey("AlbumsAlbumID", "AuthorsAuthorID");

                    b.HasIndex("AuthorsAuthorID");

                    b.ToTable("AlbumAuthor");
                });

            modelBuilder.Entity("Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("AuthorSong", b =>
                {
                    b.Property<int>("AuthorsAuthorID")
                        .HasColumnType("int");

                    b.Property<int>("SongsSongID")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorID", "SongsSongID");

                    b.HasIndex("SongsSongID");

                    b.ToTable("AuthorSong");
                });

            modelBuilder.Entity("Song", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("SongID"));

                    b.Property<int?>("AlbumID")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("SongID");

                    b.HasIndex("AlbumID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("SongUser", b =>
                {
                    b.Property<int>("OwnedSongsSongID")
                        .HasColumnType("int");

                    b.Property<int>("UsersWhoOwnUserID")
                        .HasColumnType("int");

                    b.HasKey("OwnedSongsSongID", "UsersWhoOwnUserID");

                    b.HasIndex("UsersWhoOwnUserID");

                    b.ToTable("SongUser");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Adrdess")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AlbumAuthor", b =>
                {
                    b.HasOne("Album", null)
                        .WithMany()
                        .HasForeignKey("AlbumsAlbumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthorSong", b =>
                {
                    b.HasOne("Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Song", null)
                        .WithMany()
                        .HasForeignKey("SongsSongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Song", b =>
                {
                    b.HasOne("Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumID");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("SongUser", b =>
                {
                    b.HasOne("Song", null)
                        .WithMany()
                        .HasForeignKey("OwnedSongsSongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", null)
                        .WithMany()
                        .HasForeignKey("UsersWhoOwnUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Album", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}