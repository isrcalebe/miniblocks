// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using miniblocks.API.Input;

namespace miniblocks.API.Windowing.Events.Mouse;

/// <inheritdoc />
/// <summary>
/// Represents a mouse button released event.
/// </summary>
/// <param name="Button">The key that was released.</param>
public record MouseButtonReleasedEvent(IWindow Handle, MouseKey Button) : MouseButtonEvent(Handle, Button);
