ParameterizedThreadStart threadStart = new ParameterizedThreadStart(ThreadFunc);

Thread thread1 = new Thread(threadStart);
thread1.Start((object)"First");

Thread thread2 = new Thread(threadStart);
thread2.Start((object)"\t\t\tSecond");

void ThreadFunc(object? a)
{
    string? ID = a as string;

    for (int i = 0; i < 100; i++)
        Console.WriteLine(ID);
}
