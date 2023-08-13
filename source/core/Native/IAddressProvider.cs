// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

namespace miniblocks.API.Core.Native;

/// <summary>
/// Provides methods for querying available functions in the process.
/// </summary>
public interface IAddressProvider
{
    /// <summary>
    /// Retrieves an unmanaged function pointer to the specified exported function in the specified module.
    /// </summary>
    /// <param name="name">An ASCII-encoded <see cref="string"/> that contains the name of the function.</param>
    /// <returns>
    /// A <see cref="nint"/> that represents the address of the exported function, or <see cref="nint.Zero"/>,
    /// if the function is not found or not supported by the drivers.
    /// </returns>
    /// <remarks>
    /// Some drivers are known to return non-zero values for unsupported functions.
    /// </remarks>
    nint GetProcessAddress(string name);
}
