// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using miniblocks.API.Core.Native;

namespace miniblocks.API.Windowing;

public interface IGraphicsContext : IHasHandle
{
    bool IsCurrent { get; }

    int Interval { get; set; }

    void MakeCurrent();

    void ClearCurrent();

    void Swap();
}
