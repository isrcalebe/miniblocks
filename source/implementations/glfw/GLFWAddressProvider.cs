// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using miniblocks.API.Core.Native;
using Silk.NET.GLFW;

namespace miniblocks.API.Windowing.GLFW;

/// <inheritdoc />
/// <summary>
/// Provides the address of a function in the GLFW library.
/// </summary>
public sealed class GLFWAddressProvider : IAddressProvider
{
    private readonly Glfw? glfw;

    /// <summary>
    /// Initializes a new instance of the <see cref="GLFWAddressProvider"/> class.
    /// </summary>
    /// <param name="glfw">A reference to the GLFW library.</param>
    /// <remarks>
    /// If <paramref name="glfw"/> is <see langword="null"/>, the default GLFW library will be used.
    /// </remarks>
    public GLFWAddressProvider(Glfw? glfw = null)
    {
        this.glfw ??= Glfw.GetApi();
    }

    public nint GetProcessAddress(string name)
        => glfw?.GetProcAddress(name) ?? throw new InvalidOperationException("There was an error getting the GLFW process address.");
}
