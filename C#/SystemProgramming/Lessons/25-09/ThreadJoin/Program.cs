ThreadStart ts = new ThreadStart(Method);

Thread t = new Thread(ts);

Console.WriteLine("Starting thread 1");
t.Start();

Thread.Sleep(200);

Console.WriteLine("Waiting thread to stop");
t.Join(); // Ожидает пока завершиться второстепенный поток

Console.WriteLine("Finishing program");
Console.ReadKey();

void Method()
{
    Console.WriteLine("Thread is working");
    Thread.Sleep(2000);
    Console.WriteLine("Thread has finished work");
}