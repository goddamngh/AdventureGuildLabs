using Microsoft.EntityFrameworkCore;

namespace AdventurersGuild.Database;

public static class GuildContextOptionsBuilder
{
    public static DbContextOptions<GuildContext> Build(string dataSource = "guild.db")
    {
        return new DbContextOptionsBuilder<GuildContext>()
            .UseSqlite($"Data Source={dataSource}")
            .Options;
    }
}