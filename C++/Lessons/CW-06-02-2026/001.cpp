#include <iostream>

struct statusField
{
    unsigned int JS: 1;
    unsigned int PHP: 1;
    unsigned int Python: 1;
};

struct fieldBite
{
    unsigned short field1: 2;
    unsigned short field2: 2;
    unsigned short field3: 4;
};

struct Date
{
    unsigned short weekDay: 3;
    unsigned short monthDay: 6;
    unsigned short month: 5;
    unsigned short year: 2;
};

struct DateTime
{
    unsigned short DayNum: 5;
    unsigned short MonthNum: 4;
    unsigned short YearNum: 7;
    unsigned short HourNum: 5;
    unsigned short MinuteNum: 6;
    unsigned short SecondNum: 6;
};

int main()
{
    // statusField fieldo{};
    // std::cout << sizeof(fieldo) << "\n";

    // fieldBite fioldo{};
    // std::cout << sizeof(fioldo) << "\n";

    // Date newDate{};
    // std::cout << sizeof(newDate) << "\n";

    DateTime d{};
    int i{};

    std::cout << "Enter day: ";
    std::cin >> i;
    d.DayNum = i;
    std::cout << "Enter month: ";
    std::cin >> i;
    d.MonthNum = i;
    std::cout << "Enter year: ";
    std::cin >> i;
    d.YearNum = i;
    std::cout << "Enter second: ";
    std::cin >> i;
    d.SecondNum = i;
    std::cout << "Enter minute: ";
    std::cin >> i;
    d.MinuteNum = i;
    std::cout << "Enter hour: ";
    std::cin >> i;
    d.HourNum = i;
    std::cout << "Current datetime: " << d.DayNum << "." << d.MonthNum << ".20" << d.YearNum << " " << d.HourNum << ":" << d.MinuteNum << ":" << d.SecondNum;

    return 0;
}
