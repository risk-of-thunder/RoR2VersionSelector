// This file is subject to the terms and conditions defined
// in file 'LICENSE', which is part of this source code package.

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DepotDownloader
{
    static class PlatformUtilities
    {
        public static void SetExecutable(string path, bool value)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return;
            }

            const UnixFileMode ModeExecute = UnixFileMode.UserExecute | UnixFileMode.GroupExecute | UnixFileMode.OtherExecute;

            var mode = File.GetUnixFileMode(path);
            var hasExecuteMask = (mode & ModeExecute) == ModeExecute;
            if (hasExecuteMask != value)
            {
                File.SetUnixFileMode(path, value
                    ? mode | ModeExecute
                    : mode & ~ModeExecute);
            }
        }

        #region WIN32_CONSOLE_STUFF
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint GetConsoleProcessList(uint[] processList, uint processCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        const uint MB_OK = 0x0;
        const uint MB_ICONWARNING = 0x30;

        public static void VerifyConsoleLaunch()
        {
            // Reference: https://devblogs.microsoft.com/oldnewthing/20160125-00/?p=92922
            var processList = new uint[2];
            var processCount = GetConsoleProcessList(processList, (uint)processList.Length);

            if (processCount != 1)
            {
                return;
            }

            _ = MessageBox(
                IntPtr.Zero,
                "Depot Downloader is a console application; there is no GUI.\n\nIf you do not pass any command line parameters, it prints usage info and exits.\n\nYou must use this from a terminal/console.",
                "DepotDownloader",
                MB_OK | MB_ICONWARNING
            );
        }
        #endregion
    }
}
