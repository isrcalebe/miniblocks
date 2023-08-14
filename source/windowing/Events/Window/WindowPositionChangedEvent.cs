// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using Silk.NET.Maths;

namespace miniblocks.API.Windowing.Events.Window;

/// <inheritdoc/>
/// <summary>
/// Represents a window position changed event.
/// </summary>
/// <param name="Position">The new position of the window.</param>
public record WindowPositionChangedEvent(IWindow Handle, Vector2D<int> Position) : WindowEvent(Handle);
