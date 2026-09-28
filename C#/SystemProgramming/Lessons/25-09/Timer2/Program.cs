int Sek = 10;

TimerCallback timerCallback = new TimerCallback(TimerTick);

Timer timer = new Timer(timerCallback);

timer.Change(2000, 500);

Console.ReadKey();

void TimerTick(object? state)
{
    Sek--;
    Console.WriteLine(Sek.ToString());
    if (Sek <= 0)
    {
        Timer? tmr = state as Timer;
        tmr?.Dispose();
    }
}