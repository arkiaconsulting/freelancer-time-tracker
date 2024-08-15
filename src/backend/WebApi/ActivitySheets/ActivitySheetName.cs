namespace WebApi.ActivitySheets;

public sealed class ActivitySheetName
{
    private readonly string _value;

    private ActivitySheetName(string value) =>
        _value = value;

    public static ActivitySheetName Create(string? value) =>
        string.IsNullOrWhiteSpace(value)
        ? throw new ArgumentException("An activity sheet name cannot be empty", nameof(value))
        : new(value);

    public override string ToString() => _value;
}