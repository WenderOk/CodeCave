Console.WriteLine("Step 1");
Thread.Sleep(1000);
Console.WriteLine("Step 2");

Thread thisThread = Thread.CurrentThread;

Console.WriteLine(thisThread.GetHashCode().ToString());