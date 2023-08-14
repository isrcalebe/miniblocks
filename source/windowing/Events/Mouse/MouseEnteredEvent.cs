// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.API.Windowing.Events.Mouse;

/// <inheritdoc />
/// <summary>
/// Represents a mouse entered event.
/// </summary>
public record MouseEnteredEvent(IWindow Handle) : WindowEvent(Handle);
