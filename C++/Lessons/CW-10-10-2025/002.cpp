#include <iostream>

int main()
{
    int a{};
    int b{};

    std::cout << "Enter numbers (a b): ";
    std::cin >> a >> b;

    (b != 0) ? std::cout << "a / b = " << a / b << "\n"
             : std::cout << "You can't divide by zero!\n";

    return 0;
}