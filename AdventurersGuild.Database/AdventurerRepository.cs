using AdventurersGuild.Database.Abstract;
using AdventurersGuild.Models;

namespace AdventurersGuild.Database;

public class AdventurerRepository : IAdventurerRepository
{
    private readonly GuildContext _context;

    public AdventurerRepository(GuildContext context)
    {
        _context = context;
    }

    public Adventurer[] Get(AdventurerFilter filter)
    {
        var query = _context.Adventurers.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(filter.SearchText))
        {
            query = query.Where(a => a.Name.Contains(filter.SearchText));
        }

        if (filter.Rank.HasValue)
        {
            query = query.Where(a => a.Rank == filter.Rank.Value);
        }

        return query.ToArray();
    }
    
    public Adventurer? GetById(int id)
    {
        return _context.Adventurers.Find(id);
    }
    
    public void Add(Adventurer adventurer)
    {
        _context.Adventurers.Add(adventurer);
        _context.SaveChanges();
    }
    
    public void Update(Adventurer adventurer)
    {
        _context.Adventurers.Update(adventurer);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var adventurer = GetById(id);
        if (adventurer != null)
        {
            _context.Adventurers.Remove(adventurer);
            _context.SaveChanges();
        }
    }
}