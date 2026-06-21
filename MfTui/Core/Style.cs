using System.Text;

namespace MfTui.Core;

[Flags]
public enum TextModifier
{
    None = 0,
    Bold = 1 << 0,
    Dim = 1 << 1,
    Italic = 1 << 2,
    Underline = 1 << 3,
    Blink = 1 << 4,
    Reverse = 1 << 5,
    Strike = 1 << 6,
}

public readonly record struct Style(Color Fg, Color Bg, TextModifier Modifiers = TextModifier.None)
{
    public static readonly Style Default = new(Color.Default, Color.Default);

    public string ToAnsi()
    {
        var sb = new StringBuilder();
        sb.Append("\e[0m");
        sb.Append(Fg.ToFg());
        sb.Append(Bg.ToBg());
        if (Modifiers.HasFlag(TextModifier.Bold)) sb.Append("\e[1m");
        if (Modifiers.HasFlag(TextModifier.Dim)) sb.Append("\e[2m");
        if (Modifiers.HasFlag(TextModifier.Italic)) sb.Append("\e[3m");
        if (Modifiers.HasFlag(TextModifier.Underline)) sb.Append("\e[4m");
        if (Modifiers.HasFlag(TextModifier.Blink)) sb.Append("\e[5m");
        if (Modifiers.HasFlag(TextModifier.Reverse)) sb.Append("\e[7m");
        if (Modifiers.HasFlag(TextModifier.Strike)) sb.Append("\e[9m");
        return sb.ToString();
    }

    public static Style Of(Color fg) => new(fg, Color.Default);
    public static Style Of(Color fg, Color bg) => new(fg, bg);

    public Style WithFg(Color fg) => this with { Fg = fg };
    public Style WithBg(Color bg) => this with { Bg = bg };
    public Style WithModifier(TextModifier m) => this with { Modifiers = Modifiers | m };
}