using Api.Entities.Match;

namespace Api.Entities;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int TeamId { get; set; }
    public virtual Team? Team { get; set; }
    public virtual ICollection<MatchPlayerStatistic>? MatchPlayerStatistics { get; set; }
}