﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sportics.Api.Data;

#nullable disable

namespace Sportics.Api.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221224120935_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("Sportics.Api.Entities.Match.InningPlayerStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BallsPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BattingPosition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CacthesTaken")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchInningId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("OversBowled")
                        .HasColumnType("REAL");

                    b.Property<int>("RunsScored")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WicketsTaken")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchInningId");

                    b.ToTable("InningPlayerStats");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Match.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManOfMatch")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Match.MatchInning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InnningNo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RunsScored")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WicketsFallen")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("MatchInnings");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Match.MatchTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MatchWon")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TossWon")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("MatchTeams");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Match.InningPlayerStats", b =>
                {
                    b.HasOne("Sportics.Api.Entities.Match.MatchInning", null)
                        .WithMany("InningPlayerStats")
                        .HasForeignKey("MatchInningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sportics.Api.Entities.Match.MatchInning", b =>
                {
                    b.HasOne("Sportics.Api.Entities.Match.Match", "Match")
                        .WithMany("Innings")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Match.MatchTeam", b =>
                {
                    b.HasOne("Sportics.Api.Entities.Match.Match", "Match")
                        .WithMany("Teams")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sportics.Api.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Player", b =>
                {
                    b.HasOne("Sportics.Api.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Match.Match", b =>
                {
                    b.Navigation("Innings");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Sportics.Api.Entities.Match.MatchInning", b =>
                {
                    b.Navigation("InningPlayerStats");
                });
#pragma warning restore 612, 618
        }
    }
}
