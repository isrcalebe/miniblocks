// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using miniblocks.API.Input;

namespace miniblocks.API.Windowing.Events.Mouse;

/// <inheritdoc />
/// <summary>
/// Represents a mouse button pressed event.
/// </summary>
/// <param name="Button">The key that was pressed.</param>
public record MouseButtonPressedEvent(IWindow Handle, MouseKey Button) : MouseButtonEvent(Handle, Button);
