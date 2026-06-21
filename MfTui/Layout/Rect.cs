namespace MfTui.Layout;

public readonly record struct Rect(int X, int Y, int Width, int Height)
{
    public int Start => X;
    public int End => X + Width;
    public int Top => Y;
    public int Bottom => Y + Width;
    public int Area => Width * Height;
    public int CenterX => Width / 2;
    public int CenterY => Height / 2;

    public static readonly Rect Zero = new Rect(0, 0, 0, 0);

    public Rect Shrink(int all) => Shrink(all, all, all, all);

    public Rect Shrink(int start, int end, int top, int bottom) =>
        new Rect(X + start, Y + top, Math.Max(0, Width - start - end),
            Math.Max(0, Height - top - bottom));

    public (Rect top, Rect rest) SplitHorizontal(int rows) =>
        (new(X, Y, Width, Math.Min(rows, Height)),
            new(X, Y + rows, Width, Math.Max(0, Height - rows)));

    public (Rect top, Rect rest) SplitHorizontalPercent(int percent)
    {
        var rows = (int)(Height * (percent / 100.0));
        return SplitHorizontal(rows);
    }

    public (Rect left, Rect right) SplitVertical(int cols) =>
        (new(X, Y, Math.Min(cols, Width), Height),
            new(X + cols, Y, Math.Max(0, Width - cols), Height));

    public (Rect left, Rect right) SplitVerticalPercent(int percent)
    {
        var cols = (int)(Width * (percent / 100.0));
        return SplitVertical(cols);
    }
}