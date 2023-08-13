// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using System.Diagnostics;
using System.Reflection;

namespace miniblocks.API.Core;

/// <summary>
/// Provides information about the runtime environment.
/// </summary>
public static class RuntimeInfo
{
    /// <summary>
    /// The directory that the application was started from.
    /// </summary>
    public static string StartupDirectory { get; } = AppContext.BaseDirectory;

    /// <summary>
    /// The operating system that the application is running on.
    /// </summary>
    public static Platform OS { get; }

    /// <summary>
    /// Whether the application is running on a Unix-like system.
    /// </summary>
    public static bool IsUnix => OS is not Platform.Windows;

    /// <summary>
    /// Whether the application is running on Mac or iOS.
    /// </summary>
    public static bool IsApple => OS is Platform.Mac or Platform.IOS;

    /// <summary>
    /// Whether the application is running on Windows, Linux, or Mac.
    /// </summary>
    public static bool IsDesktop
        => OS is Platform.Windows or Platform.Linux or Platform.Mac;

    /// <summary>
    /// Whether the application is running on Android or iOS.
    /// </summary>
    public static bool IsMobile => OS is Platform.Android or Platform.IOS;

    static RuntimeInfo()
    {
        if (OperatingSystem.IsWindows())
            OS = Platform.Windows;

        if (OperatingSystem.IsLinux())
        {
            OS = OS == 0
                ? Platform.Linux
                : throw new InvalidOperationException(
                    $"Tried to set {nameof(OS)} to {nameof(Platform.Linux)} but it was already set to {Enum.GetName(OS)}."
                );
        }

        if (OperatingSystem.IsMacOS())
        {
            OS = OS == 0
                ? Platform.Mac
                : throw new InvalidOperationException(
                    $"Tried to set {nameof(OS)} to {nameof(Platform.Mac)} but it was already set to {Enum.GetName(OS)}."
                );
        }

        if (OperatingSystem.IsAndroid())
        {
            OS = OS == 0
                ? Platform.Android
                : throw new InvalidOperationException(
                    $"Tried to set {nameof(OS)} to {nameof(Platform.Android)} but it was already set to {Enum.GetName(OS)}."
                );
        }

        if (OperatingSystem.IsIOS())
        {
            OS = OS == 0
                ? Platform.IOS
                : throw new InvalidOperationException(
                    $"Tried to set {nameof(OS)} to {nameof(Platform.IOS)} but it was already set to {Enum.GetName(OS)}."
                );
        }

        if (OS == 0)
        {
            throw new PlatformNotSupportedException(
                "The current platform is not supported."
            );
        }
    }

    /// <summary>
    /// Gets the absolute path of <c>miniblocks.Core.dll</c>.
    /// </summary>
    /// <returns>The absolute path of <c>miniblocks.Core.dll</c>.</returns>
    public static string GetAssemblyPath()
    {
        var assembly = Assembly.GetAssembly(typeof(RuntimeInfo));
        Debug.Assert(assembly is not null);

        return assembly.Location;
    }
}

/// <summary>
/// Represents a platform that the application can run on.
/// </summary>
public enum Platform
{
    /// <summary>
    /// The Windows operating system.
    /// </summary>
    Windows,

    /// <summary>
    /// The Linux operating system.
    /// </summary>
    Linux,

    /// <summary>
    /// The Mac operating system.
    /// </summary>
    Mac,

    /// <summary>
    /// The Android operating system.
    /// </summary>
    Android,

    /// <summary>
    /// The iOS operating system.
    /// </summary>
    IOS,
}
