// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.API.Windowing.Events.Mouse;

/// <inheritdoc />
/// <summary>
/// Represents a mouse left event.
/// </summary>
public record MouseLeftEvent(IWindow Handle) : WindowEvent(Handle);
