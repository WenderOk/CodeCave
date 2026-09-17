using System;
using System.Runtime.InteropServices;

public class Win32Controller
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    public const uint WM_SETTEXT = 0x000C;
    public const uint WM_CLOSE = 0x0010;
    public const uint WM_SYSCOMMAND = 0x0112;
    public static readonly IntPtr SC_MAXIMIZE = 0xF030;

    public static void Main()
    {
        Console.Write("\nВведите точный заголовок нужного окна\n(оставьте пустым чтобы использовать WyWindow): ");
        
        string? targetTitle = Console.ReadLine();

        if (targetTitle == "")
        {
            targetTitle = "MyWindow";
            Console.WriteLine("Используется заголовок по умолчанию");
        }

        IntPtr hWnd = FindWindow(null, targetTitle);

        if (hWnd == IntPtr.Zero)
        {
            Console.WriteLine($"\n[Ошибка] Окно с заголовком {targetTitle} не найдено.");
            return;
        }

        Console.WriteLine("Окно найдено!");
        Console.WriteLine("\nВыберите действие:");
        Console.WriteLine("1. Изменить заголовок окна");
        Console.WriteLine("2. Закрыть окно");
        Console.WriteLine("3. Максимизировать окно (развернуть)");
        Console.Write("Ваш выбор (1-3): ");

        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Введите новый заголовок: ");
                string? newTitle = Console.ReadLine();

                SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, newTitle);
                Console.WriteLine("Заголовок изменен");
                break;

            case "2":
                SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                Console.WriteLine("Окно закрыто.");
                break;

            case "3":
                SendMessage(hWnd, WM_SYSCOMMAND, SC_MAXIMIZE, IntPtr.Zero);
                Console.WriteLine("Окно максимизировано.");
                break;

            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}