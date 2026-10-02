using System.Diagnostics;

Console.Write("Введите 1 для принудительного завершения процесса ");
int choice = int.Parse(Console.ReadLine()!);

string AssemblyName = "ChildProc.exe";

Process proc = Process.Start(AssemblyName);

Console.WriteLine($"Запущен дочерний процесс, PID = {proc.Id}");

if (choice == 1)
{
    Console.WriteLine("Принудительное завершение дочернего процесса...");
    proc.Kill();
    proc.WaitForExit();
    Console.WriteLine($"Процесс завершён. Код завершения: {proc.ExitCode}");
}
else
{
    Console.WriteLine("Ожидание завершения дочернего процесса...");
    proc.WaitForExit();
    Console.WriteLine($"Процесс завершён. Код завершения: {proc.ExitCode}");
}