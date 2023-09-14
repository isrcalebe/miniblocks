// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.Allocation;

/// <summary>
/// Represents an object that has a handle.
/// </summary>
/// <typeparam name="T">The type of the handle, which must be unmanaged.</typeparam>
public interface IHasHandle<out T>
    where T : unmanaged
{
    /// <summary>
    /// The handle of the object.
    /// </summary>
    T Handle { get; }
}
