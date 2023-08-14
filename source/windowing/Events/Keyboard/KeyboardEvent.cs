// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using miniblocks.API.Input;

namespace miniblocks.API.Windowing.Events.Keyboard;

/// <inheritdoc/>
/// <summary>
/// Represents a keyboard event.
/// </summary>
/// <param name="Key">The key.</param>
public abstract record KeyboardEvent(IWindow Handle, KeyboardKey Key) : WindowEvent(Handle);
