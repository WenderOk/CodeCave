#include <iostream>

int main()
{
    int total_seconds{};
    int hours{};

    std::cout << "Enter time in seconds: ";
    std::cin >> total_seconds;

    hours = (28800 - total_seconds) / 3600;

    std::cout << "Hours untill the end of working day: " << hours << "\n";

    return 0;
}