// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using miniblocks.API.Input;
using miniblocks.API.Windowing.Events;
using miniblocks.API.Windowing.Events.Keyboard;
using miniblocks.API.Windowing.Events.Mouse;
using miniblocks.API.Windowing.Events.Window;
using Silk.NET.GLFW;
using Silk.NET.Maths;

namespace miniblocks.API.Windowing.GLFW;

public sealed unsafe partial class GLFWDesktopWindow
{
    private void setWindowEventsCallbacks()
    {
        glfw?.SetWindowCloseCallback(windowHandle, handleWindowCloseCallback);
        glfw?.SetWindowSizeCallback(windowHandle, handleWindowSizeCallback);
        glfw?.SetWindowPosCallback(windowHandle, handleWindowPosCallback);
        glfw?.SetWindowFocusCallback(windowHandle, handleWindowFocusCallback);
        glfw?.SetWindowMaximizeCallback(windowHandle,
            handleWindowMaximizeCallback);
        glfw?.SetWindowIconifyCallback(windowHandle,
            handleWindowIconifyCallback);
    }

    private void setWindowInputEventsCallbacks()
    {
        glfw?.SetKeyCallback(windowHandle, handleKeyboard);
        glfw?.SetMouseButtonCallback(windowHandle, handleMouseButton);
        glfw?.SetCursorEnterCallback(windowHandle, handleMouseEnterCallback);
        glfw?.SetCursorPosCallback(windowHandle, handleMouseMoved);
        glfw?.SetScrollCallback(windowHandle, handleMouseScrolled);
    }

    private void handleKeyboard(WindowHandle* window, Keys key, int scancode,
                                InputAction action, KeyModifiers mods)
    {
        var keyboardKey = (KeyboardKey)key;

        WindowEvent? e;

        switch (action)
        {
            case InputAction.Press:
                e = new KeyboardKeyPressedEvent(this, keyboardKey, false);

                Any?.Invoke(e);
                KeyboardKeyPressed?.Invoke((KeyboardKeyPressedEvent)e);
                break;

            case InputAction.Repeat:
                e = new KeyboardKeyPressedEvent(this, keyboardKey, true);

                Any?.Invoke(e);
                KeyboardKeyPressed?.Invoke((KeyboardKeyPressedEvent)e);
                break;

            case InputAction.Release:
                e = new KeyboardKeyReleasedEvent(this, keyboardKey);

                Any?.Invoke(e);
                KeyboardKeyReleased?.Invoke((KeyboardKeyReleasedEvent)e);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(action), action,
                    null);
        }
    }

    private void handleMouseButton(WindowHandle* window, MouseButton button,
                                   InputAction action, KeyModifiers mods)
    {
        var mouseKey = (MouseKey)button;

        WindowEvent? e;

        switch (action)
        {
            case InputAction.Press:
                e = new MouseButtonPressedEvent(this, mouseKey);

                MouseButtonPressed?.Invoke((MouseButtonPressedEvent)e);
                break;

            case InputAction.Release:
                e = new MouseButtonReleasedEvent(this, mouseKey);

                MouseButtonReleased?.Invoke((MouseButtonReleasedEvent)e);
                break;

            case InputAction.Repeat:
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action,
                    null);
        }
    }

    private void handleMouseMoved(WindowHandle* window, double x, double y)
    {
        var e = new MouseMovedEvent(this, new Vector2D<double>(x, y));

        Any?.Invoke(e);
        MouseMoved?.Invoke(e);
    }

    private void handleMouseScrolled(WindowHandle* window, double x, double y)
    {
        var e = new MouseScrolledEvent(this, new Vector2D<double>(x, y));

        Any?.Invoke(e);
        MouseScrolled?.Invoke(e);
    }

    private void handleMouseEnterCallback(WindowHandle* window, bool entered)
    {
        WindowEvent? e;

        if (entered)
        {
            e = new MouseEnteredEvent(this);

            Any?.Invoke(e);
            MouseEntered?.Invoke((MouseEnteredEvent)e);
        }
        else
        {
            e = new MouseLeftEvent(this);

            Any?.Invoke(e);
            MouseLeft?.Invoke((MouseLeftEvent)e);
        }
    }

    private void handleWindowCloseCallback(WindowHandle* window)
    {
        var e = new WindowClosedEvent(this);

        Any?.Invoke(e);
        Closed?.Invoke(e);
    }

    private void handleWindowSizeCallback(WindowHandle* window, int width,
                                          int height)
    {
        size.X = width;
        size.Y = height;

        var e = new WindowSizeChangedEvent(this, size);

        Any?.Invoke(e);
        SizeChanged?.Invoke(e);
    }

    private void handleWindowPosCallback(WindowHandle* window, int x, int y)
    {
        position.X = x;
        position.Y = y;

        var e = new WindowPositionChangedEvent(this, position);

        Any?.Invoke(e);
        PositionChanged?.Invoke(e);
    }

    private void handleWindowFocusCallback(WindowHandle* window, bool focused)
    {
        WindowEvent? e;

        if (focused)
        {
            e = new WindowFocusedEvent(this);

            Any?.Invoke(e);
            Focused?.Invoke((WindowFocusedEvent)e);
        }
        else
        {
            e = new WindowUnfocusedEvent(this);

            Any?.Invoke(e);
            Unfocused?.Invoke((WindowUnfocusedEvent)e);
        }
    }

    private void handleWindowMaximizeCallback(WindowHandle* window,
                                              bool maximized)
    {
        WindowEvent? e;

        if (maximized)
        {
            e = new WindowMaximizedEvent(this);

            Any?.Invoke(e);
            Maximized?.Invoke((WindowMaximizedEvent)e);
        }
        else
        {
            e = new WindowMinimizedEvent(this);

            Any?.Invoke(e);
            Minimized?.Invoke((WindowMinimizedEvent)e);
        }
    }

    private void handleWindowIconifyCallback(WindowHandle* window,
                                             bool iconified)
    {
        WindowEvent? e;

        if (iconified)
        {
            e = new WindowMinimizedEvent(this);

            Any?.Invoke(e);
            Minimized?.Invoke((WindowMinimizedEvent)e);
        }
        else
        {
            e = new WindowMaximizedEvent(this);

            Any?.Invoke(e);
            Maximized?.Invoke((WindowMaximizedEvent)e);
        }
    }
}
