using AdventurersGuild.Models;

namespace AdventurersGuild.Database.Abstract;

public interface IAdventurerRepository
{
    Adventurer[] Get(AdventurerFilter filter);
    Adventurer? GetById(int id);
    void Add(Adventurer adventurer);
    void Update(Adventurer adventurer);
    void Delete(int id);
}