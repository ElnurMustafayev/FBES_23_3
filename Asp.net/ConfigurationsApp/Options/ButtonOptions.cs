namespace ConfigurationsApp.Options;

public class ButtonOptions
{
    public string Text { get; set; } = string.Empty;
    public int FontSize { get; set; } = 0;
    public bool Animation { get; set; } = false;

    public override string ToString() => $"{Text} | {FontSize}px | {nameof(Animation)}: {Animation}";
}