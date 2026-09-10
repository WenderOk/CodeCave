using System.Diagnostics;

Process proc = new Process();
proc.StartInfo.FileName = "mspaint.exe";

proc.Start();

Console.WriteLine($"Запущен процесс: {proc.ProcessName}");

proc.WaitForExit();

Console.WriteLine($"Завершен процесс: {proc.ExitCode}");
Console.WriteLine($"Имя текущего процесса: {Process.GetCurrentProcess().ProcessName}");
