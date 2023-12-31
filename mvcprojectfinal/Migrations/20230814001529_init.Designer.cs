﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvcprojectfinal.Models;

#nullable disable

namespace mvcprojectfinal.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230814001529_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("mvcprojectfinal.Models.AppliacationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

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

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Booking", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("AppliacationUserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Visa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("totalPrice")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AppliacationUserID");

                    b.ToTable("booking");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "dahab.jpg",
                            Name = "dahab"
                        },
                        new
                        {
                            Id = 2,
                            Image = "alex.jpg",
                            Name = "Alex"
                        });
                });

            modelBuilder.Entity("mvcprojectfinal.Models.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HotelsID")
                        .HasColumnType("int");

                    b.Property<string>("applicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelsID");

                    b.HasIndex("applicationUserId");

                    b.ToTable("feedBacks");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Fun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsContainsAquaBark")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContainsBeach")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContainsDesco")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContaintsSwimmingPool")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHavingElevator")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHavingKidsArea")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHavingParking")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOpenBuffit")
                        .HasColumnType("bit");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("funs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsContainsAquaBark = true,
                            IsContainsBeach = false,
                            IsContainsDesco = true,
                            IsContaintsSwimmingPool = true,
                            IsHavingElevator = false,
                            IsHavingKidsArea = true,
                            IsHavingParking = true,
                            IsOpenBuffit = false,
                            Stars = 4
                        },
                        new
                        {
                            Id = 2,
                            IsContainsAquaBark = true,
                            IsContainsBeach = true,
                            IsContainsDesco = false,
                            IsContaintsSwimmingPool = true,
                            IsHavingElevator = true,
                            IsHavingKidsArea = false,
                            IsHavingParking = true,
                            IsOpenBuffit = false,
                            Stars = 5
                        });
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Hotels", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FunID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CityID");

                    b.HasIndex("FunID");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Images", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("HotelsId")
                        .HasColumnType("int");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("HotelsId");

                    b.ToTable("images");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHavingAirconditioning")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHavingTv")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("View")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HotelId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.RoomVisits", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("BokingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoomID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("check_in")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("check_out")
                        .HasColumnType("datetime2");

                    b.Property<int>("numberofnights")
                        .HasColumnType("int");

                    b.Property<int?>("subPrice")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BokingId");

                    b.HasIndex("RoomID");

                    b.ToTable("roomVisits");
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
                    b.HasOne("mvcprojectfinal.Models.AppliacationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("mvcprojectfinal.Models.AppliacationUser", null)
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

                    b.HasOne("mvcprojectfinal.Models.AppliacationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("mvcprojectfinal.Models.AppliacationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Booking", b =>
                {
                    b.HasOne("mvcprojectfinal.Models.AppliacationUser", "User")
                        .WithMany("booking")
                        .HasForeignKey("AppliacationUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.FeedBack", b =>
                {
                    b.HasOne("mvcprojectfinal.Models.Hotels", "Hotel")
                        .WithMany("feedBacks")
                        .HasForeignKey("HotelsID");

                    b.HasOne("mvcprojectfinal.Models.AppliacationUser", "applicationUser")
                        .WithMany("feedBacks")
                        .HasForeignKey("applicationUserId");

                    b.Navigation("Hotel");

                    b.Navigation("applicationUser");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Hotels", b =>
                {
                    b.HasOne("mvcprojectfinal.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mvcprojectfinal.Models.Fun", "Fun")
                        .WithMany("hotels")
                        .HasForeignKey("FunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Fun");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Images", b =>
                {
                    b.HasOne("mvcprojectfinal.Models.Hotels", "hotels")
                        .WithMany("images")
                        .HasForeignKey("HotelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotels");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Room", b =>
                {
                    b.HasOne("mvcprojectfinal.Models.Hotels", "hotels")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId");

                    b.Navigation("hotels");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.RoomVisits", b =>
                {
                    b.HasOne("mvcprojectfinal.Models.Booking", "booking")
                        .WithMany("roomVisits")
                        .HasForeignKey("BokingId");

                    b.HasOne("mvcprojectfinal.Models.Room", "Room")
                        .WithMany("onceReserved")
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");

                    b.Navigation("booking");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.AppliacationUser", b =>
                {
                    b.Navigation("booking");

                    b.Navigation("feedBacks");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Booking", b =>
                {
                    b.Navigation("roomVisits");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Fun", b =>
                {
                    b.Navigation("hotels");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Hotels", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("feedBacks");

                    b.Navigation("images");
                });

            modelBuilder.Entity("mvcprojectfinal.Models.Room", b =>
                {
                    b.Navigation("onceReserved");
                });
#pragma warning restore 612, 618
        }
    }
}
