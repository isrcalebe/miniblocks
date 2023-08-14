// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using miniblocks.API.Input;

namespace miniblocks.API.Windowing.Events.Keyboard;

/// <inheritdoc />
/// <summary>
/// Represents a keyboard pressed event.
/// </summary>
/// <param name="Key">The key that was pressed.</param>
/// <param name="Repeat">Whether the key was pressed repeatedly.</param>
public record KeyboardKeyPressedEvent(IWindow Handle, KeyboardKey Key, bool Repeat) : KeyboardEvent(Handle, Key);
