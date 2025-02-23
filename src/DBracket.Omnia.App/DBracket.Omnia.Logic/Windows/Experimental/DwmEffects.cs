using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SNMP_Test.TilingWinodwManager
{
    public class DwmEffects
    {
        // Import DWM functions
        [DllImport("dwmapi.dll")]
        public static extern int DwmEnableBlurBehindWindow(IntPtr hwnd, ref DWM_BLURBEHIND pBlurBehind);

        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_BLURBEHIND
        {
            public uint dwFlags;
            public bool fEnable;
            public IntPtr hRgnBlur;
            public uint fTransitionOnMaximized;
        }

        // Constants for DWM flags
        const uint DWM_BB_ENABLE = 0x00000001;
        const uint DWM_BB_BLURREGION = 0x00000002;
        const uint DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004;

        public static void EnableWindowBlur(IntPtr hwnd)
        {
            DWM_BLURBEHIND blurBehind = new DWM_BLURBEHIND
            {
                dwFlags = DWM_BB_ENABLE,
                fEnable = true,
                hRgnBlur = IntPtr.Zero, // No region (apply to entire window)
                fTransitionOnMaximized = 0
            };

            DwmEnableBlurBehindWindow(hwnd, ref blurBehind);
        }

        public static void DisableWindowBlur(IntPtr hwnd)
        {
            DWM_BLURBEHIND blurBehind = new DWM_BLURBEHIND
            {
                dwFlags = DWM_BB_ENABLE,
                fEnable = false,
                hRgnBlur = IntPtr.Zero, // No region (apply to entire window)
                fTransitionOnMaximized = 0
            };

            DwmEnableBlurBehindWindow(hwnd, ref blurBehind);
        }
    }
}