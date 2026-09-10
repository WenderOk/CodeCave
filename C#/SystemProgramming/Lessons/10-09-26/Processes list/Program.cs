using System.Diagnostics;
Process[] procArr = Process.GetProcesses();

Console.WriteLine($"{"PID",-8} | {"Имя процесса",-30} | {"Память (МБ)",12}");
Console.WriteLine(new string('-', 58));

 foreach (Process proc in procArr)
{
    try
    {
        double memoryMb = proc.WorkingSet64 / 1024.0 / 1024.0;

        Console.WriteLine($"{proc.Id,-8} | {proc.ProcessName,-30} | {memoryMb,12:N2}");
    }
    catch (Exception)
    {
        Console.WriteLine($"{proc.Id,-8} | {proc.ProcessName,-30} | {"Нет доступа",12}");
    }
}

Console.WriteLine(new string('-', 58));
Console.WriteLine($"Всего процессов: {procArr.Length}");
