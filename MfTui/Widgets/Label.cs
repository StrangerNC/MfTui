using MfTui.Core;
using MfTui.Layout;
using MfTui.Rendering;

namespace MfTui.Widgets;

public class Label(Rect area, string text, Style style) : Widget(area, style)
{
    public string Text { get; set; } = text;

    public override void Render(IRenderContext context)
    {
        if (!IsVisible) return;
        var text = Text.Length <= Area.Width
            ? Text.PadRight(Area.Width)
            : Text[..Area.Width];
        context.DrawText(Area.X, Area.Y, text, Style);
    }
}