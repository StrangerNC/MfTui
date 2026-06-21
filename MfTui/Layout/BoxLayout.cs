using MfTui.Core;
using MfTui.Rendering;

namespace MfTui.Layout;

public class BoxLayout(Rect area, BorderStyle borderStyle, Style style) : Layout(area, style)
{
    public override void Render(IRenderContext context)
    {
        context.DrawBox(Area, borderStyle, Style);
        context.Fill(Area.Shrink(1), ' ', Style);
    }

    public override void Measure()
    {
    }

    public override void Arrange()
    {
        int width, height;
        foreach (var child in Children)
        {
            child.Area = child.Area with { X = child.Area.X + Area.X, Y = child.Area.Y + Area.Y };
            width = child.Area.X + child.Area.Width;
            height = child.Area.Y + child.Area.Height;
            if (width > Area.End)
                child.Area = child.Area with { Width = child.Area.Width - (child.Area.End - Area.End) };
            if (height > Area.Bottom)
                child.Area = child.Area with { Height = child.Area.Height - (child.Area.Bottom - Area.Bottom) };
        }
    }
}