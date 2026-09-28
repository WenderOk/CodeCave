ThreadStart threadStart = new ThreadStart(Method);

Thread thread = new Thread(threadStart);
thread.Start();

for (int i = 0; i < 100; i++)
    Console.WriteLine($"Hello {i} from main thread");

void Method()
{
    for (int i = 0; i < 100; i++)
        Console.WriteLine($"\t\t\t\t\t\tHello {i} from other thread");
}
