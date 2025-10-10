#include <iostream>

int main()
{
    int a{};
    int b{};

    std::cout << "Enter numbers (a b): ";
    std::cin >> a >> b;
    
    int max{ (a > b ? a : b) };
    int min{ (a < b ? a : b) };

    std::cout << "Maximum: " << max << "\n"; 
    std::cout << "Minimum: " << min << "\n"; 

    return 0;
}