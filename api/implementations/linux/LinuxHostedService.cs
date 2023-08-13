// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using Serilog;

namespace miniblocks.API.Hosting.Linux;

public sealed class LinuxHostedService : HostedService
{
    protected override void OnActivated()
    {
        base.OnActivated();

        Logger?.Information("Hello, world!");
    }

    protected override void OnDeactivated()
    {
        base.OnDeactivated();

        Logger?.Information("Goodbye, world!");
    }

    protected override void OnExited()
    {
        base.OnExited();

        Logger?.Information("Exited.");
    }

    protected override LoggerConfiguration CreateLoggerConfiguration()
        => base.CreateLoggerConfiguration()
               .MinimumLevel
               .Debug();
}
