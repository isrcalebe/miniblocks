// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using Silk.NET.Maths;

namespace miniblocks.API.Windowing.Events.Window;

/// <inheritdoc />
/// <summary>
/// Represents a window size changed event.
/// </summary>
/// <param name="Size">The new size of the window.</param>
public record WindowSizeChangedEvent(IWindow Handle, Vector2D<int> Size) : WindowEvent(Handle);
