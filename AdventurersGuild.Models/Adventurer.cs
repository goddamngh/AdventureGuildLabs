namespace AdventurersGuild.Models;

public class Adventurer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdventurerRank Rank { get; set; }
    public bool IsActive { get; set; }
    public ICollection<Quest> Quests { get; set; } = new List<Quest>();
}