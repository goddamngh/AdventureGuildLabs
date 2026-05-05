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

    // TODO: реализовать методы интерфейса IAdventurerRepository

    public Adventurer[] GetAll()
    {
        return _context.Adventurers.ToArray();
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