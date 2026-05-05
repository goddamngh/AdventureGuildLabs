using AdventurersGuild.Database.Abstract;
using AdventurersGuild.Models;
using AdventurersGuild.ViewModels.Adventurers;
using AdventurersGuild.ViewModels.Framework;
using AdventurersGuild.ViewModels.Quests;

namespace AdventurersGuild.ViewModels.Main;

public class MainViewModel : ViewModelBase
{
    private readonly IQuestRepository _questRepository;
    private readonly IAdventurerRepository _adventurerRepository;

    private readonly QuestsViewModel _questsViewModel;
    private readonly AdventurersViewModel _adventurersViewModel;

    private ViewModelBase _currentView;

    // Текущий отображаемый ViewModel.
    // ContentControl в MainWindow привязан к этому свойству.
    // При смене значения WPF автоматически выбирает подходящий View через DataTemplate по типу объекта.
    public ViewModelBase CurrentView
    {
        get => _currentView;
        private set => Set(ref _currentView, value);
    }

    public RelayCommand ShowQuestsCommand { get; }
    public RelayCommand ShowAdventurersCommand { get; }

    public MainViewModel(IQuestRepository questRepository, IAdventurerRepository adventurerRepository)
    {
        _questRepository = questRepository;
        _adventurerRepository = adventurerRepository;

        _questsViewModel = new QuestsViewModel(_questRepository, _adventurerRepository, this);
        _adventurersViewModel = new AdventurersViewModel(_adventurerRepository, this);

        ShowQuestsCommand = new RelayCommand(ShowQuests);
        ShowAdventurersCommand = new RelayCommand(ShowAdventurers);

        _currentView = _questsViewModel;
    }

    public async Task OpenQuestEdit(Quest? quest)
    {
        var editVm = new QuestEditViewModel(_questRepository, _adventurerRepository, quest);

        // Переключаем CurrentView на форму редактирования.
        // ContentControl в MainWindow автоматически подберёт нужный View через DataTemplate.
        CurrentView = editVm;

        // Ждём, пока форма не вызовет _completion.Complete() (Save или Cancel).
        await editVm.WhenCompleted;

        // Форма закрыта — возвращаемся к списку квестов.
        CurrentView = _questsViewModel;
    }

    public async Task OpenAdventurerEdit(Adventurer? adventurer)
    {
        var editVm = new AdventurerEditViewModel(_adventurerRepository, adventurer);

        // Переключаем CurrentView на форму редактирования.
        // ContentControl в MainWindow автоматически подберёт нужный View через DataTemplate.
        CurrentView = editVm;

        // Ждём, пока форма не вызовет _completion.Complete() (Save или Cancel).
        await editVm.WhenCompleted;

        // Форма закрыта — возвращаемся к списку авантюристов.
        CurrentView = _adventurersViewModel;
    }

    private void ShowQuests()
    {
        CurrentView = _questsViewModel;
    }

    private void ShowAdventurers()
    {
        CurrentView = _adventurersViewModel;
    }
}