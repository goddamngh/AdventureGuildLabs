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
    
    public Quest[] Get(QuestFilter filter)
    {
        var query = _context.Questions.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(filter.SearchText))
        {
            query = query.Where(q => q.Title.Contains(filter.SearchText) 
                                     || q.Description.Contains(filter.SearchText));
        }

        if (filter.Status.HasValue)
        {
            query = query.Where(q => q.Status == filter.Status.Value);
        }

        return query.ToArray();
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