using System.Text;

class Program
{
    private static byte[] buffer = new byte[4096];
    private static FileStream? fileStream;
    private static StringBuilder contentBuilder = new StringBuilder();

    static void Main(string[] sender)
    {
        string filePath = "source.txt";

        Console.WriteLine("Начало асинхронного чтения файла...");

        fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
        fileStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), fileStream);
        
        Console.WriteLine("Основной поток свободен и ждет завершения чтения. Нажмите Enter для выхода после вывода текста.");
        Console.ReadLine();
    }

    private static void ReadCallback(IAsyncResult asyncResult)
    {
        FileStream? stream = (FileStream)asyncResult.AsyncState;
        int bytesRead = stream.EndRead(asyncResult);

        if (bytesRead > 0)
        {
            string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            contentBuilder.Append(chunk);

            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), stream);
        }
        else
        {
            Console.WriteLine("\n--- Содержимое файла ---");
            Console.WriteLine(contentBuilder.ToString());
            Console.WriteLine("------------------------");

            stream.Close();
            stream.Dispose();
            Console.WriteLine("\nЧтение успешно завершено. Поток закрыт.");
        }
    }
}
