// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.API.Windowing.Events.Window;

/// <inheritdoc />
/// <summary>
/// Represents a window unfocused event.
/// </summary>
public record WindowUnfocusedEvent(IWindow Handle) : WindowEvent(Handle);
