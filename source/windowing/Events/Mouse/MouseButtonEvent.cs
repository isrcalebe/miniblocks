// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using miniblocks.API.Input;

namespace miniblocks.API.Windowing.Events.Mouse;

/// <inheritdoc />
/// <summary>
/// Represents a mouse button event.
/// </summary>
/// <param name="Button">The key.</param>
public record MouseButtonEvent(IWindow Handle, MouseKey Button) : WindowEvent(Handle);
