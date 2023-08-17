// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using miniblocks.API.Development;
using miniblocks.API.Platform.Impl.Linux;

namespace miniblocks.API.Platform.Hosting.Builders;

public sealed class HostClientBuilder : HostBuilder
{
    private ClientHost? host;

    internal HostClientBuilder()
    {
    }

    public override Host Build()
    {
        return Runtime.OS switch
        {
            OSPlatform.Linux => host ??= new LinuxGameHost(),
            _ => throw new NotImplementedException("This OS is not supported yet.")
        };
    }
}
