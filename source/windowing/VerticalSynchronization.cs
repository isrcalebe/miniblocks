// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.API.Windowing;

/// <summary>
/// The vertical synchronization mode.
/// </summary>
public enum VerticalSynchronization
{
    /// <summary>
    /// The vertical synchronization is disabled.
    /// </summary>
    Disabled = 0,

    /// <summary>
    /// The vertical synchronization is enabled.
    /// </summary>
    Enabled,

    /// <summary>
    /// The vertical synchronization is enabled, but the frame rate is adaptive.
    /// </summary>
    Adaptive
}
