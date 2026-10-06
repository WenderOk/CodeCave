using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = "source.txt";

        Console.WriteLine("Начало асинхронного чтения файла (TAP)...");

        // Метод ReadAllTextAsync автоматически открывает поток, читает его и закрывает
        string content = await File.ReadAllTextAsync(filePath, Encoding.UTF8);

        Console.WriteLine("\n--- Содержимое файла ---");
        Console.WriteLine(content);
        Console.WriteLine("------------------------");
        Console.WriteLine("\nЧтение успешно завершено.");

        Console.WriteLine("Основной поток завершает работу. Нажмите любую клавишу...");
        Console.ReadKey();
    }
}
