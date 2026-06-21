using MfTui.Core;

namespace MfTui.Rendering;

public record struct Cell(char Symbol, Style Style, string? ComponentId = null)
{
    public static readonly Cell Empty = new(' ', Style.Default);
    public bool IsEmpty => Symbol == ' ' && Style == Style.Default;
}