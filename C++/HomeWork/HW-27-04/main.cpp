#include <iostream>
#include <string>
#include "Date.h"

int main(int argc, char* argv[]) 
{
    if (argc < 2) 
    {
        std::cout << "Usage: " << argv[0] << " [MODE]" << "\n"
                  << "--io - Test input-output\n"
                  << "--math - Test mathematic operations\n"
                  << "--inc - Test increment and decrement\n"
                  << "--set - Test set by () operator\n";
        return 1;
    }

    std::string mode = argv[1];
    Date d{27, 4, 2026};

    if (mode == "--io") 
    {
        // Тест ввода-вывода
        std::cout << "Current date: " << d << "\n";
        std::cout << "Enter new date (D M Y): ";
        std::cin >> d;
        std::cout << "New date is: " << d << "\n";

    } else if (mode == "--math") 
    {
        // Тест += и -=
        std::cout << "Current: " << d << "\n";
        d += 10;
        std::cout << "+10 days: " << d << "\n";
        d -= 15;
        std::cout << "-15 days: " << d << "\n";

    } else if (mode == "--inc") 
    {
        // Тест инкремента и декремента
        std::cout << "Current: " << d << "\n";
        std::cout << "Pre-inc (++d): " << ++d << "\n";
        std::cout << "Pre-dec (--d): " << --d << "\n";

    } else if (mode == "--set") 
    {
        // Тест оператора ()
        std::cout << "Current: " << d << "\n";
        d(31, 12, 2025);
        std::cout << "After d(31, 12, 2025): " << d << "\n";

    } else 
    {
        std::cerr << "Unknown mode: " << mode << "\n";
        return 1;
    }

    return 0;
}
