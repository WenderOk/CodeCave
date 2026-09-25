TimerCallback timerCallback = new TimerCallback(TimerTick);

Timer timer = new Timer(timerCallback);

timer.Change(2000, 500);

Console.ReadKey();

void TimerTick(object? state)
{
    Console.WriteLine("сообщение по таймеру");
}