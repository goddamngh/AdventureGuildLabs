using System.Collections.ObjectModel;

using AdventurersGuild.Database.Abstract;
using AdventurersGuild.Models;
using AdventurersGuild.ViewModels.Framework;
using AdventurersGuild.ViewModels.Main;

namespace AdventurersGuild.ViewModels.Adventurers;

public class AdventurersViewModel : ViewModelBase
{
    private readonly IAdventurerRepository _repository;
    private readonly MainViewModel _main;

    private ObservableCollection<Adventurer> _adventurers = [];
    public ObservableCollection<Adventurer> Adventurers
    {
        get => _adventurers;
        private set => Set(ref _adventurers, value);
    }
    
    private Adventurer? _selectedAdventurer;
    public Adventurer? SelectedAdventurer
    {
        get => _selectedAdventurer;
        set => Set(ref _selectedAdventurer, value);
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
    
    // обертки для комбобокса
    private AdventurerRank? _selectedRank;
    private readonly FilterOption<AdventurerRank?>[] _rankOptions;
    
    
    private FilterOption<AdventurerRank?> _selectedRankOption;
    public FilterOption<AdventurerRank?> SelectedRankOption
    {
        get => _selectedRankOption;
        set
        {
            if (Set(ref _selectedRankOption, value))
            {
                Load();
            }
        }
    }


    

    
    public IEnumerable<FilterOption<AdventurerRank?>> RankOptions => _rankOptions;
    public RelayCommand AddCommand { get; }
    public RelayCommand EditCommand { get; }
    public RelayCommand DeleteCommand { get; }

    public AdventurersViewModel(IAdventurerRepository repository, MainViewModel main)
    {
        _repository = repository;
        _main = main;

        _rankOptions = new[]
        {
            new FilterOption<AdventurerRank?>(null),  // "Все"
            new FilterOption<AdventurerRank?>(AdventurerRank.F),
            new FilterOption<AdventurerRank?>(AdventurerRank.E),
            new FilterOption<AdventurerRank?>(AdventurerRank.D),
            new FilterOption<AdventurerRank?>(AdventurerRank.C),
            new FilterOption<AdventurerRank?>(AdventurerRank.B),
            new FilterOption<AdventurerRank?>(AdventurerRank.A),
            new FilterOption<AdventurerRank?>(AdventurerRank.S)
        };
        _selectedRankOption = _rankOptions[0];
        
        AddCommand = new RelayCommand(Add);
        EditCommand = new RelayCommand(Edit, () => SelectedAdventurer is not null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedAdventurer is not null);

        Load();
    }

    public void Load()
    {
        var filter = new AdventurerFilter
        {
            SearchText = SearchText,
            Rank = SelectedRankOption?.Value
        };
        
        var adventurers = _repository.Get(filter);
        Adventurers = new ObservableCollection<Adventurer>(adventurers);
    }

    private async Task Add()
    {
        await _main.OpenAdventurerEdit(null);
        Load(); 
    }

    private async Task Edit()
    {
        await _main.OpenAdventurerEdit(SelectedAdventurer);
        Load(); 
    }

    private void Delete()
    {
        if (SelectedAdventurer is not null)
        {
            _repository.Delete(SelectedAdventurer.Id);
            Load(); 
        }
    }
}