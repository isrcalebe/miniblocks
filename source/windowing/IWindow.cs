// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using miniblocks.API.Core.Native;
using miniblocks.API.Windowing.Events;
using miniblocks.API.Windowing.Events.Keyboard;
using miniblocks.API.Windowing.Events.Mouse;
using miniblocks.API.Windowing.Events.Window;

namespace miniblocks.API.Windowing;

/// <inheritdoc cref="miniblocks.API.Windowing.ISafeWindow" />
/// <summary>
/// Represents a window.
/// </summary>
public interface IWindow : ISafeWindow, IHasHandle
{
    /// <summary>
    /// The graphics context.
    /// </summary>
    IGraphicsContext? Context { get; }

    /// <summary>
    /// Creates the window.
    /// </summary>
    void CreateCapabilities();

    /// <summary>
    /// Processes events.
    /// </summary>
    void ProcessEvents();

    /// <summary>
    /// Exits the window.
    /// </summary>
    void Exit();

    /// <summary>
    /// Occurs when any event is raised.
    /// </summary>
    event Action<WindowEvent>? Any;

    /// <summary>
    /// Occurs when the window is closed.
    /// </summary>
    event Action<WindowClosedEvent>? Closed;

    /// <summary>
    /// Occurs when the window is focused.
    /// </summary>
    event Action<WindowFocusedEvent>? Focused;

    /// <summary>
    /// Occurs when the window is unfocused.
    /// </summary>
    event Action<WindowUnfocusedEvent>? Unfocused;

    /// <summary>
    /// Occurs when the window is maximized.
    /// </summary>
    event Action<WindowMaximizedEvent>? Maximized;

    /// <summary>
    /// Occurs when the window is minimized.
    /// </summary>
    event Action<WindowMinimizedEvent>? Minimized;

    /// <summary>
    /// Occurs when the window size is changed.
    /// </summary>
    event Action<WindowSizeChangedEvent>? SizeChanged;

    /// <summary>
    /// Occurs when the window position is changed.
    /// </summary>
    event Action<WindowPositionChangedEvent>? PositionChanged;

    /// <summary>
    /// Occurs when a key is pressed.
    /// </summary>
    event Action<KeyboardKeyPressedEvent>? KeyboardKeyPressed;

    /// <summary>
    /// Occurs when a key is released.
    /// </summary>
    event Action<KeyboardKeyReleasedEvent>? KeyboardKeyReleased;

    /// <summary>
    /// Occurs when a mouse button is pressed.
    /// </summary>
    event Action<MouseButtonPressedEvent>? MouseButtonPressed;

    /// <summary>
    /// Occurs when a mouse button is released.
    /// </summary>
    event Action<MouseButtonReleasedEvent>? MouseButtonReleased;

    /// <summary>
    /// Occurs when the mouse is scrolled.
    /// </summary>
    event Action<MouseScrolledEvent>? MouseScrolled;

    /// <summary>
    /// Occurs when the mouse is moved.
    /// </summary>
    event Action<MouseMovedEvent>? MouseMoved;

    /// <summary>
    /// Occurs when the mouse enters the window.
    /// </summary>
    event Action<MouseEnteredEvent>? MouseEntered;

    /// <summary>
    /// Occurs when the mouse leaves the window.
    /// </summary>
    event Action<MouseLeftEvent>? MouseLeft;
}
