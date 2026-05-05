using AdventurersGuild.Models;

namespace AdventurersGuild.Database.Abstract;

public class AdventurerFilter
{
    public string? SearchText { get; set; }
    public AdventurerRank? Rank { get; set; }
}