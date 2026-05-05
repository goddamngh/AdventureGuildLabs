using AdventurersGuild.Models;

namespace AdventurersGuild.Database.Abstract;

public class QuestFilter
{
    public string? SearchText { get; set; }
    public QuestStatus? Status { get; set; }
    public int? AdventurerId { get; set; }
}