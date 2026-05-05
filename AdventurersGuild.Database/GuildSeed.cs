using AdventurersGuild.Models;

namespace AdventurersGuild.Database;

internal static class GuildSeed
{
    internal static readonly Quest[] Quests =
    [
        new()
        {
            Id = 1,
            Title = "Убить крыс в подвале таверны",
            Description = "Хозяин таверны жалуется на нашествие крыс.",
            Reward = 50m,
            Status = QuestStatus.Completed
        },
        new()
        {
            Id = 2,
            Title = "Найти пропавшую кошку",
            Description = "Кошка пропала три дня назад в районе рынка.",
            Reward = 30m,
            Status = QuestStatus.Completed
        },
        new()
        {
            Id = 3,
            Title = "Доставить письмо в Восточный форт",
            Description = "Срочное письмо для командира гарнизона.",
            Reward = 80m,
            Status = QuestStatus.Completed
        },
        new()
        {
            Id = 4,
            Title = "Охрана купеческого каравана",
            Description = "Сопровождение каравана до перевала Серых Камней.",
            Reward = 300m,
            Status = QuestStatus.Completed
        },
        new()
        {
            Id = 5,
            Title = "Расследование пожара на мельнице",
            Description = "Мельник подозревает поджог. Найти виновного.",
            Reward = 150m,
            Status = QuestStatus.Completed
        },
        new()
        {
            Id = 6,
            Title = "Зачистка бандитского лагеря",
            Description = "Банда орудует на дороге к северу от города.",
            Reward = 400m,
            Status = QuestStatus.InProgress
        },
        new()
        {
            Id = 7,
            Title = "Поиск пропавшего мага",
            Description = "Маг Ортан не вернулся из экспедиции в Тёмный лес две недели назад.",
            Reward = 500m,
            Status = QuestStatus.InProgress
        },
        new()
        {
            Id = 8,
            Title = "Сбор лечебных трав",
            Description = "Травнице нужны корни лунного цветка с болот.",
            Reward = 120m,
            Status = QuestStatus.InProgress
        },
        new()
        {
            Id = 9,
            Title = "Починить мост через реку Грай",
            Description = "Мост обрушился, нужны плотники и охрана.",
            Reward = 200m,
            Status = QuestStatus.InProgress
        },
        new()
        {
            Id = 10,
            Title = "Допросить информатора",
            Description = "Информатор скрывается в портовом квартале. Доставить живым.",
            Reward = 350m,
            Status = QuestStatus.InProgress
        },
        new()
        {
            Id = 11,
            Title = "Уничтожить гнездо гарпий",
            Description = "Гарпии нападают на пастбища к западу от города.",
            Reward = 600m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 12,
            Title = "Найти артефакт в руинах Калдара",
            Description = "Старинный медальон был утерян в руинах древней крепости.",
            Reward = 800m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 13,
            Title = "Охрана ярмарки",
            Description = "Требуется охрана на трёхдневную городскую ярмарку.",
            Reward = 250m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 14,
            Title = "Расследовать слухи о некроманте",
            Description = "Жители деревни Пустошь видели мертвецов у кладбища.",
            Reward = 450m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 15,
            Title = "Поймать дезертира",
            Description = "Солдат бежал с поста с казёнными деньгами.",
            Reward = 380m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 16,
            Title = "Разведка в горном перевале",
            Description = "Нужно выяснить, что происходит в перевале Туманного хребта.",
            Reward = 320m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 17,
            Title = "Освободить заложников",
            Description = "Культисты захватили паломников в старом храме.",
            Reward = 700m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 18,
            Title = "Уничтожить проклятый алтарь",
            Description = "Алтарь тёмного бога найден в катакомбах под городом.",
            Reward = 900m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 19,
            Title = "Найти украденные чертежи",
            Description = "Чертежи новой крепости похищены из архива герцога.",
            Reward = 550m,
            Status = QuestStatus.Available
        },
        new()
        {
            Id = 20,
            Title = "Убить дракона в Пепельных горах",
            Description = "Дракон Вермитар терроризирует деревни уже полгода.",
            Reward = 5000m,
            Status = QuestStatus.Available
        },
    ];

    internal static readonly Adventurer[] Adventurers =
    [
        new() { Id = 1, Name = "Торин Железнорукий", Rank = AdventurerRank.B, IsActive = true },
        new() { Id = 2, Name = "Элара Быстрый Лист", Rank = AdventurerRank.C, IsActive = true },
        new() { Id = 3, Name = "Магнус Пепельный", Rank = AdventurerRank.D, IsActive = false },
    ];
}