// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using miniblocks.API.Platform.Hosting.Builders;

namespace miniblocks.API.Platform.Hosting;

public abstract class Host : IDisposable
{
    protected AppDomain? Domain { get; private set; }

    public virtual void Run()
    {
        Domain = AppDomain.CurrentDomain;

        CreateCapabilities();
    }

    protected virtual void CreateCapabilities()
    {
    }

    #region Builders

    public static HostClientBuilder CreateClientBuilder()
    {
        return new HostClientBuilder();
    }

    #endregion

    #region IDisposable Support

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
