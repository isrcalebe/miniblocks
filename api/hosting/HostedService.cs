// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using miniblocks.API.Core;

namespace miniblocks.API.Hosting;

/// <summary>
/// Represents a hosted service, which is a base class for all platform-specific hosted services.
/// </summary>
public abstract class HostedService : Foundation, IDisposable
{
    /// <summary>
    /// Occurs when the host is activated.
    /// </summary>
    public event Action Activated;

    /// <summary>
    /// Occurs when the host is deactivated.
    /// </summary>
    public event Action Deactivated;

    /// <summary>
    /// Occurs when the host is requested to exit.
    /// </summary>
    public event Action ExitRequested;

    /// <summary>
    /// Occurs when the host is exited.
    /// </summary>
    public event Action Exited;

    /// <summary>
    /// Gets a value indicating whether the host is alive.
    /// </summary>
    public bool IsAlive { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the host can exit.
    /// </summary>
    protected virtual bool CanExit => true;

    /// <summary>
    /// Called when the host is activated.
    /// </summary>
    protected virtual void OnActivated()
        => Activated();

    /// <summary>
    /// Called when the host is deactivated.
    /// </summary>
    protected virtual void OnDeactivated()
    {
        Deactivated();

        if (CanExit) ExitRequested?.Invoke();
    }

    /// <summary>
    /// Called when the host is exited.
    /// </summary>
    protected virtual void OnExited()
        => Exited();

    /// <summary>
    /// Run the host.
    /// </summary>
    public void Run()
    {
        IsAlive = true;

        AppDomain.CurrentDomain.ProcessExit += (_, _) =>
            Exit();

        OnActivated();
    }

    /// <summary>
    /// Exit the host.
    /// </summary>
    public void Exit()
    {
        if (!IsAlive) return;

        IsAlive = false;

        OnDeactivated();
        OnExited();
    }

#region IDisposable Support

    /// <summary>
    /// Collect the garbage.
    /// </summary>
    public virtual void Collect()
        => GC.Collect();

    /// <summary>
    /// Dispose of the object.
    /// </summary>
    /// <param name="disposing"><c>true</c> if called from Dispose(), <c>false</c> if called from the finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }

    /// <summary>
    /// Dispose of the object.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

#endregion
}
