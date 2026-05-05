using Microsoft.EntityFrameworkCore.Design;

namespace AdventurersGuild.Database;

public class GuildContextFactory : IDesignTimeDbContextFactory<GuildContext>
{
    public GuildContext CreateDbContext(string[] args) =>
        new(GuildContextOptionsBuilder.Build());
}