// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using miniblocks.API.Core.Native;

namespace miniblocks.API.Windowing;

public interface IGraphicsContext : IHasHandle
{
    /// <summary>
    /// Whether the context is current on the calling thread.
    /// </summary>
    bool IsCurrent { get; }

    /// <summary>
    /// The interval between frame swaps.
    /// </summary>
    int Interval { get; set; }

    /// <summary>
    /// Makes the context current on the calling thread.
    /// </summary>
    void MakeCurrent();

    /// <summary>
    /// Clears the current context on the calling thread.
    /// </summary>
    void ClearCurrent();

    /// <summary>
    /// Swaps the front and back buffers of the current context.
    /// </summary>
    void Swap();
}
