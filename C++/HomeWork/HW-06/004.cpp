#include <iostream>

int main()
{
    int res{1};
    int number{};

    std::cout << "Enter a number: ";
    std::cin >> number;

    for(int i{number}; i <= 20; i++)
    {
        res *= i;
    }

    std::cout << res << "\n";

    return 0;
}