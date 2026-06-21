namespace MfTui.Rendering;

public class RenderEngine
{
    public readonly FrameBuffer Buffer;
    private int _cursorX = -1;
    private int _cursorY = -1;

    public RenderEngine()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Write("\e[?1049h"); // enter alternate screen
        Console.Write("\e[?25l"); // hide cursor

        int w = Console.WindowWidth;
        int h = Console.WindowHeight;

        Buffer = new FrameBuffer(w, h);
    }

    public IRenderContext BeginFrame()
    {
        Buffer.Clear();
        return new RenderContext(Buffer, this);
    }

    public void EndFrame()
    {
        foreach (var (x, y, cell) in Buffer.GetDiff())
        {
            if (_cursorX != x || _cursorY != y)
            {
                Console.SetCursorPosition(x, y);
                _cursorX = x;
                _cursorY = y;
            }

            Console.Write($"{cell.Style.Bg.ToBg()}{cell.Style.Fg.ToFg()}{cell.Symbol}");

            _cursorX++;

            if (_cursorX >= Buffer.Width)
            {
                _cursorX = 0;
                _cursorY++;
            }
        }

        Console.ResetColor();
        Buffer.Commit();
    }

    public void ShowCursor(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.CursorVisible = true;
    }

    public void HideCursor() => Console.CursorVisible = false;
    public void Resize(int width, int height) => Buffer.Resize(width, height);
}