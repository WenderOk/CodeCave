Console.WriteLine("Основной поток: ставим в очередь рабочий элемент");
Random r = new Random();
for (int i = 0; i < 10; ++i)
    ThreadPool.QueueUserWorkItem(WorkingElementMethod, r.Next(10));

Console.WriteLine("Основной поток: выполняем другие задачи");
Thread.Sleep(1000);

Console.WriteLine("Нажмите любую клавишу для продолжения");
Console.ReadLine();

static void WorkingElementMethod(object? state)
{
    Console.WriteLine("\tпоток:{0} состояние = {1}", Thread.CurrentThread.ManagedThreadId, state);
    Thread.Sleep(500);
}