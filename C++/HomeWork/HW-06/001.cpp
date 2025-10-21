#include <iostream>

int main()
{
    int res{};
    int number{};

    std::cout << "Enter a number: ";
    std::cin >> number;

    for(int i{number}; i < 500; i++)
    {
        res += i;
    }

    std::cout << res << "\n";

    return 0;
}