using System;
using System.Runtime.InteropServices; // Необходим для работы с DllImport

class Program
{
    // Импортируем функцию MessageBoxW (Unicode-версию) из системной библиотеки user32.dll
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    static void Main()
    {
        // Константы для настройки внешнего вида окна
        uint MB_OK = 0x00000000;            // Кнопка OK
        uint MB_ICONINFORMATION = 0x00000040; // Иконка "Информация"

        // Комбинируем флаги с помощью побитового ИЛИ (|)
        uint windowType = MB_OK | MB_ICONINFORMATION;

        // Вызываем WinAPI функцию
        MessageBox(IntPtr.Zero, "Hello, world", "Заголовок окна", windowType);
    }
}
