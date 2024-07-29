﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bs_data;

#nullable disable

namespace bs_data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("bs_data.Entities.Author", b =>
                {
                    b.Property<long>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Code"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.HasKey("Code");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("bs_data.Entities.Book", b =>
                {
                    b.Property<long>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Code"));

                    b.Property<int>("Edition")
                        .HasColumnType("integer");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<int>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("integer");

                    b.HasKey("Code");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("bs_data.Entities.BookAuthor", b =>
                {
                    b.Property<long>("BookCode")
                        .HasColumnType("bigint");

                    b.Property<long>("AuthorCode")
                        .HasColumnType("bigint");

                    b.HasKey("BookCode", "AuthorCode");

                    b.HasIndex("AuthorCode");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("bs_data.Entities.BookPriceTable", b =>
                {
                    b.Property<long>("BookCode")
                        .HasColumnType("bigint");

                    b.Property<long>("PriceTableCode")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("BookCode", "PriceTableCode");

                    b.HasIndex("PriceTableCode");

                    b.ToTable("BookPriceTable");
                });

            modelBuilder.Entity("bs_data.Entities.BookSubject", b =>
                {
                    b.Property<long>("BookCode")
                        .HasColumnType("bigint");

                    b.Property<long>("SubjectCode")
                        .HasColumnType("bigint");

                    b.HasKey("BookCode", "SubjectCode");

                    b.HasIndex("SubjectCode");

                    b.ToTable("BookSubject");
                });

            modelBuilder.Entity("bs_data.Entities.PriceTable", b =>
                {
                    b.Property<long>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Code"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Code");

                    b.ToTable("PriceTable");
                });

            modelBuilder.Entity("bs_data.Entities.Subject", b =>
                {
                    b.Property<long>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Code"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Code");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("bs_data.Entities.BookAuthor", b =>
                {
                    b.HasOne("bs_data.Entities.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bs_data.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("bs_data.Entities.BookPriceTable", b =>
                {
                    b.HasOne("bs_data.Entities.Book", "Book")
                        .WithMany("BookPriceTables")
                        .HasForeignKey("BookCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bs_data.Entities.PriceTable", "PriceTable")
                        .WithMany("BookPriceTables")
                        .HasForeignKey("PriceTableCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("PriceTable");
                });

            modelBuilder.Entity("bs_data.Entities.BookSubject", b =>
                {
                    b.HasOne("bs_data.Entities.Book", "Book")
                        .WithMany("BookSubjects")
                        .HasForeignKey("BookCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bs_data.Entities.Subject", "Subject")
                        .WithMany("BookSubjects")
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("bs_data.Entities.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("bs_data.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookPriceTables");

                    b.Navigation("BookSubjects");
                });

            modelBuilder.Entity("bs_data.Entities.PriceTable", b =>
                {
                    b.Navigation("BookPriceTables");
                });

            modelBuilder.Entity("bs_data.Entities.Subject", b =>
                {
                    b.Navigation("BookSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
