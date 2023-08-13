// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;

namespace miniblocks.API.Hosting.Linux;

public sealed class LinuxHostedService : HostedService
{
    protected override void OnActivated()
    {
        base.OnActivated();

        Console.WriteLine("[LINUX] Hello, world!");
    }

    protected override void OnDeactivated()
    {
        base.OnDeactivated();

        Console.WriteLine("[LINUX] Goodbye, world!");
    }

    protected override void OnExited()
    {
        base.OnExited();

        Console.WriteLine("[LINUX] Exited.");
    }
}
