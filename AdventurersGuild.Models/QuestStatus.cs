using System.ComponentModel;

namespace AdventurersGuild.Models;

public enum QuestStatus
{
    [Description("Доступен")]
    Available,
    [Description("В процессе")]
    InProgress,
    [Description("Завершён")]
    Completed,
    [Description("Провален")]
    Failed
}