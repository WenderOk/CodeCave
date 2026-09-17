using System;
using System.Runtime.InteropServices;

public class Win32
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    public const uint MB_OK = 0x00000000;
    public const uint MB_ICONINFORMATION = 0x00000040;
}

public class Program
{
    public static void Main()
    {
        Win32.MessageBox(
            IntPtr.Zero,
            "Георгий", 
            "Часть 1",
            Win32.MB_OK | Win32.MB_ICONINFORMATION
        );

        Win32.MessageBox(
            IntPtr.Zero,
            "18 лет,\nНа 3 курсе колледжа", 
            "Часть 2",
            Win32.MB_OK | Win32.MB_ICONINFORMATION
        );

        int res = Win32.MessageBox(
            IntPtr.Zero,
            "Интересуюсь Linux",
            "Часть 3",
            Win32.MB_OK | Win32.MB_ICONINFORMATION
        );
    }
}