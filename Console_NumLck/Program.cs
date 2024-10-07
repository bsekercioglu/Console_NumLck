using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Console_NumLck
{
    internal class Program
    {
        // Windows API fonksiyonu keybd_event
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        // Sanal tuş kodları (NumLock için)
        const byte VK_NUMLOCK = 0x90;
        const uint KEYEVENTF_EXTENDEDKEY = 0x1;
        const uint KEYEVENTF_KEYUP = 0x2;

        static void Main(string[] args)
        {
            // Eğer NumLock aktif değilse, NumLock tuşuna bas ve aktif hale getir
            if (!IsNumLockOn())
            {
                PressNumLockKey();
                Console.WriteLine("NumLock aktif hale getirildi.");
            }
            else
            {
                Console.WriteLine("NumLock zaten aktif.");
            }

            Console.ReadKey();
        }

        // NumLock durumunu kontrol et
        static bool IsNumLockOn()
        {
            // GetKeyState fonksiyonu ile NumLock durumunu kontrol et
            return (GetKeyState(VK_NUMLOCK) & 0x0001) != 0;
        }

        // NumLock tuşuna basma ve bırakma işlemi
        static void PressNumLockKey()
        {
            // NumLock tuşunu basılı tut
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);
            // NumLock tuşunu serbest bırak
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, UIntPtr.Zero);
        }
    }
}
