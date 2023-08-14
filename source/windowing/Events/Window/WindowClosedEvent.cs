// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.API.Windowing.Events.Window;

/// <inheritdoc />
/// <summary>
/// Represents a window closed event.
/// </summary>
public record WindowClosedEvent(IWindow Handle) : WindowEvent(Handle);
