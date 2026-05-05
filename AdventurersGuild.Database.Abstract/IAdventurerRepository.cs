using AdventurersGuild.Models;

namespace AdventurersGuild.Database.Abstract;

public interface IAdventurerRepository
{
    Adventurer[] GetAll();
    Adventurer? GetById(int id);
    void Add(Adventurer adventurer);
    void Update(Adventurer adventurer);
    void Delete(int id);
}