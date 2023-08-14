using System;
using miniblocks.API.Input;
using miniblocks.API.Windowing.GLFW;

using var window = new GLFWDesktopWindow();
window.CreateCapabilities();

window.Any += Console.WriteLine;

// window.Closed += Console.WriteLine;
// window.Focused += Console.WriteLine;
// window.Unfocused += Console.WriteLine;
// window.Maximized += Console.WriteLine;
// window.Minimized += Console.WriteLine;
// window.SizeChanged += Console.WriteLine;
// window.PositionChanged += Console.WriteLine;
window.KeyboardKeyPressed += e =>
{
    Console.WriteLine(e);

    if (e.Key == KeyboardKey.Escape)
        e.Handle.Exit();

    if (e.Key == KeyboardKey.H)
        e.Handle.Title = "Hello World!";
};
// window.KeyboardKeyReleased += Console.WriteLine;
// window.MouseButtonPressed += Console.WriteLine;
// window.MouseButtonReleased += Console.WriteLine;
// window.MouseMoved += Console.WriteLine;
// window.MouseScrolled += Console.WriteLine;
// window.MouseEntered += Console.WriteLine;
// window.MouseLeft += Console.WriteLine;

while (window.Exists)
{
    window.Context?.Swap();
    window.ProcessEvents();
}
