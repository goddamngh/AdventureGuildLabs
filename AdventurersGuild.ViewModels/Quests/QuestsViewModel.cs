using System.Collections.ObjectModel;

using AdventurersGuild.Database.Abstract;
using AdventurersGuild.Models;
using AdventurersGuild.ViewModels.Framework;
using AdventurersGuild.ViewModels.Main;

namespace AdventurersGuild.ViewModels.Quests;

public class QuestsViewModel : ViewModelBase
{
    private readonly IQuestRepository _repository;
    private readonly IAdventurerRepository _adventurerRepository;
    private readonly MainViewModel _main;

    private ObservableCollection<Quest> _quests = [];
    public ObservableCollection<Quest> Quests
    {
        get => _quests;
        private set => Set(ref _quests, value);
    }

    private Quest? _selectedQuest;
    public Quest? SelectedQuest
    {
        get => _selectedQuest;
        set => Set(ref _selectedQuest, value);
    }
    
    
    private string _searchText = string.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (Set(ref _searchText, value))
            {
                Load();
            }
        }
    }
    
    private FilterOption<Adventurer?>[] _adventurerOptions = [];
    public IEnumerable<FilterOption<Adventurer?>> AdventurerOptions => _adventurerOptions;

    private FilterOption<Adventurer?> _selectedAdventurerOption;
    public FilterOption<Adventurer?> SelectedAdventurerOption
    {
        get => _selectedAdventurerOption;
        set
        {
            if (Set(ref _selectedAdventurerOption, value))
            {
                Load();
            }
        }
    }
    
    
    private readonly FilterOption<QuestStatus?>[] _statusOptions;
    private FilterOption<QuestStatus?> _selectedStatusOption;
    public FilterOption<QuestStatus?> SelectedStatusOption
    {
        get => _selectedStatusOption;
        set
        {
            if (Set(ref _selectedStatusOption, value))
            {
                Load();
            }
        }
    }
    
    

    public IEnumerable<FilterOption<QuestStatus?>> StatusOptions => _statusOptions; 
    public RelayCommand AddCommand { get; }
    public RelayCommand EditCommand { get; }
    public RelayCommand DeleteCommand { get; }

    public QuestsViewModel(IQuestRepository repository, IAdventurerRepository adventurerRepository, MainViewModel main)
    {
        _repository = repository;
        _adventurerRepository = adventurerRepository;
        _main = main;

        _statusOptions = new[]
        {
            new FilterOption<QuestStatus?>(null),
            new FilterOption<QuestStatus?>(QuestStatus.Available),
            new FilterOption<QuestStatus?>(QuestStatus.InProgress),
            new FilterOption<QuestStatus?>(QuestStatus.Completed),
            new FilterOption<QuestStatus?>(QuestStatus.Failed)
        };
        _selectedStatusOption = _statusOptions[0];
        
        LoadAdventurerOptions(); 
        
        AddCommand = new RelayCommand(Add);
        EditCommand = new RelayCommand(Edit, () => SelectedQuest is not null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedQuest is not null);

        Load();
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
        _selectedAdventurerOption = _adventurerOptions[0];
    }

    public void Load()
    {
        var filter = new QuestFilter
        {
            SearchText = SearchText,
            Status = SelectedStatusOption?.Value,
            AdventurerId = SelectedAdventurerOption?.Value?.Id
        };
        
        var quests = _repository.Get(filter);
        Quests = new ObservableCollection<Quest>(quests);
    }

    private async Task Add()
    {
        await _main.OpenQuestEdit(null);
        Load();
    }

    private async Task Edit()
    {
        await _main.OpenQuestEdit(SelectedQuest);
        Load();
    }

    private void Delete()
    {
        if (SelectedQuest is not null)
        {
            _repository.Delete(SelectedQuest.Id);
            Load(); 
        }
    }
}