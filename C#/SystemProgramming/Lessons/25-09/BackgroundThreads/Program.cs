ThreadStart ts = new ThreadStart(Method);
Thread t = new Thread(ts);

t.IsBackground = true;

t.Start();

Console.WriteLine("Press any key to finish program");
Console.ReadKey();

void Method()
{
    for (int i = 10; i >= 0; i--)
    {
        Thread.Sleep(1000);
        Console.Write(i.ToString() + " ");
    }
    Console.WriteLine("Thread finished");
}
