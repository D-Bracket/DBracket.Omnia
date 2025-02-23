using System.Runtime.InteropServices;

namespace DBracket.Omnia.Logic.Windows.KeyBoardControl
{
    internal class KeySimulator
    {
        #region "----------------------------- Private Fields ------------------------------"
        // Virtual key codes
        public const int bVK_HOME = 0x24;
        public const int bVK_END = 0x23;
        public const int bVK_Up = 0x26;
        public const int bVK_RIGHT = 0x27;
        public const int bVK_DOWN = 0x28;
        public const int bVK_LEFT = 0x25;
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

        // Structure for keyboard input
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint type;
            public MOUSEKEYBDINPUT ki;
        }

        // Structure for keyboard input event
        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEKEYBDINPUT
        {
            public uint dwFlags;
            public ushort wVk;
            public ushort wScan;
            public uint time;
            public uint dwExtraInfo;
        }

        // Constants for input type and key event flags
        public const uint INPUT_KEYBOARD = 1;
        public const uint KEYEVENTF_KEYDOWN = 0x0000;
        public const uint KEYEVENTF_KEYUP = 0x0002;

        // Import SendInput function
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);


        //public static void Main()
        //{
        //    // Simulate pressing and releasing the Home key
        //    SimulateKeyPress(VK_HOME);
        //}
        public static void SimulateKeyPress2(byte vkCode)
        {
            // Press the key (KEYDOWN)
            keybd_event(vkCode, 0, KEYEVENTF_KEYDOWN, 0);
            Console.WriteLine("Home key pressed (KEYDOWN)");

            // Release the key (KEYUP)
            keybd_event(vkCode, 0, KEYEVENTF_KEYUP, 0);
            Console.WriteLine("Home key released (KEYUP)");
        }










        public static void SimulateKeyPress(int vkCode)
        {
            // Create the INPUT structure for the key press
            INPUT[] inputs = new INPUT[2];

            // Key down event
            inputs[0] = new INPUT
            {
                type = INPUT_KEYBOARD,
                ki = new MOUSEKEYBDINPUT
                {
                    dwFlags = KEYEVENTF_KEYDOWN,
                    wVk = (ushort)vkCode
                }
            };

            // Key up event
            inputs[1] = new INPUT
            {
                type = INPUT_KEYBOARD,
                ki = new MOUSEKEYBDINPUT
                {
                    dwFlags = KEYEVENTF_KEYUP,
                    wVk = (ushort)vkCode
                }
            };

            // Send the input events
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }
}