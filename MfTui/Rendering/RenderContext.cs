using MfTui.Core;
using MfTui.Layout;

namespace MfTui.Rendering;

public class RenderContext(FrameBuffer buffer, RenderEngine engine) : IRenderContext
{
    public void DrawChar(int x, int y, char symbol, Style style) => buffer.Set(x, y, symbol, style);

    public void DrawText(int x, int y, string text, Style style)
    {
        for (int i = 0; i < text.Length; i++)
            buffer.Set(x + i, y, text[i], style);
    }

    public void DrawBox(Rect area, BorderStyle border, Style style)
    {
        var chars = BorderChars.Get(border);

        buffer.Set(area.X, area.Y, chars.TopLeft, style);
        buffer.Set(area.End - 1, area.Y, chars.TopRight, style);
        buffer.Set(area.X, area.Bottom - 1, chars.BottomLeft, style);
        buffer.Set(area.End - 1, area.Bottom - 1, chars.BottomRight, style);

        for (int x = area.X + 1; x < area.End - 1; x++)
        {
            buffer.Set(x, area.Y, chars.Horizontal, style);
            buffer.Set(x, area.Bottom - 1, chars.Horizontal, style);
        }

        for (int y = area.Y + 1; y < area.Bottom - 1; y++)
        {
            buffer.Set(area.X, y, chars.Vertical, style);
            buffer.Set(area.End - 1, y, chars.Vertical, style);
        }
    }  

    public void Fill(Rect bounds, char ch, Style style)
    {
        for (int row = bounds.Y; row < bounds.Bottom; row++)
        for (int col = bounds.X; col < bounds.End; col++)
            buffer.Set(col, row, ch, style);
    }

    public void ShowCursor(int x, int y) => engine.ShowCursor(x, y);

    public void HideCursor() => engine.HideCursor();
}