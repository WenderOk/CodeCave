ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);

ThreadStart ts = new ThreadStart(Method);
Thread t = new Thread(ts);


t.Start();

Console.WriteLine("Press any key to pause program");

Console.ReadKey();

t.Interrupt();
Console.WriteLine("Thread finished");

void Method()
{
    for (int i = 0; i < 100; i++)
    {
        pauseEvent.Wait();
        Console.WriteLine(i);
        Thread.Sleep(1000);
    }
    // try
    // {
    // }
    // finally
    // {
    //     Console.WriteLine("Thread finished");
    // }
}
