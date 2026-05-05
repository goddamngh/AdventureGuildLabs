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
    private Adventurer? _selectedAdventurer;

    public ObservableCollection<Adventurer> Adventurers
    {
        get => _adventurers;
        private set => Set(ref _adventurers, value);
    }

    public Adventurer? SelectedAdventurer
    {
        get => _selectedAdventurer;
        set => Set(ref _selectedAdventurer, value);
    }

    public RelayCommand AddCommand { get; }
    public RelayCommand EditCommand { get; }
    public RelayCommand DeleteCommand { get; }

    public AdventurersViewModel(IAdventurerRepository repository, MainViewModel main)
    {
        _repository = repository;
        _main = main;

        AddCommand = new RelayCommand(Add);
        EditCommand = new RelayCommand(Edit, () => SelectedAdventurer is not null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedAdventurer is not null);

        Load();
    }

    public void Load()
    {
        // TODO: загрузить авантюристов из репозитория
        var _adventurers = _repository.GetAll();
        Adventurers = new ObservableCollection<Adventurer>(_adventurers);
    }

    private async Task Add()
    {
        await _main.OpenAdventurerEdit(null);
        // Форма закрылась — данные в БД могли измениться, обновляем список
        // TODO: обновить список
        Load(); 
    }

    private async Task Edit()
    {
        await _main.OpenAdventurerEdit(SelectedAdventurer);
        // Форма закрылась — данные в БД могли измениться, обновляем список
        // TODO: обновить список
        Load(); 
    }

    private void Delete()
    {
        // TODO: удалить выбранного авантюриста через репозиторий, обновить список
        if (SelectedAdventurer is not null)
        {
            _repository.Delete(SelectedAdventurer.Id);
            Load(); 
        }
    }
}