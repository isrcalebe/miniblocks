// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using Silk.NET.GLFW;

namespace miniblocks.API.Windowing.GLFW;

public sealed unsafe class GLFWGraphicsContext : IGraphicsContext
{
    public nint Handle => (nint)windowHandle;

    public bool IsCurrent => (glfw != null ? glfw.GetCurrentContext() : null) == windowHandle;

    public int Interval
    {
        get => interval;
        set
        {
            if (interval == value)
                return;

            interval = value;

            glfw?.SwapInterval(value);
        }
    }

    private int interval;

    private readonly Glfw? glfw;
    private readonly WindowHandle* windowHandle;

    public GLFWGraphicsContext(Glfw? glfw, WindowHandle* windowHandle)
    {
        this.glfw = glfw;
        this.windowHandle = windowHandle;
    }

    public void MakeCurrent()
    {
        if (IsCurrent)
            return;

        glfw?.MakeContextCurrent(windowHandle);
    }

    public void ClearCurrent()
    {
        if (!IsCurrent)
            return;

        glfw?.MakeContextCurrent(null);
    }

    public void Swap()
    {
        glfw?.SwapBuffers(windowHandle);
    }
}
