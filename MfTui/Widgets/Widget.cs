using MfTui.Core;
using MfTui.Layout;
using MfTui.Rendering;

namespace MfTui.Widgets;

public abstract class Widget(Rect area, Style style, string? id = null)
{
    public Rect Area { get; set; } = area;
    public string? Id { get; init; } = id;
    public Style Style { get; set; } = style;
    public bool IsVisible { get; set; } = true;
    public abstract void Render(IRenderContext context);
}