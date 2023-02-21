﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mission6.Models;

namespace mission6.Migrations
{
    [DbContext(typeof(movieContext))]
    [Migration("20230221191621_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("mission6.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Action/Adventure"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Romance"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Horror"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Thriller"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Documentary"
                        });
                });

            modelBuilder.Entity("mission6.Models.movieInput", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("moviesAdded");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CategoryId = 1,
                            Director = "George Lucas",
                            Edited = false,
                            Rating = "PG-13",
                            Title = "Star Wars III",
                            Year = 2001
                        },
                        new
                        {
                            MovieId = 2,
                            CategoryId = 1,
                            Director = "George Lucas",
                            Edited = false,
                            Rating = "PG",
                            Title = "Star Wars II",
                            Year = 1999
                        },
                        new
                        {
                            MovieId = 3,
                            CategoryId = 1,
                            Director = "George Lucas",
                            Edited = false,
                            Rating = "PG",
                            Title = "Star Wars I",
                            Year = 1998
                        });
                });

            modelBuilder.Entity("mission6.Models.movieInput", b =>
                {
                    b.HasOne("mission6.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}