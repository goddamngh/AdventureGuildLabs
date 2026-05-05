using System.Windows;
using System.Windows.Media;

using AdventurersGuild.Database;
using AdventurersGuild.Database.Abstract;
using AdventurersGuild.ViewModels.Main;

using Microsoft.EntityFrameworkCore;

using Wpf.Ui.Appearance;

namespace AdventurersGuild.UI;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ApplicationAccentColorManager.Apply(Color.FromRgb(0xFF, 0xD7, 0x00), ApplicationTheme.Dark);

        // TODO: получить опции через GuildContextOptionsBuilder.Build()
        
        var options = GuildContextOptionsBuilder.Build();
        
        // TODO: создать GuildContext, передав опции в конструктор

        var context = new GuildContext(options);
        
        // TODO: применить миграции — context.Database.Migrate()

        context.Database.Migrate();
        
        // TODO: создать репозитории
        
        var adventurerRepository = new AdventurerRepository(context);
        var questRepository = new QuestRepository(context);

        // TODO: передать репозитории в MainViewModel и установить DataContext окна
        
        var mainViewModel = new MainViewModel(questRepository, adventurerRepository);
        
        var window = new MainWindow { DataContext = mainViewModel };
        window.Show();
    }
}