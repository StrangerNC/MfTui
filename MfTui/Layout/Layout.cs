using MfTui.Core;
using MfTui.Widgets;

namespace MfTui.Layout;

public abstract class Layout(Rect area, Style style) : Widget(area, style)
{
    public Rect Area { get; set; } = area;
    public Style Style { get; set; } = style;
    public List<Widget> Children = new List<Widget>();
    public abstract void Measure();
    public abstract void Arrange();
}