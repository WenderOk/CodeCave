#include <iostream>

int main()
{
    enum week_days{monday = 1, tuesday,wednesday,thursday,friday,saturday,sunday};

    int num{};
    std::cout << "Input number: ";
    std::cin >> num;

    switch (num)
    {
    case monday:
        std::cout << "Monday\n";
        break;
    case tuesday:
        std::cout << "Tuesday\n";
        break;
    case wednesday:
        std::cout << "Wednesday\n";
        break;
    case thursday:
        std::cout << "Thursday\n";
        break;
    case friday:
        std::cout << "Friday\n";
        break;
    case saturday:
        std::cout << "Saturday\n";
        break;
    case sunday:
        std::cout << "Sunday\n";
        break;
    default:
        std::cout << "Wrong number\n";
        break;
    }

    return 0;

}