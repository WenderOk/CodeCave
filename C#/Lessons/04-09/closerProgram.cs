using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    // 1. Импортируем функцию поиска дескриптора окна (HWND) по его имени
    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    // 2. Импортируем функцию отправки сообщений окну
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    // Константа Win32 для закрытия окна
    private const uint WM_CLOSE = 0x0010;

    static void Main(string[] args)
    {
        // Имя заголовка окна, которое мы ищем (например, пустой Блокнот)
        string windowTitle = "Безымянный – Блокнот"; 

        Console.WriteLine($"Поиск окна с заголовком: \"{windowTitle}\"...");

        // Ищем окно программы
        IntPtr hWnd = FindWindow(null, windowTitle);

        if (hWnd != IntPtr.Zero)
        {
            Console.WriteLine("Окно найдено! Отправляем команду закрытия...");
            
            // Отправляем сообщение WM_CLOSE окну приложения
            SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            
            Console.WriteLine("Команда успешно отправлена.");
        }
        else
            Console.WriteLine("Ошибка: Окно не найдено. Убедитесь, что программа запущена и заголовок указан верно.");

        Console.ReadKey();
    }
}
