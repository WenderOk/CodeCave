#include <iostream>

int main()
{
    double t{};

    // std::cout << "Enter temperature: ";
    // std::cin >> t;

    // while (t < 60)
    // {
    //     std::cout << "Enter temperature: ";
    //     std::cin >> t;
    // }

    // std::cout << "Fire!!!\n";

    do
    {
        std::cout << "Enter temperature: ";
        std::cin >> t;
    } while (t < 60);
    
    std::cout << "Fire!!!\n";

    for(int num{1}; num < 100; num++)
    {
        std::cout << num << " ";
    }
    std::cout << "\n";

    return 0;
}