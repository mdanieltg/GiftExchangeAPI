﻿// <auto-generated />
using System;
using GiftExchange.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GiftExchange.DataAccess.Migrations
{
    [DbContext(typeof(GiftExchangeContext))]
    [Migration("20211111235551_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.Exchange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("HasStarted")
                        .HasColumnType("tinyint(1)");

                    b.Property<float?>("LowerBudgetLimit")
                        .HasColumnType("float");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<float?>("UpperBudgetLimit")
                        .HasColumnType("float");

                    b.Property<int>("Visibility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Exchanges");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.Gift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.InvitationLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExchangeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ExchangeId")
                        .IsUnique();

                    b.ToTable("InvitationLinks");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.LoginLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("LoginLinks");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExchangeId")
                        .HasColumnType("int");

                    b.Property<int?>("GivingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExchangeId");

                    b.HasIndex("GivingId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.Exchange", b =>
                {
                    b.HasOne("GiftExchange.DataAccess.Entities.User", "Organizer")
                        .WithMany("OwnedExchanges")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.Gift", b =>
                {
                    b.HasOne("GiftExchange.DataAccess.Entities.UserProfile", "UserProfile")
                        .WithMany("Gifts")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.InvitationLink", b =>
                {
                    b.HasOne("GiftExchange.DataAccess.Entities.Exchange", "Exchange")
                        .WithOne("InvitationLink")
                        .HasForeignKey("GiftExchange.DataAccess.Entities.InvitationLink", "ExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exchange");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.LoginLink", b =>
                {
                    b.HasOne("GiftExchange.DataAccess.Entities.User", "User")
                        .WithOne("LoginLink")
                        .HasForeignKey("GiftExchange.DataAccess.Entities.LoginLink", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.UserProfile", b =>
                {
                    b.HasOne("GiftExchange.DataAccess.Entities.Exchange", "Exchange")
                        .WithMany("Participants")
                        .HasForeignKey("ExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiftExchange.DataAccess.Entities.UserProfile", "Giving")
                        .WithMany()
                        .HasForeignKey("GivingId");

                    b.HasOne("GiftExchange.DataAccess.Entities.User", "User")
                        .WithMany("Profiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exchange");

                    b.Navigation("Giving");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.Exchange", b =>
                {
                    b.Navigation("InvitationLink");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.User", b =>
                {
                    b.Navigation("LoginLink");

                    b.Navigation("OwnedExchanges");

                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("GiftExchange.DataAccess.Entities.UserProfile", b =>
                {
                    b.Navigation("Gifts");
                });
#pragma warning restore 612, 618
        }
    }
}
