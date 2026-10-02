// альтернатива Thread.Suspend() и Thread.Resume()
// светофор: зеленый свет (параметр true)
ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);

// создать делегата, который будет связан с методом шифрования или дешифрования
ParameterizedThreadStart? Param = null;

while (true)
{
    // меню, где пользователю предлогается выбрать действие
    Console.Clear();
    Console.WriteLine("1. Шифровать");
    Console.WriteLine("2. Дешифровать");
    
    ConsoleKeyInfo Select = Console.ReadKey(true);
    Console.Clear();

    Param = new ParameterizedThreadStart(Encryption); // по умолчанию
    if (ConsoleKey.D1 == Select.Key)
    {
        // если выбрано шифрование, связать делегат с методом шифрования
        Param = new ParameterizedThreadStart(Encryption);
        Console.WriteLine("Введите путь к файлу, который хотите зашифровать");
    }
    else if(ConsoleKey.D2 == Select.Key)
    {
        // если выбрано дешифрование, связать делегат с методом дешифрования
        Param = new ParameterizedThreadStart(Decryption);
        Console.WriteLine("Введите путь к файлу, который хотите расшифровать");
    }

    if(ConsoleKey.D1 == Select.Key || ConsoleKey.D2 == Select.Key)
    {
        // пользователь вводит путь к файлу, с которым собирается работать
        string? FilePath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(FilePath))
            throw new ArgumentException("Путь к файлу указан неверно или отсутствует");
        
        // создать поток, который будет шифровать или дешифровать
        Thread thread = new Thread(Param);

        // запустить поток, в параметр передать путь к файлу
        thread.Start((object)FilePath);

        Console.WriteLine("Нажмите символ, чтобы выполнить действие");
        do
        {
            // в цикле пользователю предлагаются выбрать действие с потоком
            Console.WriteLine("[c] Отменить работу потока");
            Console.WriteLine("[p] Приостановить или возобновить работу потока");
            ConsoleKeyInfo Selects = Console.ReadKey(true);

            if (Selects.Key == ConsoleKey.C)
            {
                if (thread.ThreadState == ThreadState.Running)
                {
                    // если поток выполнялся и пользователь выбрал завершение
                    //thread.Abort();// завершить работу потока (устарело)
                    thread.Interrupt(); // альтернатива
                    Console.WriteLine("Поток остановлен");
                }
            }
            else if (Selects.Key == ConsoleKey.P)
            {
                if (thread.ThreadState == ThreadState.Running)
                {
                    // если поток выполнялся и пользователь выбрал приостановку
                    // устарело, считается опасным для использования
                    //thread.Suspend(); // приостанавить поток
                    pauseEvent.Reset(); // альтернатива (светофор: красный свет)
                    Console.WriteLine("Поток приостановлен");
                }
                else if (thread.ThreadState == ThreadState.Suspended) 
                {
                    // если поток остановлен и пользователь выбрал возобновление
                    // устарело, считается опасным для использования
                    //thread.Resume(); // возобновить поток
                    pauseEvent.Set(); // альтернатива (светофор: зеленый свет)
                    Console.WriteLine("Поток восстановил работу");
                }
                Thread.Sleep(100);
            }

            // если поток приостановлен или работает, то показать это меню пользователю еще раз
        } while (thread.ThreadState == ThreadState.Suspended || thread.ThreadState == ThreadState.Running);

        Console.ReadKey(true);
        Console.Clear();
    }
}

// метод шифрования
void Encryption(object? ObjFilePath)
{
    
    FileStream? RFile = null;
    FileStream? WFile = null;

    try
    {
        string? FilePath = ObjFilePath as string;
        if (string.IsNullOrWhiteSpace(FilePath))
            throw new ArgumentException("Путь к файлу указан неверно или отсутствует");
        RFile = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        
        string NewFile = FilePath + ".cryp";
        WFile = new FileStream(NewFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        Console.WriteLine("Процесс начался");
        
        for (long i = 0; i < RFile?.Length; i++)
        { 
            pauseEvent.Wait(); // альтернатива (контрольная точка)

            byte One = (byte)RFile.ReadByte();
            One = (byte)~One;
            WFile.WriteByte(One);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Шифрование успешно завершено");
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ошибка при шифровании: " + ex.Message);
        
    }
    finally
    {
        Console.ResetColor();
        RFile?.Close();
        WFile?.Close();
        Console.WriteLine("Поток завершил свою работу");
        Console.WriteLine("Нажмите любую клавишу для продолжения");
    }
}

// метод дешифрования
void Decryption(object? ObjFilePath)
{
    FileStream? RFile = null;
    FileStream? WFile = null;

    try
    {
        string? FilePath = ObjFilePath as string;
        if (string.IsNullOrWhiteSpace(FilePath))
            throw new ArgumentException("Путь к файлу указан неверно или отсутствует");
        RFile = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        
        string NewFile = FilePath.Substring(0, FilePath.Length - 5);
        WFile = new FileStream(NewFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
        Console.WriteLine("Процесс начался");
        for (long i = 0; i < RFile.Length; i++)
        {
            pauseEvent.Wait(); // альтернатива (контрольная точка)

            byte One = (byte)RFile.ReadByte();
            One = (byte)~One;
            WFile.WriteByte(One);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Дешифрование успешно завершено");
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Ошибка при дешифровании: " + ex.Message);

    }
    finally
    {
        Console.ResetColor();
        RFile?.Close();
        WFile?.Close();
        Console.WriteLine("Поток завершил свою работу");
        Console.WriteLine("Нажмите любую клавишу для продолжения");
    }
}
