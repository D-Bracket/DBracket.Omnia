using DBracket.Omnia.Api.Interfaces;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DBracket.Omnia.Logic.Windows.KeyBoardControl
{
    public class KeyBoardControlWindows : IKeyBoardControl
    {
        #region "----------------------------- Private Fields ------------------------------"
        private static byte _lastKey = 0;
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public KeyBoardControlWindows()
        {
            KeyboardInterceptor.Start(HookCallback);
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"
        public void AddShortCut()
        {
            throw new NotImplementedException();
        }

        public void DisableShortCut()
        {
            
        }
        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
             if (nCode >= 0)
            {
                var hookStruct = (KeyboardHook.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KeyboardHook.KBDLLHOOKSTRUCT));
                int keyCode = hookStruct.vkCode;
                Debug.WriteLine($"keycode: {keyCode}, lParam: {lParam}");

                if (wParam == (IntPtr)KeyboardHook.WM_KEYDOWN || wParam == (IntPtr)KeyboardHook.WM_SYSKEYDOWN)
                {
                    //if (keyCode == KeyboardHook.VK_ESCAPE) // Example: intercept the ESC key
                    //{
                    //    Debug.WriteLine("ESC key pressed and handled.");
                    //    return (IntPtr)1;  // Return 1 to mark as handled and stop propagation
                    //}
                    //else 
                    if (keyCode == KeyboardHook.VK_CAPITAL)
                    {
                        Console.WriteLine("Caps Lock key pressed and handled.");
                        _lastKey = KeyboardHook.VK_CAPITAL;
                        return (IntPtr)1;  // Return 1 to mark the event as handled
                    }
                    else if (keyCode == KeySimulator.bVK_LEFT)
                    {
                        if (_lastKey == KeyboardHook.VK_CAPITAL)
                        {
                            Console.WriteLine("Caps Lock key pressed and handled.");
                            KeySimulator.SimulateKeyPress2(KeySimulator.bVK_HOME);
                            return (IntPtr)1;  // Return 1 to mark the event as handled
                        }
                    }
                    else if (keyCode == KeySimulator.bVK_RIGHT)
                    {
                        if (_lastKey == KeyboardHook.VK_CAPITAL)
                        {
                            Console.WriteLine("Caps Lock key pressed and handled.");
                            KeySimulator.SimulateKeyPress2(KeySimulator.bVK_END);
                            return (IntPtr)1;  // Return 1 to mark the event as handled
                        }
                    }
                }
            }

            // If not handling the key, pass the event to the next hook in the chain
            return KeyboardHook.CallNextHookEx(_hook.hookHandle, nCode, wParam, lParam);
        }
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        private static KeyboardHook _hook = new KeyboardHook();

        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}