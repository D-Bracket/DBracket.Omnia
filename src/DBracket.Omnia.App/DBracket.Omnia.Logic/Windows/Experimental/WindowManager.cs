using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SNMP_Test.TilingWinodwManager
{
    public class WindowManager
    {
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        const int WH_CBT = 5;
        private static IntPtr _hookHandle = IntPtr.Zero;
        private static HookProc _hookProc;


        public static void SetHook()
        {
            _hookProc = new HookProc(CbtHookProc);
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                IntPtr hMod = GetModuleHandle("user32.dll");
                // Use the current thread's ID with Thread.CurrentThread.ManagedThreadId
                uint threadId = (uint)Thread.CurrentThread.ManagedThreadId;
               
                _hookHandle = SetWindowsHookEx(13, _hookProc, GetModuleHandle(curModule.ModuleName), 0);
                if (_hookHandle == IntPtr.Zero)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    Console.WriteLine($"Failed to set hook. Error code: {errorCode}");
                }

                //    string success = _hookHandle == IntPtr.Zero ? "Failed To Hook" : "Hooked!!!";
                //MessageBox.Show(success);
                    
            }
        }

        private static IntPtr CbtHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                // Do something when a new window is created (e.g., log the window handle)
                if (nCode == 3) // HCBT_CREATEWND
                {
                    Console.WriteLine($"New window created: {wParam}");
                }
            }
            return CallNextHookEx(_hookHandle, nCode, wParam, lParam);
        }

        public static void Unhook()
        {
            if (_hookHandle != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookHandle);
                _hookHandle = IntPtr.Zero;
            }
        }
            //// Import necessary WinAPI functions
            //[DllImport("user32.dll", CharSet = CharSet.Auto)]
            //public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, uint threadId);

            //[DllImport("user32.dll", CharSet = CharSet.Auto)]
            //public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            //[DllImport("user32.dll")]
            //public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            //[DllImport("user32.dll", CharSet = CharSet.Auto)]
            //public static extern IntPtr GetMessageExtraInfo();

            //// Define the hook type
            //public const int WH_CBT = 5;
            //public const int HCBT_CREATEWND = 3; // Window is being created

            //// Delegate for the hook callback function
            //public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

            //// Struct for window creation information
            //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            //public struct CREATESTRUCT
            //{
            //    public IntPtr lpCreateParams;
            //    public IntPtr hInstance;
            //    public IntPtr hMenu;
            //    public IntPtr hwndParent;
            //    public int cy;
            //    public int cx;
            //    public int y;
            //    public int x;
            //    public int style;
            //    public IntPtr lpszName;
            //    public IntPtr lpszClass;
            //    public uint dwExStyle;
            //}

            //// This function will be called when the hook is triggered
            //public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            //{
            //    if (nCode >= 0)
            //    {
            //        // When a window is being created (HCBT_CREATEWND)
            //        if (nCode == HCBT_CREATEWND)
            //        {
            //            CREATESTRUCT createStruct = (CREATESTRUCT)Marshal.PtrToStructure(lParam, typeof(CREATESTRUCT));

            //            // Log the name of the window class
            //            string windowClass = Marshal.PtrToStringAuto(createStruct.lpszClass);
            //            string windowName = Marshal.PtrToStringAuto(createStruct.lpszName);

            //            Debug.WriteLine($"Window Created: Class={windowClass}, Name={windowName}");
            //        }
            //    }
            //    return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            //}













            // Import necessary WinAPI functions
            [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int Width, int Height, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

        // Window style constants
        const uint SWP_NOMOVE = 0x0002;
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;

        // Delegate for EnumWindowsProc callback
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        // Rectangle structure
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        // Function to get and print window information
        public static void EnumerateWindows()
        {
            EnumWindows((hWnd, lParam) =>
            {
                // Get window rect
                GetWindowRect(hWnd, out RECT rect);
                Console.WriteLine($"Window Handle: {hWnd} - Position: {rect.Left}, {rect.Top}, {rect.Right}, {rect.Bottom}");

                return true; // Continue enumeration
            }, IntPtr.Zero);
        }

        // Function to move and resize a window
        public static void MoveWindow(IntPtr hWnd, int x, int y, int width, int height)
        {
            SetWindowPos(hWnd, IntPtr.Zero, x, y, width, height, SWP_NOZORDER);
        }
    }
}