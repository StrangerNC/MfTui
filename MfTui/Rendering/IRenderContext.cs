using MfTui.Core;
using MfTui.Layout;

namespace MfTui.Rendering;

public interface IRenderContext
{
    void DrawChar(int x, int y, char symbol, Style style);
    void DrawText(int x, int y, string text, Style style);
    void DrawBox(Rect area, BorderStyle border, Style style);
    void Fill(Rect area, char symbol, Style style);
    void ShowCursor(int x, int y);
    void HideCursor();
}

public enum BorderStyle
{
    None,
    Single,
    Double,
    Rounded,
    Bold
}

public record BorderChars(
    char TopLeft,
    char TopRight,
    char BottomLeft,
    char BottomRight,
    char Horizontal,
    char Vertical)
{
    public static BorderChars Get(BorderStyle style) => style switch
    {
        BorderStyle.Single => new('┌', '┐', '└', '┘', '─', '│'),
        BorderStyle.Double => new('╔', '╗', '╚', '╝', '═', '║'),
        BorderStyle.Rounded => new('╭', '╮', '╰', '╯', '─', '│'),
        BorderStyle.Bold => new('┏', '┓', '┗', '┛', '━', '┃'),
        _ => new(' ', ' ', ' ', ' ', ' ', ' ')
    };
}