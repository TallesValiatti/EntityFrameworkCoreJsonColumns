﻿// <auto-generated />
using System;
using EntityFrameworkCoreJsonColumns.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCoreJsonColumns.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231003212709_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkCoreJsonColumns.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EntityFrameworkCoreJsonColumns.Models.Book", b =>
                {
                    b.OwnsOne("EntityFrameworkCoreJsonColumns.Models.Details", "Details", b1 =>
                        {
                            b1.Property<Guid>("BookId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("BookId");

                            b1.ToTable("Books");

                            b1.ToJson("Details");

                            b1.WithOwner()
                                .HasForeignKey("BookId");

                            b1.OwnsMany("EntityFrameworkCoreJsonColumns.Models.Tag", "Tags", b2 =>
                                {
                                    b2.Property<Guid>("DetailsBookId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<string>("Key")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.HasKey("DetailsBookId", "Id");

                                    b2.ToTable("Books");

                                    b2.WithOwner()
                                        .HasForeignKey("DetailsBookId");
                                });

                            b1.Navigation("Tags");
                        });

                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
