using MfTui.Core;
using MfTui.Layout;

namespace MfTui.Rendering;

public class FrameBuffer
{
    private Cell[,] _current;
    private Cell[,] _previous;

    public int Width { get; }
    public int Height { get; }

    public FrameBuffer(int width, int height)
    {
        Width = width;
        Height = height;
        _current = new Cell[height, width];
        _previous = new Cell[height, width];

        Clear();
    }

    public void Set(int x, int y, char symbol, Style style)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height) return;
        this[y, x] = new Cell(symbol, style);
    }

    public IEnumerable<(int X, int Y, Cell cell)> GetDiff()
    {
        for (int y = 0; y < Height; y++)
        for (int x = 0; x < Width; x++)
            if (!_current[y, x].Equals(_previous[y, x]))
                yield return (x, y, _current[y, x]);
    }

    public void Commit() => Array.Copy(_current, _previous, _current.Length);

    public void Resize(int width, int height)
    {
        Array.Clear(_current, 0, _current.Length);
        Array.Clear(_previous, 0, _previous.Length);
        _current = new Cell[height, width];
        _previous = new Cell[height, width];
    }

    public void Invalidate() => Array.Clear(_previous, 0, _previous.Length);

    public ref Cell this[int y, int x] => ref _current[y, x];

    public void Clear(Rect area, Style? style = null)
    {
        var s = style ?? Style.Default;
        for (int y = area.Y; y < area.Bottom; y++)
        for (int x = area.X; x < area.End; x++)
            this[y, x] = new Cell(' ', s);
    }

    public void Clear()
    {
        for (int y = 0; y < Height; y++)
        for (int x = 0; x < Width; x++)
            _current[y, x] = Cell.Empty;
    }
}