#pragma warning disable SYSLIB0014

using System.Net;
using System.Text;
using System.Text.RegularExpressions;

const string ftpHost = "ftp://eu-central-1.sftpcloud.io"; 
const string username = "df5e033c5b7f42b9815db75bd26c1f01";   
const string password = "veig4hvpvoE5moePm9DgUHknx4Lzfdmb";   

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

while (true)
{
    Console.Clear();
    Console.WriteLine("=== УПРАВЛЕНИЕ ФАЙЛАМИ НА FTP ===");
    Console.WriteLine("1. Список файлов на сервере");
    Console.WriteLine("2. Создать (загрузить) файл");
    Console.WriteLine("3. Просмотреть содержимое файла");
    Console.WriteLine("4. Удалить файл");
    Console.WriteLine("0. Выход");
    Console.Write("\nВыберите действие: ");

    string? choice = Console.ReadLine();

    if (choice == "0")
    {
        break;
    }

    try
    {
        switch (choice)
        {
            case "1":
                ListFiles();
                break;

            case "2":
                string? createName = AskFileName();
                if (createName != null)
                {
                    Console.Write("Введите текст для записи в файл: ");
                    string content = Console.ReadLine() ?? string.Empty;
                    UploadFile(createName, content);
                }
                break;

            case "3":
                string? readName = AskFileName();
                if (readName != null)
                {
                    ReadFile(readName);
                }
                break;

            case "4":
                string? deleteName = AskFileName();
                if (deleteName != null)
                {
                    DeleteFile(deleteName);
                }
                break;

            default:
                Console.WriteLine("Неверный пункт меню.");
                break;
        }
    }
    catch (WebException ex)
    {
        Console.WriteLine($"\nОшибка FTP: {ex.Message}");
        if (ex.Response is FtpWebResponse response)
        {
            Console.WriteLine($"Статус сервера: {response.StatusDescription.Trim()}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nОбщая ошибка: {ex.Message}");
    }

    Pause();
}


void ListFiles()
{
    FtpWebRequest request = CreateFtpRequest(string.Empty, WebRequestMethods.Ftp.ListDirectoryDetails);

    using var response = (FtpWebResponse)request.GetResponse();
    using Stream responseStream = response.GetResponseStream();
    using var reader = new StreamReader(responseStream, Encoding.UTF8);

    string rawList = reader.ReadToEnd();
    string[] lines = rawList.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

    Console.WriteLine("\n--- Список файлов на сервере ---");
    
    if (lines.Length == 0)
    {
        Console.WriteLine("(Папка пуста)");
        Console.WriteLine("--------------------------------");
        return;
    }

    var unixRegex = new Regex(@"^(?<dir>[\-d])(?<perms>(?:[\-r][\-w][\-xs]){3})\s+\d+\s+\S+\s+\S+\s+(?<size>\d+)\s+\w+\s+\d+\s+[\d:]+\s+(?<name>.+)$");

    var winRegex = new Regex(@"^\d{2}-\d{2}-\d{2,4}\s+\d{2}:\d{2}[AP]M\s+(?<dir><DIR>)?\s*(?<size>\d+)?\s+(?<name>.+)$");

    Console.WriteLine($"{"Имя файла",-30} | {"Размер",12}");
    Console.WriteLine(new string('-', 45));

    foreach (string line in lines)
    {
        Match match = unixRegex.Match(line);
        if (match.Success)
        {
            bool isDir = match.Groups["dir"].Value == "d";
            string name = match.Groups["name"].Value;
            string size = isDir ? "<ПАПКА>" : FormatSize(long.Parse(match.Groups["size"].Value));

            Console.WriteLine($"{name,-30} | {size,12}");
            continue;
        }

        match = winRegex.Match(line);
        if (match.Success)
        {
            bool isDir = match.Groups["dir"].Success;
            string name = match.Groups["name"].Value;
            string size = isDir ? "<ПАПКА>" : FormatSize(long.Parse(match.Groups["size"].Value));

            Console.WriteLine($"{name,-30} | {size,12}");
            continue;
        }

        Console.WriteLine(line);
    }
    Console.WriteLine(new string('-', 45));
}

string FormatSize(long bytes)
{
    if (bytes < 1024) return $"{bytes} Б";
    if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} КБ";
    return $"{bytes / (1024.0 * 1024.0):F1} МБ";
}


void UploadFile(string fileName, string content)
{
    FtpWebRequest request = CreateFtpRequest(fileName, WebRequestMethods.Ftp.UploadFile);

    byte[] fileContents = Encoding.UTF8.GetBytes(content);
    request.ContentLength = fileContents.Length;

    using (Stream requestStream = request.GetRequestStream())
    {
        requestStream.Write(fileContents, 0, fileContents.Length);
    }

    using var response = (FtpWebResponse)request.GetResponse();
    Console.WriteLine($"\nФайл '{fileName}' успешно создан. Ответ сервера: {response.StatusDescription.Trim()}");
}

void ReadFile(string fileName)
{
    FtpWebRequest request = CreateFtpRequest(fileName, WebRequestMethods.Ftp.DownloadFile);

    using var response = (FtpWebResponse)request.GetResponse();
    using Stream responseStream = response.GetResponseStream();
    using var reader = new StreamReader(responseStream, Encoding.UTF8);

    string content = reader.ReadToEnd();
    Console.WriteLine($"\n--- Содержимое файла '{fileName}' ---");
    Console.WriteLine(content);
    Console.WriteLine("-------------------------------------");
}

void DeleteFile(string fileName)
{
    FtpWebRequest request = CreateFtpRequest(fileName, WebRequestMethods.Ftp.DeleteFile);

    using var response = (FtpWebResponse)request.GetResponse();
    Console.WriteLine($"\nФайл '{fileName}' удален. Ответ сервера: {response.StatusDescription.Trim()}");
}

FtpWebRequest CreateFtpRequest(string targetPath, string method)
{
    // Если путь пустой (для списка файлов), используем корень сервера, иначе добавляем имя файла
    string uri = string.IsNullOrEmpty(targetPath) 
        ? $"{ftpHost}/" 
        : $"{ftpHost}/{targetPath}";

    var request = (FtpWebRequest)WebRequest.Create(uri);

    request.Method = method;
    request.Credentials = new NetworkCredential(username, password);
    request.UsePassive = true;
    return request;
}

string? AskFileName()
{
    Console.Write("Введите имя файла (например, test.txt): ");
    string? fileName = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(fileName))
    {
        Console.WriteLine("Имя файла не может быть пустым!");
        return null;
    }

    return fileName;
}

void Pause()
{
    Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
    Console.ReadKey();
}
