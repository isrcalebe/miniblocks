// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using Silk.NET.Maths;

namespace miniblocks.API.Windowing;

/// <inheritdoc />
/// <summary>
/// Represents a window, which only exposes properties. Useful for not exposing graphics context, events or handles directly.
/// </summary>
public interface ISafeWindow : IDisposable
{
    /// <summary>
    /// The title of the window.
    /// </summary>
    string Title { get; set; }

    /// <summary>
    /// The size of the window.
    /// </summary>
    Vector2D<int> Size { get; set; }

    /// <summary>
    /// The position of the window.
    /// </summary>
    Vector2D<int> Position { get; set; }

    /// <summary>
    /// Whether the window exists.
    /// </summary>
    bool Exists { get; }

    /// <summary>
    /// Whether the window is focused.
    /// </summary>
    bool IsFocused { get; }

    /// <summary>
    /// Whether the window is maximized.
    /// </summary>
    bool IsMaximized { get; }

    /// <summary>
    /// Whether the window is minimized.
    /// </summary>
    bool IsMinimized { get; }

    /// <summary>
    /// Whether the window is visible.
    /// </summary>
    bool IsVisible { get; }

    /// <summary>
    /// The vertical synchronization mode.
    /// </summary>
    VerticalSynchronization VSync { get; set; }
}
