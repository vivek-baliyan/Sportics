namespace Api.Dtos;

public class PlayerDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int TeamId { get; set; }
    public string? TeamName { get; set; }
}