using Microsoft.EntityFrameworkCore;
using Api.Entities;
using Api.Entities.Match;
using Api.Entities.Tournament;

namespace Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Team>? Teams { get; set; }
    public DbSet<Player>? Players { get; set; }
    public DbSet<Tournament>? Tournaments { get; set; }
    public DbSet<Match>? Matches { get; set; }
    public DbSet<Inning>? Innings { get; set; }
    public DbSet<MatchResult>? MatchResults { get; set; }
    public DbSet<Scorecard>? Scorecards { get; set; }
    public DbSet<Toss>? Tosses { get; set; }
    public DbSet<TossDecision>? TossDecisions { get; set; }
    public DbSet<MatchPlayerStatistic>? MatchPlayerStatistics { get; set; }
}