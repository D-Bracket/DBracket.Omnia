namespace DBracket.Omnia.Logic.Windows.KeyBoardControl
{
    internal class KeyboardInterceptor
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
        private static KeyboardHook _hook = new KeyboardHook();

        public static void Start(Func<int, IntPtr, IntPtr, IntPtr> callBack)
        {
            _hook.hookProc = new KeyboardHook.HookProc(callBack);
            _hook.hookHandle = KeyboardHook.SetWindowsHookEx(KeyboardHook.WH_KEYBOARD_LL, _hook.hookProc, IntPtr.Zero, 0);
        }

        public static void Stop()
        {
            if (_hook.hookHandle != IntPtr.Zero)
            {
                KeyboardHook.UnhookWindowsHookEx(_hook.hookHandle);
                _hook.hookHandle = IntPtr.Zero;
            }
        }


        //// Callback function for the keyboard hook
        //private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        //{
        //    if (nCode >= 0)
        //    {
        //        var hookStruct = (KeyboardHook.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KeyboardHook.KBDLLHOOKSTRUCT));
        //        int keyCode = hookStruct.vkCode;
        //        Debug.WriteLine($"keycode: {keyCode}, lParam: {lParam}");

        //        if (wParam == (IntPtr)KeyboardHook.WM_KEYDOWN || wParam == (IntPtr)KeyboardHook.WM_SYSKEYDOWN)
        //        {
        //            //if (keyCode == KeyboardHook.VK_ESCAPE) // Example: intercept the ESC key
        //            //{
        //            //    Debug.WriteLine("ESC key pressed and handled.");
        //            //    return (IntPtr)1;  // Return 1 to mark as handled and stop propagation
        //            //}
        //            //else 
        //              if (keyCode == KeyboardHook.VK_CAPITAL)
        //            {
        //                Console.WriteLine("Caps Lock key pressed and handled.");
        //                _lastKey = KeyboardHook.VK_CAPITAL;
        //                return (IntPtr)1;  // Return 1 to mark the event as handled
        //            }
        //            else if (keyCode == KeySimulator.bVK_LEFT)
        //            {
        //                if (_lastKey == KeyboardHook.VK_CAPITAL)
        //                {
        //                    Console.WriteLine("Caps Lock key pressed and handled.");
        //                    KeySimulator.SimulateKeyPress2(KeySimulator.bVK_HOME);
        //                    return (IntPtr)1;  // Return 1 to mark the event as handled
        //                }
        //            }
        //            else if (keyCode == KeySimulator.bVK_RIGHT)
        //            {
        //                if (_lastKey == KeyboardHook.VK_CAPITAL)
        //                {
        //                    Console.WriteLine("Caps Lock key pressed and handled.");
        //                    KeySimulator.SimulateKeyPress2(KeySimulator.bVK_END);
        //                    return (IntPtr)1;  // Return 1 to mark the event as handled
        //                }
        //            }
        //        }
        //    }

        //    // If not handling the key, pass the event to the next hook in the chain
        //    return KeyboardHook.CallNextHookEx(_hook.hookHandle, nCode, wParam, lParam);
        //}
    }
}