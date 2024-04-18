﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shoe4U.Data;

#nullable disable

namespace Shoe4U.Data.Migrations
{
    [DbContext(typeof(Shoe4UDbContext))]
    [Migration("20240418063417_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "73c65cbf-b488-4648-a6e0-559cace3a694",
                            ConcurrencyStamp = "73c65cbf-b488-4648-a6e0-559cace3a694",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "a8067a00-432d-4815-a109-d7c5e51152aa",
                            RoleId = "73c65cbf-b488-4648-a6e0-559cace3a694"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Shoe4U.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Зелените ботуши налични ли са?",
                            Email = "ivan.petrov@gmail.com",
                            Name = "Иван Петров",
                            Subject = "Запитване"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Бежавите мокасини налични ли са 37 номер?",
                            Email = "georgi.angelov@gmail.com",
                            Name = "Георги Ангелов",
                            Subject = "Размер на мокасините"
                        });
                });

            modelBuilder.Entity("Shoe4U.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ул. \"Сан Стефано\" 1",
                            PhoneNumber = "+359874526871",
                            TotalSum = 133.98m,
                            UserId = "ab73d78b-5c5d-4ab8-8d29-f6c8702c1d6b"
                        },
                        new
                        {
                            Id = 2,
                            Address = "ул. \"Княз Александър Батенберг\" 34",
                            PhoneNumber = "+359878526011",
                            TotalSum = 47.99m,
                            UserId = "ab73d78b-5c5d-4ab8-8d29-f6c8702c1d6b"
                        },
                        new
                        {
                            Id = 3,
                            Address = "ул. \"Опълченска\" 21",
                            PhoneNumber = "+359874596507",
                            TotalSum = 85.99m,
                            UserId = "a8067a00-432d-4815-a109-d7c5e51152aa"
                        });
                });

            modelBuilder.Entity("Shoe4U.Data.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            OrderId = 3,
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("Shoe4U.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Adidas",
                            Category = 1,
                            Color = "Зелен",
                            CreatedOn = new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Зимни ботуши, идеални за студените месеци, с водоустойчива повърхност и топла подплата. Стилен дизайн, подходящ за всекидневието и разнообразни поводи. Издръжливи материали и удобна подметка за сигурност на различни повърхности. Насладете се на комфорт и топлина през зимата с тези модерни ботуши.",
                            ImageUrl = "http://res.cloudinary.com/dthtmmyo8/image/upload/v1713120403/btu4yldkeb0h7qeobksc.jpg",
                            IsDeleted = false,
                            Material = "Велур",
                            Name = "Зимни ботуши",
                            Price = 85.99m,
                            Quantity = 3,
                            Size = "43"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Tendenz",
                            Category = 2,
                            Color = "Розово и бяло",
                            CreatedOn = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Мокасини с универсален стил, подходящи за всички сезони. Изработени от висококачествени материали, които осигуряват комфорт и издръжливост. Лек и гъвкав дизайн за удобство при носене през цялата година. Изберете мокасините за ежедневието си с увереност в стил и удобство.",
                            ImageUrl = "http://res.cloudinary.com/dthtmmyo8/image/upload/v1713124891/pj6qwgbm7ldvi6nox00b.jpg",
                            IsDeleted = false,
                            Material = "Велур",
                            Name = "Мокасини",
                            Price = 47.99m,
                            Quantity = 1,
                            Size = "37"
                        });
                });

            modelBuilder.Entity("Shoe4U.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Зимните ботуши са идеалният избор за студените дни! Удобни, топли и водоустойчиви - точно както обещават. Дизайнът им е стилен и мога да ги комбинирам с всякакви облекла. Супер съм доволен от покупката си!",
                            CreatedOn = new DateTime(2024, 5, 10, 21, 19, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 1,
                            UserId = "ab73d78b-5c5d-4ab8-8d29-f6c8702c1d6b"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Зимните ботуши са моят спасител през студените месеци! Не само че са топли и удобни, но и изглеждат страхотно. Водоустойчивата повърхност наистина работи и ме уверява, че няма да ми стане студ нито на дъждовен ден. Със сигурност ще ги препоръчам на приятелите си!",
                            CreatedOn = new DateTime(2024, 5, 15, 15, 23, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 1,
                            UserId = "a8067a00-432d-4815-a109-d7c5e51152aa"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Мокасините са просто невероятни! Нося ги всеки ден и се чувствам толкова комфортно в тях. Изработени са от качествени материали и изглеждат много стилно. Бих ги препоръчал на всеки, който търси удобство и елегантност в едно.",
                            CreatedOn = new DateTime(2024, 5, 17, 7, 41, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 2,
                            UserId = "ab73d78b-5c5d-4ab8-8d29-f6c8702c1d6b"
                        },
                        new
                        {
                            Id = 4,
                            Content = "Мокасините са моят нов любим чифт обувки! Невероятно са удобни и меки, като втора кожа. Подходящи за носене през цялата година, те са перфектни за всекидневна употреба. Дизайнът им е класически, но все пак много стилен. Препоръчвам ги на всеки, който цени комфорта и качеството.",
                            CreatedOn = new DateTime(2024, 5, 19, 12, 37, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 2,
                            UserId = "a8067a00-432d-4815-a109-d7c5e51152aa"
                        });
                });

            modelBuilder.Entity("Shoe4U.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Basket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a8067a00-432d-4815-a109-d7c5e51152aa",
                            AccessFailedCount = 0,
                            Basket = "1",
                            ConcurrencyStamp = "be98e1b3-c930-48cf-a858-e08fc224c058",
                            Email = "admin@shoe4u.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Иван Петров",
                            NormalizedEmail = "ADMIN@SHOE4U.COM",
                            NormalizedUserName = "ADMIN@SHOE4U.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJ2cpYEXlRin9ovmz0OVkcol0GmuzxZuYKLf1gfo0clBN/a7YM4sR8BdCaVzw6OArA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "372fc3e2-dc36-4b29-98b5-99abed120b7c",
                            TwoFactorEnabled = false,
                            UserName = "admin@shoe4u.com"
                        },
                        new
                        {
                            Id = "ab73d78b-5c5d-4ab8-8d29-f6c8702c1d6b",
                            AccessFailedCount = 0,
                            Basket = "1; 2",
                            ConcurrencyStamp = "218b29f8-e369-42a2-95a9-e2901df27356",
                            Email = "user@shoe4u.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            Name = "Петър Георгиев",
                            NormalizedEmail = "USER@SHOE4U.COM",
                            NormalizedUserName = "USER@SHOE4U.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOHUFjMN4zpR2xdvIUHf/xleiqXgFwKMP6962bcRg30xBgaxpPQvVZoKbh+AwE3qWg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5f427a57-6355-47ae-a846-c4ac803a7857",
                            TwoFactorEnabled = false,
                            UserName = "user@shoe4u.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Shoe4U.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Shoe4U.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoe4U.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Shoe4U.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shoe4U.Data.Models.Order", b =>
                {
                    b.HasOne("Shoe4U.Data.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shoe4U.Data.Models.OrderProduct", b =>
                {
                    b.HasOne("Shoe4U.Data.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoe4U.Data.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shoe4U.Data.Models.Review", b =>
                {
                    b.HasOne("Shoe4U.Data.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shoe4U.Data.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shoe4U.Data.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Shoe4U.Data.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Shoe4U.Data.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}