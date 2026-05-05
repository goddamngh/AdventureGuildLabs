namespace AdventurersGuild.ViewModels.Framework;

// Сигнал о завершении работы формы.
// Оборачивает TaskCompletionSource: вызов Complete() переводит Task в состояние завершён,
// что позволяет await-ить окончание работы формы из внешнего кода.
public class Completion
{
    private readonly TaskCompletionSource _tcs = new();

    public Task Task => _tcs.Task;

    public void Complete() => _tcs.SetResult();
}