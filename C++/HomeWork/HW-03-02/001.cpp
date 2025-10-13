#include <iostream>

int main()
{
    int total_seconds{};
    int hours{}, hours_midnight{};
    int minutes{}, minutes_midnight{};
    int seconds{}, seconds_midnight{};
    int temp{};

    std::cout << "Enter current time in seconds: ";
    std::cin >> total_seconds;

    hours = total_seconds / 3600;
    temp = total_seconds % 3600;
    minutes = temp / 60;
    seconds = temp % 60;

    std::cout << "Current time: " 
              << hours
              << ":" << minutes
              << ":" << seconds
              << "\n";

    temp = 86400 - total_seconds;
    hours_midnight = temp / 3600;
    temp = temp % 3600;
    minutes_midnight = temp / 60;
    seconds_midnight = temp % 60;

    std::cout << "Time to midnight left: " 
              << hours_midnight
              << ":" << minutes_midnight
              << ":" << seconds_midnight
              << "\n";

    return 0;
}