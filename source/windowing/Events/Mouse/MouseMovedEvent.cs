// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using Silk.NET.Maths;

namespace miniblocks.API.Windowing.Events.Mouse;

/// <inheritdoc />
/// <summary>
/// Represents a mouse moved event.
/// </summary>
/// <param name="Position">The new position of the mouse.</param>
public record MouseMovedEvent(IWindow Handle, Vector2D<double> Position) : WindowEvent(Handle);
