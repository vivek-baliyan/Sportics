﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Api.Entities.Match.Inning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BattingTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InningsNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BattingTeamId");

                    b.HasIndex("MatchId");

                    b.ToTable("Innings");
                });

            modelBuilder.Entity("Api.Entities.Match.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("MatchNo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Team1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Team2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TournamentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Api.Entities.Match.MatchPlayerStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BallsFaced")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fours")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Maidens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OversBowled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Runs")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RunsConceded")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sixes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wickets")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("MatchPlayerStatistics");
                });

            modelBuilder.Entity("Api.Entities.Match.MatchResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinningMarginRuns")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinningMarginWickets")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinningTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinningTeamInningId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.HasIndex("WinningTeamId");

                    b.HasIndex("WinningTeamInningId");

                    b.ToTable("MatchResults");
                });

            modelBuilder.Entity("Api.Entities.Match.Scorecard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BallsFaced")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fours")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InningId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Maidens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("OversBowled")
                        .HasColumnType("REAL");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Runs")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RunsConceded")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sixes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wickets")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InningId");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Scorecards");
                });

            modelBuilder.Entity("Api.Entities.Match.Toss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TossDecision")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinningTeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId")
                        .IsUnique();

                    b.HasIndex("WinningTeamId");

                    b.ToTable("Tosses");
                });

            modelBuilder.Entity("Api.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Api.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Coach")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Api.Entities.Tournament.TeamStanding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchesLost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchesPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchesTied")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchesWon")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NoResults")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TournamentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TeamStandings");
                });

            modelBuilder.Entity("Api.Entities.Tournament.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TournamentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Api.Entities.Match.Inning", b =>
                {
                    b.HasOne("Api.Entities.Team", "BattingTeam")
                        .WithMany()
                        .HasForeignKey("BattingTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Match.Match", "Match")
                        .WithMany("Innings")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BattingTeam");

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Api.Entities.Match.Match", b =>
                {
                    b.HasOne("Api.Entities.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Tournament.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team1");

                    b.Navigation("Team2");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Api.Entities.Match.MatchPlayerStatistic", b =>
                {
                    b.HasOne("Api.Entities.Match.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Player", "Player")
                        .WithMany("MatchPlayerStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Api.Entities.Match.MatchResult", b =>
                {
                    b.HasOne("Api.Entities.Match.Match", "Match")
                        .WithOne("Result")
                        .HasForeignKey("Api.Entities.Match.MatchResult", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Team", "WinningTeam")
                        .WithMany()
                        .HasForeignKey("WinningTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Match.Inning", "WinningTeamInning")
                        .WithMany()
                        .HasForeignKey("WinningTeamInningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("WinningTeam");

                    b.Navigation("WinningTeamInning");
                });

            modelBuilder.Entity("Api.Entities.Match.Scorecard", b =>
                {
                    b.HasOne("Api.Entities.Match.Inning", null)
                        .WithMany("Scorecard")
                        .HasForeignKey("InningId");

                    b.HasOne("Api.Entities.Match.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Api.Entities.Match.Toss", b =>
                {
                    b.HasOne("Api.Entities.Match.Match", "Match")
                        .WithOne("Toss")
                        .HasForeignKey("Api.Entities.Match.Toss", "MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Team", "WinningTeam")
                        .WithMany()
                        .HasForeignKey("WinningTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("WinningTeam");
                });

            modelBuilder.Entity("Api.Entities.Player", b =>
                {
                    b.HasOne("Api.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Api.Entities.Tournament.TeamStanding", b =>
                {
                    b.HasOne("Api.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Tournament.Tournament", "Tournament")
                        .WithMany("TeamStandings")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("Api.Entities.Match.Inning", b =>
                {
                    b.Navigation("Scorecard");
                });

            modelBuilder.Entity("Api.Entities.Match.Match", b =>
                {
                    b.Navigation("Innings");

                    b.Navigation("Result");

                    b.Navigation("Toss");
                });

            modelBuilder.Entity("Api.Entities.Player", b =>
                {
                    b.Navigation("MatchPlayerStatistics");
                });

            modelBuilder.Entity("Api.Entities.Team", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Api.Entities.Tournament.Tournament", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("TeamStandings");
                });
#pragma warning restore 612, 618
        }
    }
}
