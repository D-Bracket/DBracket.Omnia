
using DBracket.Omnia.Logic.Windows.KeyBoardControl;
using SNMP_Test.TilingWinodwManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DBracket.Omnia.Logic.Windows.Experimental
{
    internal class TestExecution
    {
        // Define constants
        private const uint EVENT_SYSTEM_FOREGROUND = 0x0003;
        private const uint WINEVENT_OUTOFCONTEXT = 0x0000;

        // Declare the WinAPI function SetWinEventHook
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        // Declare the WinAPI function UnhookWinEvent
        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        // Delegate to receive events
        private delegate void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        // The callback that will be invoked when a window is focused
        private static void WinEventCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (eventType == EVENT_SYSTEM_FOREGROUND)
            {
                Debug.WriteLine($"Window focused: {hwnd}");
                // Do something with the window handle (hwnd)
            }
        }

        private IntPtr _focusHook;

        public void Test()
        {
            //KeyboardInterceptor.Start();

            Debug.WriteLine("Press ESC to stop the hook.");


            // Enumerate windows and get information
            WindowManager.EnumerateWindows();

            // Example: Find a specific window by class or title (e.g., Notepad)
            IntPtr notepadWnd = WindowManager.FindWindow("Notepad", null);

            if (notepadWnd != IntPtr.Zero)
            {
                // Example: Move Notepad window to position (100, 100)
                WindowManager.MoveWindow(notepadWnd, 100, 100, 800, 600);
                DwmEffects.DisableWindowBlur(notepadWnd);
            }

            // Set the hook for window focus events
            IntPtr _focusHook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, WinEventCallback, 0, 0, WINEVENT_OUTOFCONTEXT);

            if (_focusHook == IntPtr.Zero)
            {
                Debug.WriteLine("Failed to set hook.");
                return;
            }

            //// Set up the hook to listen for window creation events
            //HookProc hookProc = new HookProc(HookCallback);

            //// Use the current thread's ID with Thread.CurrentThread.ManagedThreadId
            //uint threadId = (uint)Thread.CurrentThread.ManagedThreadId;

            //_hookHandle = SetWindowsHookEx(WH_CBT, hookProc, IntPtr.Zero, threadId);

            //if (_hookHandle == IntPtr.Zero)
            //{
            //    int errorCode = Marshal.GetLastWin32Error();
            //    Debug.WriteLine($"Failed to set hook! Error code: {errorCode}");
            //}



            ////SetHook();
            //UpdateList();

            //Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, AutomationElement.RootElement, TreeScope.Subtree, (sender, e) =>
            //{
            //    UpdateList();
            //});

            //Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, AutomationElement.RootElement, TreeScope.Subtree, (sender, e) =>
            //{
            //    UpdateList();

            //});

            //System.Windows.Automation.Automation.AddAutomationFocusChangedEventHandler(OnFocusChanged);


            //void UpdateList()
            //{
            //    var windows = string.Empty;
            //    foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
            //    {
            //        IntPtr handle = window.Key;
            //        string title = window.Value;

            //        windows += $"Handle: {handle}, title: {title}\n";
            //        //Debug.WriteLine("{0}: {1}", handle, title);
            //    }
            //    Application.Current.Dispatcher.Invoke(() => TextWindowList.Text = windows);
            //}
            //Unloaded += HandleUnloaded;
        }

        private void HandleUnloaded()
        {
            // Unhook the hook when done
            //if (_hookHandle != IntPtr.Zero)
            //    WindowManager.UnhookWindowsHookEx(_hookHandle);

            //Unhook();
            UnhookWinEvent(_focusHook);
            // Stop the keyboard hook
            KeyboardInterceptor.Stop();
        }

        private IntPtr _hookHandle;
    }
}
