using AdventurersGuild.Database.Abstract;
using AdventurersGuild.Models;
using AdventurersGuild.ViewModels.Framework;

namespace AdventurersGuild.ViewModels.Adventurers;

public class AdventurerEditViewModel : ViewModelBase
{
    private readonly IAdventurerRepository _repository;
    private readonly Adventurer? _adventurer;
    private readonly Completion _completion = new();

    // TODO: добавить свойства формы (Name, Rank, IsActive)
    
    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set => Set(ref _name, value);
    }
    
    private AdventurerRank _rank = AdventurerRank.F;
    public AdventurerRank Rank
    {
        get => _rank;
        set => Set(ref _rank, value);
    }
    
    private bool _isActive = true;
    public bool IsActive
    {
        get => _isActive;
        set => Set(ref _isActive, value);
    }
    

    public IEnumerable<AdventurerRank> Ranks { get; } = Enum.GetValues<AdventurerRank>();

    public bool IsEditMode => _adventurer is not null;
    public string FormTitle => _adventurer is { } a ? $"Авантюрист #{a.Id}" : "Новый авантюрист";

    public RelayCommand SaveCommand { get; }
    public RelayCommand CancelCommand { get; }

    // MainViewModel ожидает этот Task через await.
    // Когда форма завершает работу (Save или Cancel), Complete() разблокирует ожидающего.
    public Task WhenCompleted => _completion.Task;

    public AdventurerEditViewModel(IAdventurerRepository repository, Adventurer? adventurer)
    {
        _repository = repository;
        _adventurer = adventurer;

        if (_adventurer is not null)
        {
            CopyFrom(_adventurer);
        }

        SaveCommand = new RelayCommand(Save, Validate);
        CancelCommand = new RelayCommand(Cancel);
    }

    private void CopyFrom(Adventurer adventurer)
    {
        // TODO: скопировать данные из модели в свойства формы
        Name = adventurer.Name;
        Rank = adventurer.Rank;
        IsActive = adventurer.IsActive;
    }

    private void CopyTo(Adventurer adventurer)
    {
        // TODO: скопировать данные из свойств формы в модель
        adventurer.Name = Name;
        adventurer.Rank = Rank;
        adventurer.IsActive = IsActive;
    }

    private bool Validate()
    {
        // TODO: проверить корректность введённых данных
        return !string.IsNullOrWhiteSpace(Name);
    }

    private void Save()
    {
        // TODO: создать или обновить запись через репозиторий
        
        if (_adventurer is not null)
        {
            CopyTo(_adventurer);
            _repository.Update(_adventurer);
        }
        else
        {
            var newAdventurer = new Adventurer();
            CopyTo(newAdventurer);
            _repository.Add(newAdventurer);
        }
        // Сигнализируем MainViewModel, что форма завершила работу
        _completion.Complete();
    }

    private void Cancel()
    {
        // Сигнализируем MainViewModel, что форма завершила работу
        _completion.Complete();
    }
}