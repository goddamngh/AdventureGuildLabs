using AdventurersGuild.Models;

namespace AdventurersGuild.Database.Abstract;

public interface IQuestRepository
{
    Quest[] GetAll();
    Quest? GetById(int id);
    void Add(Quest quest);
    void Update(Quest quest);
    void Delete(int id);
}