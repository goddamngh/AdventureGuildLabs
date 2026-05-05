using System.Collections.ObjectModel;

using AdventurersGuild.Database.Abstract;
using AdventurersGuild.Models;
using AdventurersGuild.ViewModels.Framework;
using AdventurersGuild.ViewModels.Main;

namespace AdventurersGuild.ViewModels.Quests;

public class QuestsViewModel : ViewModelBase
{
    private readonly IQuestRepository _repository;
    private readonly MainViewModel _main;

    private ObservableCollection<Quest> _quests = [];
    private Quest? _selectedQuest;

    public ObservableCollection<Quest> Quests
    {
        get => _quests;
        private set => Set(ref _quests, value);
    }

    public Quest? SelectedQuest
    {
        get => _selectedQuest;
        set => Set(ref _selectedQuest, value);
    }

    public RelayCommand AddCommand { get; }
    public RelayCommand EditCommand { get; }
    public RelayCommand DeleteCommand { get; }

    public QuestsViewModel(IQuestRepository repository, MainViewModel main)
    {
        _repository = repository;
        _main = main;

        AddCommand = new RelayCommand(Add);
        EditCommand = new RelayCommand(Edit, () => SelectedQuest is not null);
        DeleteCommand = new RelayCommand(Delete, () => SelectedQuest is not null);

        Load();
    }

    public void Load()
    {
        // TODO: загрузить квесты из репозитория
        var quests = _repository.GetAll();
        Quests = new ObservableCollection<Quest>(quests);
    }

    private async Task Add()
    {
        await _main.OpenQuestEdit(null);
        // Форма закрылась — данные в БД могли измениться, обновляем список
        // TODO: обновить список
        Load();
    }

    private async Task Edit()
    {
        await _main.OpenQuestEdit(SelectedQuest);
        // Форма закрылась — данные в БД могли измениться, обновляем список
        // TODO: обновить список
        Load();
    }

    private void Delete()
    {
        // TODO: удалить выбранный квест через репозиторий, обновить список
        if (SelectedQuest is not null)
        {
            _repository.Delete(SelectedQuest.Id);
            Load();  // Обновляем список после удаления
        }
    }
}