// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using miniblocks.API.Input;

namespace miniblocks.API.Windowing.Events.Keyboard;

/// <inheritdoc/>
/// <summary>
/// Represents a keyboard released event.
/// </summary>
/// <param name="Key">The key that was released.</param>
public record KeyboardKeyReleasedEvent(IWindow Handle, KeyboardKey Key) : KeyboardEvent(Handle, Key);
