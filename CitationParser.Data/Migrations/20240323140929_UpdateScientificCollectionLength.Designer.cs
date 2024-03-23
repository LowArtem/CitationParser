﻿// <auto-generated />
using System;
using CitationParser.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitationParser.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240323140929_UpdateScientificCollectionLength")]
    partial class UpdateScientificCollectionLength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("AuthorPublication", b =>
                {
                    b.Property<int>("IdAuthors")
                        .HasColumnType("int");

                    b.Property<int>("IdPublications")
                        .HasColumnType("int");

                    b.HasKey("IdAuthors", "IdPublications");

                    b.HasIndex("IdPublications");

                    b.ToTable("AuthorPublication");
                });

            modelBuilder.Entity("CitationParser.Data.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("authors");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("CitationParser.Data.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("country");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("cities");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("CitationParser.Data.Model.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("universities");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("CitationParser.Data.Model.Editor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("editors");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("CitationParser.Data.Model.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArticleNumber")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("articleNumber");

                    b.Property<string>("CountOfPages")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("numberOfPages");

                    b.Property<string>("Country")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("country");

                    b.Property<string>("DataStorage")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("dataStorage");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DateIntroduction")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("dateIntroduction");

                    b.Property<string>("DateOfRegistration")
                        .HasColumnType("longtext")
                        .HasColumnName("dateOfRegistration");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Doi")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DOI");

                    b.Property<string>("Information")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("information");

                    b.Property<string>("InformationAboutPublication")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("informationAboutPublication");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Language")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("language");

                    b.Property<string>("Number")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("number");

                    b.Property<int?>("NumberOfVolumes")
                        .HasColumnType("int")
                        .HasColumnName("numberOfVolumes");

                    b.Property<string>("PageNumbers")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("pageNumbers");

                    b.Property<string>("ParallelSourceTitle")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("parallelSourceTitle");

                    b.Property<string>("ParallelTitle")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("parallelTitle");

                    b.Property<string>("PlaceOfRegistration")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("placeOfRegistration");

                    b.Property<string>("PublishingHouse")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("publishingHouse");

                    b.Property<string>("RegistrationNumber")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("registrationNumber");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("title");

                    b.Property<string>("TitleOfSource")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("titleOfSource");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("type_id");

                    b.Property<string>("Url")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("URL");

                    b.Property<string>("VolumeNumber")
                        .HasColumnType("longtext")
                        .HasColumnName("volumeNumber");

                    b.Property<string>("Year")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TypeId" }, "FK_types_publications");

                    b.ToTable("publications");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("CitationParser.Data.Model.ScientificCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasMaxLength(350)
                        .HasColumnType("varchar(350)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("scientific_collections");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");
                });

            modelBuilder.Entity("CitationParser.Data.Model.TypesOfPublication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("types_of_publications");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8_general_ci");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6206),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6206),
                            IsDelete = false,
                            Name = "DepositedManuscript"
                        },
                        new
                        {
                            Id = 2,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6210),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6210),
                            IsDelete = false,
                            Name = "Certificate"
                        },
                        new
                        {
                            Id = 3,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6212),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6212),
                            IsDelete = false,
                            Name = "Monograph"
                        },
                        new
                        {
                            Id = 4,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6214),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6214),
                            IsDelete = false,
                            Name = "Other"
                        },
                        new
                        {
                            Id = 5,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6216),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6216),
                            IsDelete = false,
                            Name = "Patent"
                        },
                        new
                        {
                            Id = 6,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6218),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6218),
                            IsDelete = false,
                            Name = "Textbook"
                        },
                        new
                        {
                            Id = 7,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6220),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6220),
                            IsDelete = false,
                            Name = "ReportAbstracts"
                        },
                        new
                        {
                            Id = 8,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6222),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6222),
                            IsDelete = false,
                            Name = "StudyGuide"
                        },
                        new
                        {
                            Id = 9,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6224),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6224),
                            IsDelete = false,
                            Name = "StudyGuideWithStamp"
                        },
                        new
                        {
                            Id = 10,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6226),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6226),
                            IsDelete = false,
                            Name = "VstuMagazines"
                        },
                        new
                        {
                            Id = 11,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6228),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6228),
                            IsDelete = false,
                            Name = "VstuNews"
                        },
                        new
                        {
                            Id = 12,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6230),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6230),
                            IsDelete = false,
                            Name = "EducationalMethodicalComplex"
                        },
                        new
                        {
                            Id = 13,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6231),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6231),
                            IsDelete = false,
                            Name = "ForeignCollectionArticle"
                        },
                        new
                        {
                            Id = 14,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6233),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6233),
                            IsDelete = false,
                            Name = "ForeignMagazineArticle"
                        },
                        new
                        {
                            Id = 15,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6235),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6235),
                            IsDelete = false,
                            Name = "RussianCollectionArticle"
                        },
                        new
                        {
                            Id = 16,
                            DateCreate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6237),
                            DateUpdate = new DateTime(2024, 3, 23, 14, 9, 28, 942, DateTimeKind.Utc).AddTicks(6237),
                            IsDelete = false,
                            Name = "RussianMagazineArticle"
                        });
                });

            modelBuilder.Entity("CityPublication", b =>
                {
                    b.Property<int>("IdCities")
                        .HasColumnType("int");

                    b.Property<int>("IdPublications")
                        .HasColumnType("int");

                    b.HasKey("IdCities", "IdPublications");

                    b.HasIndex("IdPublications");

                    b.ToTable("CityPublication");
                });

            modelBuilder.Entity("CompanyPublication", b =>
                {
                    b.Property<int>("IdPublications")
                        .HasColumnType("int");

                    b.Property<int>("IdUniversities")
                        .HasColumnType("int");

                    b.HasKey("IdPublications", "IdUniversities");

                    b.HasIndex("IdUniversities");

                    b.ToTable("CompanyPublication");
                });

            modelBuilder.Entity("EditorPublication", b =>
                {
                    b.Property<int>("IdEditors")
                        .HasColumnType("int");

                    b.Property<int>("IdPublications")
                        .HasColumnType("int");

                    b.HasKey("IdEditors", "IdPublications");

                    b.HasIndex("IdPublications");

                    b.ToTable("EditorPublication");
                });

            modelBuilder.Entity("PublicationScientificCollection", b =>
                {
                    b.Property<int>("IdPublications")
                        .HasColumnType("int");

                    b.Property<int>("IdScientificCollection")
                        .HasColumnType("int");

                    b.HasKey("IdPublications", "IdScientificCollection");

                    b.HasIndex("IdScientificCollection");

                    b.ToTable("PublicationScientificCollection");
                });

            modelBuilder.Entity("AuthorPublication", b =>
                {
                    b.HasOne("CitationParser.Data.Model.Author", null)
                        .WithMany()
                        .HasForeignKey("IdAuthors")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitationParser.Data.Model.Publication", null)
                        .WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitationParser.Data.Model.Publication", b =>
                {
                    b.HasOne("CitationParser.Data.Model.TypesOfPublication", "Type")
                        .WithMany("Publications")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("FK_types_publications");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("CityPublication", b =>
                {
                    b.HasOne("CitationParser.Data.Model.City", null)
                        .WithMany()
                        .HasForeignKey("IdCities")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitationParser.Data.Model.Publication", null)
                        .WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyPublication", b =>
                {
                    b.HasOne("CitationParser.Data.Model.Publication", null)
                        .WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitationParser.Data.Model.Company", null)
                        .WithMany()
                        .HasForeignKey("IdUniversities")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EditorPublication", b =>
                {
                    b.HasOne("CitationParser.Data.Model.Editor", null)
                        .WithMany()
                        .HasForeignKey("IdEditors")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitationParser.Data.Model.Publication", null)
                        .WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PublicationScientificCollection", b =>
                {
                    b.HasOne("CitationParser.Data.Model.Publication", null)
                        .WithMany()
                        .HasForeignKey("IdPublications")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitationParser.Data.Model.ScientificCollection", null)
                        .WithMany()
                        .HasForeignKey("IdScientificCollection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitationParser.Data.Model.TypesOfPublication", b =>
                {
                    b.Navigation("Publications");
                });
#pragma warning restore 612, 618
        }
    }
}