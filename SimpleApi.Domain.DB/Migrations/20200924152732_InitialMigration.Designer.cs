﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SimpleApi.Domain.DB.Configuration;

namespace SimpleApi.Domain.DB.Migrations
{
    [DbContext(typeof(StorageContext))]
    [Migration("20200924152732_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SimpleApi.Domain.Model.NewsItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FullDescription")
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("NewsItems");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Author = "Greatest journalist ever",
                            Created = new DateTime(2020, 9, 24, 18, 27, 31, 560, DateTimeKind.Local).AddTicks(7542),
                            FullDescription = "Old lady from village 'Milk farm' found a huge bomb instead of eggplant!",
                            ShortDescription = "Old lady from village 'Milk farm' found a huge bomb instead of eggplant!",
                            SubscriptionId = new Guid("00000000-aaaa-0000-0000-000000000000"),
                            Title = "First news",
                            Updated = new DateTime(2020, 9, 24, 18, 27, 31, 560, DateTimeKind.Local).AddTicks(7542),
                            UpdatedBy = new Guid("c9a305fc-cd0a-4f98-b381-954dab0ba6f1")
                        },
                        new
                        {
                            Id = 2L,
                            Author = "Only for money author",
                            Created = new DateTime(2020, 9, 24, 18, 27, 31, 560, DateTimeKind.Local).AddTicks(7542),
                            FullDescription = "Great news!",
                            ShortDescription = "Great news!",
                            SubscriptionId = new Guid("00000000-bbbb-0000-0000-000000000000"),
                            Title = "Paid news",
                            Updated = new DateTime(2020, 9, 24, 18, 27, 31, 560, DateTimeKind.Local).AddTicks(7542),
                            UpdatedBy = new Guid("19eee026-44cc-4d5a-a5ba-16a07abf069e")
                        });
                });

            modelBuilder.Entity("SimpleApi.Domain.Model.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-aaaa-0000-0000-000000000000"),
                            Name = "Free subscription",
                            Price = 0m
                        },
                        new
                        {
                            Id = new Guid("00000000-bbbb-0000-0000-000000000000"),
                            Name = "Full subscription",
                            Price = 100m
                        });
                });

            modelBuilder.Entity("SimpleApi.Domain.Model.NewsItem", b =>
                {
                    b.HasOne("SimpleApi.Domain.Model.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}