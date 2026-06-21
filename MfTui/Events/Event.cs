namespace MfTui.Events;

public abstract record Event;

public sealed record KeyEvent(ConsoleKeyInfo Key) : Event
{
    public bool IsCtrl(char ch) =>
        Key.Modifiers.HasFlag(ConsoleModifiers.Control) && char.ToLower(Key.KeyChar) == char.ToLower(ch);
}

public sealed record ResizeEvent(int Width, int Height) : Event;

public sealed record TickEvent : Event;