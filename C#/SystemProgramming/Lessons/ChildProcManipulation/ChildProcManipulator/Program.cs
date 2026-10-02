using System.Diagnostics;

// var psi = new ProcessStartInfo
// {
//     FileName = "cmd.exe",
//     Arguments = "/c exit 5",
//     UseShellExecute = false
// };

string AssemblyName = "ChildProc.exe";

Process proc = Process.Start(AssemblyName);

proc.WaitForExit();

Console.WriteLine($"Дочерний процесс завершён. Код завершения: {proc.ExitCode}");