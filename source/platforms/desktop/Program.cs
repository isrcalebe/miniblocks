// Part of the MINIBLOCKS, under the MIT License.
// See COPYING for license information.
// SPDX-License-Identifier: MIT

using System;
using miniblocks.API.Windowing;
using miniblocks.API.Windowing.GLFW;

namespace miniblocks.Desktop;

public class Program : IDisposable
{
    private readonly IWindow unsafeWindow;

    public ISafeWindow Window => unsafeWindow;

    private ulong frameCount = 0;

    private Program()
    {
        unsafeWindow = new GLFWDesktopWindow();
        unsafeWindow.CreateCapabilities();

        unsafeWindow.Any += Console.WriteLine;
    }

    private void start()
    {
        Console.WriteLine("SAMPLE APPLICATION STARTED");

        while (unsafeWindow.Exists)
        {
            updateFrame();

            unsafeWindow.ProcessEvents();
            unsafeWindow.Context?.Swap();
        }
    }

    private void updateFrame()
    {
        frameCount++;

        if (frameCount < 10)
            Console.WriteLine($"Current Frame: {frameCount}");
    }

    public void Dispose()
    {
        unsafeWindow.Dispose();

        GC.SuppressFinalize(this);
    }

    public static void Main(string[] args)
    {
        new Program().start();
    }
}
