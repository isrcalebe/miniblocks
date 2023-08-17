// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;

namespace miniblocks.API.Development;

public static class Runtime
{
    public static string StartupDirectory => AppContext.BaseDirectory;

    public static readonly OSPlatform OS;

    public static bool IsDesktop => OS is OSPlatform.Windows or OSPlatform.Linux or OSPlatform.MacOS;
    public static bool IsUnix => OS is not OSPlatform.Windows;
    public static bool IsMobile => OS is OSPlatform.Android or OSPlatform.iOS;
    public static bool IsApple => OS is OSPlatform.MacOS or OSPlatform.iOS;

    static Runtime()
    {
        if (OperatingSystem.IsWindows())
            OS = OSPlatform.Windows;

        if (OperatingSystem.IsLinux())
        {
            OS = OS == 0
                ? OSPlatform.Linux
                : throw new InvalidOperationException(
                    $"Tried to set {nameof(OS)} to {nameof(OSPlatform.Linux)} but it was already set to {Enum.GetName(OS)}.");
        }

        if (OperatingSystem.IsMacOS())
        {
            OS = OS == 0
                ? OSPlatform.MacOS
                : throw new InvalidOperationException(
                    $"Tried to set {nameof(OS)} to {nameof(OSPlatform.MacOS)} but it was already set to {Enum.GetName(OS)}.");
        }

        if (OperatingSystem.IsAndroid())
        {
            OS = OS == 0
                ? OSPlatform.Android
                : throw new InvalidOperationException(
                    $"Tried to set {nameof(OS)} to {nameof(OSPlatform.Android)} but it was already set to {Enum.GetName(OS)}.");
        }

        if (OperatingSystem.IsIOS())
        {
            OS = OS == 0
                ? OSPlatform.iOS
                : throw new InvalidOperationException(
                    $"Tried to set {nameof(OS)} to {nameof(OSPlatform.iOS)} but it was already set to {Enum.GetName(OS)}.");
        }

        throw new PlatformNotSupportedException("Couldn't detect the current platform.");
    }
}

public enum OSPlatform
{
    Windows,
    Linux,
    MacOS,
    Android,
    iOS,
}
