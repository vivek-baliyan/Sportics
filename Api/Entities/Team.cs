namespace Api.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HomeCity { get; set; } = string.Empty;
    public string Coach { get; set; } = string.Empty;
    public virtual ICollection<Player>? Players { get; set; }
}