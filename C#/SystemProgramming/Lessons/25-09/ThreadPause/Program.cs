ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);

ThreadStart ts = new ThreadStart(Method);
Thread t = new Thread(ts);


t.Start();

Console.WriteLine("Press any key to pause program");

for (int i = 0; i < 100; i++)
{
    Console.ReadKey();
    pauseEvent.Reset();

    Console.WriteLine("Thread paused");
    Console.WriteLine("Press any key to resume");
    Console.ReadKey();

    pauseEvent.Set();
}


void Method()
{
    for (int i = 0; i < 100; i++)
    {
        pauseEvent.Wait();
        Console.WriteLine(i);
        Thread.Sleep(1000);
    }
    Console.WriteLine("Thread finished");
}
