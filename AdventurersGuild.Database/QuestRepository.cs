using AdventurersGuild.Database.Abstract;
using AdventurersGuild.Models;

namespace AdventurersGuild.Database;

public class QuestRepository : IQuestRepository
{
    private readonly GuildContext _context;

    public QuestRepository(GuildContext context)
    {
        _context = context;
    }

    // TODO: реализовать методы интерфейса IQuestRepository
    
    public Quest[] GetAll()
    {
        return _context.Questions.ToArray();
    }
    
    public Quest? GetById(int id)
    {
        return _context.Questions.Find(id);
    }
    
    public void Add(Quest quest)
    {
        _context.Questions.Add(quest);
        _context.SaveChanges();
    }
    
    public void Update(Quest quest)
    {
        _context.Questions.Update(quest);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var quest = GetById(id);
        if (quest != null)
        {
            _context.Questions.Remove(quest);
            _context.SaveChanges();
        }
    }
}