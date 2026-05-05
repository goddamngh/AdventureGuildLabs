namespace AdventurersGuild.ViewModels.Framework;

public class FilterOption<T>
{
    public T? Value { get; }
    
    public FilterOption(T? value)
    {
        Value = value;
    }
    
    public override string ToString()
    {
        return Value?.ToString() ?? "null";
    }
}