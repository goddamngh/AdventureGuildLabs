using AdventurersGuild.Database.Abstract;
using AdventurersGuild.Models;
using AdventurersGuild.ViewModels.Framework;

namespace AdventurersGuild.ViewModels.Quests;

public class QuestEditViewModel : ViewModelBase
{
    private readonly IQuestRepository _repository;
    private readonly IAdventurerRepository _adventurerRepository;
    private readonly Quest? _quest;
    private readonly Completion _completion = new();
    private FilterOption<Adventurer?>[] _adventurerOptions = []; //список опций
    
    private string _title =  string.Empty;
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }
    
    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set => Set(ref _description, value);
    }
    
    private decimal _reward;
    public decimal Reward
    {
        get => _reward;
        set => Set(ref _reward, value);
    }

    private QuestStatus _status = QuestStatus.Available;
    public QuestStatus Status
    {
        get => _status;
        set => Set(ref _status, value);
    }
    
    private FilterOption<Adventurer?> _selectedAdventurerOption;
    public FilterOption<Adventurer?> SelectedAdventurerOption
    {
        get => _selectedAdventurerOption;
        set => Set(ref _selectedAdventurerOption, value);
    }
    
    public IEnumerable<FilterOption<Adventurer?>> AdventurerOptions { get; private set; }

    public IEnumerable<QuestStatus> Statuses { get; } = Enum.GetValues<QuestStatus>();

    public bool IsEditMode => _quest is not null;
    public string FormTitle => _quest is { } q ? $"Квест #{q.Id}" : "Новый квест";

    public RelayCommand SaveCommand { get; }
    public RelayCommand CancelCommand { get; }

    // MainViewModel ожидает этот Task через await.
    // Когда форма завершает работу (Save или Cancel), Complete() разблокирует ожидающего.
    public Task WhenCompleted => _completion.Task;

    public QuestEditViewModel(IQuestRepository repository, IAdventurerRepository adventurerRepository, Quest? quest)
    {
        _repository = repository;
        _adventurerRepository = adventurerRepository;
        _quest = quest;
        
        LoadAdventurerOptions();

        if (_quest is not null)
        {
            CopyFrom(_quest);
        }

        SaveCommand = new RelayCommand(Save, Validate);
        CancelCommand = new RelayCommand(Cancel);
    }

    private void LoadAdventurerOptions()
    {
        var adventurers = _adventurerRepository.Get(new AdventurerFilter());
    
        var options = new List<FilterOption<Adventurer?>>
        {
            new FilterOption<Adventurer?>(null)
        };
    
        options.AddRange(adventurers.Select(a => new FilterOption<Adventurer?>(a)));
    
        _adventurerOptions = options.ToArray();
    }
    
    private void CopyFrom(Quest quest)
    {
        Title = quest.Title;
        Description = quest.Description;
        Reward = quest.Reward;
        Status = quest.Status;
        SelectedAdventurerOption = _adventurerOptions.FirstOrDefault(o => o.Value?.Id == quest.AdventurerId);
    }

    private void CopyTo(Quest quest)
    {
        quest.Title = Title;
        quest.Description = Description;
        quest.Reward = Reward;
        quest.Status = Status;
        quest.AdventurerId = SelectedAdventurerOption?.Value?.Id;
    }
    

    private bool Validate()
    {
        return !string.IsNullOrWhiteSpace(Title) && Reward >= 0;
    }

    private void Save()
    {
        if (_quest is not null)
        {
            CopyTo(_quest);
            _repository.Update(_quest);
        }
        else
        {
            var newQuest = new Quest();
            CopyTo(newQuest);
            _repository.Add(newQuest);
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