// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using Silk.NET.Maths;

namespace miniblocks.API.Windowing.Events.Mouse;

/// <inheritdoc />
/// <summary>
/// Represents a mouse scrolled event.
/// </summary>
/// <param name="Offset">The offset of the scroll.</param>
public record MouseScrolledEvent(IWindow Handle, Vector2D<double> Offset) : WindowEvent(Handle);
