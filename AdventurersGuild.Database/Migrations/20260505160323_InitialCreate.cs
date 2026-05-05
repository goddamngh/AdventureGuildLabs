using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdventurersGuild.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adventurers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Rank = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventurers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Reward = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Adventurers",
                columns: new[] { "Id", "IsActive", "Name", "Rank" },
                values: new object[,]
                {
                    { 1, true, "Торин Железнорукий", "B" },
                    { 2, true, "Элара Быстрый Лист", "C" }
                });

            migrationBuilder.InsertData(
                table: "Adventurers",
                columns: new[] { "Id", "Name", "Rank" },
                values: new object[] { 3, "Магнус Пепельный", "D" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Description", "Reward", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "Хозяин таверны жалуется на нашествие крыс.", 50m, 2, "Убить крыс в подвале таверны" },
                    { 2, "Кошка пропала три дня назад в районе рынка.", 30m, 2, "Найти пропавшую кошку" },
                    { 3, "Срочное письмо для командира гарнизона.", 80m, 2, "Доставить письмо в Восточный форт" },
                    { 4, "Сопровождение каравана до перевала Серых Камней.", 300m, 2, "Охрана купеческого каравана" },
                    { 5, "Мельник подозревает поджог. Найти виновного.", 150m, 2, "Расследование пожара на мельнице" },
                    { 6, "Банда орудует на дороге к северу от города.", 400m, 1, "Зачистка бандитского лагеря" },
                    { 7, "Маг Ортан не вернулся из экспедиции в Тёмный лес две недели назад.", 500m, 1, "Поиск пропавшего мага" },
                    { 8, "Травнице нужны корни лунного цветка с болот.", 120m, 1, "Сбор лечебных трав" },
                    { 9, "Мост обрушился, нужны плотники и охрана.", 200m, 1, "Починить мост через реку Грай" },
                    { 10, "Информатор скрывается в портовом квартале. Доставить живым.", 350m, 1, "Допросить информатора" },
                    { 11, "Гарпии нападают на пастбища к западу от города.", 600m, 0, "Уничтожить гнездо гарпий" },
                    { 12, "Старинный медальон был утерян в руинах древней крепости.", 800m, 0, "Найти артефакт в руинах Калдара" },
                    { 13, "Требуется охрана на трёхдневную городскую ярмарку.", 250m, 0, "Охрана ярмарки" },
                    { 14, "Жители деревни Пустошь видели мертвецов у кладбища.", 450m, 0, "Расследовать слухи о некроманте" },
                    { 15, "Солдат бежал с поста с казёнными деньгами.", 380m, 0, "Поймать дезертира" },
                    { 16, "Нужно выяснить, что происходит в перевале Туманного хребта.", 320m, 0, "Разведка в горном перевале" },
                    { 17, "Культисты захватили паломников в старом храме.", 700m, 0, "Освободить заложников" },
                    { 18, "Алтарь тёмного бога найден в катакомбах под городом.", 900m, 0, "Уничтожить проклятый алтарь" },
                    { 19, "Чертежи новой крепости похищены из архива герцога.", 550m, 0, "Найти украденные чертежи" },
                    { 20, "Дракон Вермитар терроризирует деревни уже полгода.", 5000m, 0, "Убить дракона в Пепельных горах" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adventurers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
