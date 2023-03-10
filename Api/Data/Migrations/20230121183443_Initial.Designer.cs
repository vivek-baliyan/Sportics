// <auto-generated />
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230121183443_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Api.Entities.Match.InningPlayerStats", b =>
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

            modelBuilder.Entity("Api.Entities.Match.Match", b =>
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

            modelBuilder.Entity("Api.Entities.Match.MatchInning", b =>
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

            modelBuilder.Entity("Api.Entities.Match.MatchTeam", b =>
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

            modelBuilder.Entity("Api.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
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

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Api.Entities.Match.InningPlayerStats", b =>
                {
                    b.HasOne("Api.Entities.Match.MatchInning", null)
                        .WithMany("InningPlayerStats")
                        .HasForeignKey("MatchInningId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Entities.Match.MatchInning", b =>
                {
                    b.HasOne("Api.Entities.Match.Match", "Match")
                        .WithMany("Innings")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");
                });

            modelBuilder.Entity("Api.Entities.Match.MatchTeam", b =>
                {
                    b.HasOne("Api.Entities.Match.Match", "Match")
                        .WithMany("Teams")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Api.Entities.Player", b =>
                {
                    b.HasOne("Api.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Api.Entities.Match.Match", b =>
                {
                    b.Navigation("Innings");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Api.Entities.Match.MatchInning", b =>
                {
                    b.Navigation("InningPlayerStats");
                });
#pragma warning restore 612, 618
        }
    }
}
