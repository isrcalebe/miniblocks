// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.API.Core.Native;

/// <summary>
/// Represents an object that has a handle.
/// </summary>
public interface IHasHandle
{
    /// <summary>
    /// The handle, which is a pointer to the native object.
    /// </summary>
    nint Handle { get; }
}
