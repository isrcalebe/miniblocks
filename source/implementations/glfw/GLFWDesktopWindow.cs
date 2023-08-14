// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using miniblocks.API.Windowing.Events;
using miniblocks.API.Windowing.Events.Keyboard;
using miniblocks.API.Windowing.Events.Mouse;
using miniblocks.API.Windowing.Events.Window;
using Silk.NET.GLFW;
using Silk.NET.Maths;

namespace miniblocks.API.Windowing.GLFW;

public sealed unsafe partial class GLFWDesktopWindow : IWindow
{
    public nint Handle => (nint)windowHandle;

    public bool Exists => !glfw?.WindowShouldClose(windowHandle) ?? false;

    public VerticalSynchronization VSync
    {
        get => vsync;
        set
        {
            if (vsync == value)
                return;

            vsync = value;

            if (!Exists) return;

            switch (value)
            {
                case VerticalSynchronization.Disabled:
                    glfw?.SwapInterval(0);
                    break;

                case VerticalSynchronization.Enabled:
                    glfw?.SwapInterval(1);
                    break;

                case VerticalSynchronization.Adaptive:
                    glfw?.SwapInterval(-1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        null);
            }
        }
    }

    public IGraphicsContext? Context { get; private set; }

    public string Title
    {
        get => title;
        set
        {
            if (title == value)
                return;

            title = value;

            if (!Exists) return;

            glfw?.SetWindowTitle(windowHandle, value);
        }
    }

    public Vector2D<int> Size
    {
        get => size;
        set
        {
            if (size == value)
                return;

            size = value;

            if (!Exists) return;

            glfw?.SetWindowSize(windowHandle, value.X, value.Y);
        }
    }

    public Vector2D<int> Position
    {
        get => position;
        set
        {
            if (position == value)
                return;

            position = value;

            if (!Exists) return;

            glfw?.SetWindowPos(windowHandle, value.X, value.Y);
        }
    }

    public bool IsFocused => glfw?.GetWindowAttrib(windowHandle, WindowAttributeGetter.Focused) ?? false;

    public bool IsMaximized => glfw?.GetWindowAttrib(windowHandle, WindowAttributeGetter.Maximized) ?? false;

    public bool IsMinimized => glfw?.GetWindowAttrib(windowHandle, WindowAttributeGetter.Iconified) ?? false;

    public bool IsVisible => glfw?.GetWindowAttrib(windowHandle, WindowAttributeGetter.Visible) ?? false;

    public event Action<WindowEvent>? Any;

    public event Action<WindowClosedEvent>? Closed;

    public event Action<WindowFocusedEvent>? Focused;

    public event Action<WindowUnfocusedEvent>? Unfocused;

    public event Action<WindowMaximizedEvent>? Maximized;

    public event Action<WindowMinimizedEvent>? Minimized;

    public event Action<WindowSizeChangedEvent>? SizeChanged;

    public event Action<WindowPositionChangedEvent>? PositionChanged;

    public event Action<KeyboardKeyPressedEvent>? KeyboardKeyPressed;

    public event Action<KeyboardKeyReleasedEvent>? KeyboardKeyReleased;

    public event Action<MouseButtonPressedEvent>? MouseButtonPressed;

    public event Action<MouseButtonReleasedEvent>? MouseButtonReleased;

    public event Action<MouseMovedEvent>? MouseMoved;

    public event Action<MouseScrolledEvent>? MouseScrolled;

    public event Action<MouseEnteredEvent>? MouseEntered;

    public event Action<MouseLeftEvent>? MouseLeft;

    private Glfw? glfw;
    private WindowHandle* windowHandle;

    private VerticalSynchronization vsync = VerticalSynchronization.Disabled;

    private string title = "MINIBLOCKS";

    private Vector2D<int> size = new Vector2D<int>(1366, 768);
    private Vector2D<int> position = new Vector2D<int>(0, 0);

    public void CreateCapabilities()
    {
        if (Exists)
            return;

        glfw = Glfw.GetApi();

        if (glfw is null)
            throw new InvalidOperationException("Couldn't get the GLFW API.");

        if (!glfw.Init())
            throw new InvalidOperationException("Couldn't initialize GLFW.");

        glfw.WindowHint(WindowHintBool.Decorated, true);
        glfw.WindowHint(WindowHintInt.ContextVersionMajor, 4);
        glfw.WindowHint(WindowHintInt.ContextVersionMinor, 6);
        glfw.WindowHint(WindowHintOpenGlProfile.OpenGlProfile,
            OpenGlProfile.Core);

        windowHandle = glfw.CreateWindow(size.X, size.Y, Title, null, null);
        setWindowEventsCallbacks();
        setWindowInputEventsCallbacks();

        if (windowHandle is null)
        {
            var error = glfw.GetError(out _);

            throw new InvalidOperationException("Couldn't create the window.",
                new GlfwException($"Error Code: {error}."));
        }

        Context = new GLFWGraphicsContext(glfw, windowHandle);
        Context.MakeCurrent();
    }

    public void ProcessEvents()
    {
        if (!Exists)
            return;

        glfw?.PollEvents();
    }

    public void Exit()
    {
        glfw?.SetWindowShouldClose(windowHandle, true);
    }

    #region IDisposable Support

    private void releaseUnmanagedResources()
    {
        Context?.ClearCurrent();
        glfw?.DestroyWindow(windowHandle);
        glfw?.Terminate();
    }

    public void Dispose()
    {
        releaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }

    ~GLFWDesktopWindow()
    {
        releaseUnmanagedResources();
    }

    #endregion
}
