// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.API.Core;

/// <summary>
/// Represents an object that has unmanaged resources.
/// </summary>
public interface IHasUnmanagedResources
{
    /// <summary>
    /// Releases the unmanaged resources held by the object.
    /// </summary>
    void ReleaseUnmanagedResources();
}
