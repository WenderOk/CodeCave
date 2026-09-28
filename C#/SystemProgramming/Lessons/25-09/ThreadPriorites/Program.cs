ParameterizedThreadStart ts = new ParameterizedThreadStart(Method);

Thread t1 = new Thread(ts);
Thread t2 = new Thread(ts);

t1.Priority = ThreadPriority.Highest;
t2.Priority = ThreadPriority.Lowest;

t2.Start((object)"\t\t\tt2");
t1.Start((object)"t1");

void Method(object? a)
{
    string? text = a as string;

    for (int i = 0; i < 500; i++)
        Console.WriteLine("{0} #{1}", text, i.ToString());
}
