using Microsoft.EntityFrameworkCore;
using Sportics.Api.Entities;
using Sportics.Api.Entities.Match;

namespace Sportics.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Team>? Teams { get; set; }
    public DbSet<Player>? Players { get; set; }
    public DbSet<Match>? Matches { get; set; }
    public DbSet<MatchTeam>? MatchTeams { get; set; }
    public DbSet<MatchInning>? MatchInnings { get; set; }
    public DbSet<InningPlayerStats>? InningPlayerStats { get; set; }
}