using System;
using System.Runtime.InteropServices;
using System.Threading;

public class Win32Sound
{
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool Beep(uint dwFreq, uint dwDuration);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MessageBeep(uint uType);

    public const uint MB_OK = 0x00000000;
    public const uint MB_ICONHAND = 0x00000010;
    public const uint MB_ICONASTERISK = 0x00000040;

    public static void Main()
    {
        Console.WriteLine("MessageBeep (Информация)");
        MessageBeep(MB_ICONASTERISK);
        Thread.Sleep(1500);

        Console.WriteLine("500Гц 100мс)");
        Beep(500, 100);
        Thread.Sleep(800);

        Console.WriteLine("900Гц 200мс");
        Beep(900, 200);
        Thread.Sleep(800);

        Console.WriteLine("1350ГЦ 300мс");
        Beep(1350, 300);
        Thread.Sleep(1500);

        Console.WriteLine("MessageBeep (Ошибка)");
        MessageBeep(MB_ICONHAND);
    }
}
