using MfTui.Core;
using MfTui.Events;
using MfTui.Layout;
using MfTui.Rendering;
using MfTui.Widgets;

internal class Program
{
    public static void Main(string[] args)
    {
        Style s = new Style()
        {
            Bg = Color.Black,
            Fg = Color.Cyan
        };
        RenderEngine engine = new RenderEngine();
        IRenderContext context = engine.BeginFrame();
        BoxLayout box = new BoxLayout(new Rect(0, 0, 10, 5), BorderStyle.Bold, s);
        Label label = new Label(new Rect(3, 2, 10, 1), "Hello", s);
        box.Children.Add(label);
        box.Arrange();
        box.Render(context);
        label.Render(context);
        engine.EndFrame();
        Console.ReadKey();
    }
}