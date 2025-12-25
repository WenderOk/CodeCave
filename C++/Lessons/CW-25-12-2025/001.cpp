#include <iostream>

enum WeekDays { MON = 1, TUE, WEN, THU, FRI, SAT, SUN };

char* GetWeekDay(WeekDays day);

int main()
{
    WeekDays day{ MON };

    enum { MALE, FEMALE } sex { FEMALE };

    if(day == THU)
    {
        std::cout << "Today is Thursday\n";
    }

    // std::cout << "Person gender is " << sex << "\n";
    std::cout << GetWeekDay(day) << "\n";

    int x( MON );
    std::cout << x << "\n";

    day = (WeekDays)5;
    std::cout << day << "\n";

    return 0;
}

char* GetWeekDay(WeekDays day)
{
    switch (day)
    {
        case MON: return "Monday";
        case TUE: return "Tuesday";
        case WEN: return "Wensday";
        case THU: return "Thursday";
        case FRI: return "Friday";
        case SAT: return "Saturday";
        case SUN: return "Sunday";
        default: return "Wrong day number!";
    }
}