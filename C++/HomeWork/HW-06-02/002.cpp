#include <iostream>

int main()
{
    int count{};

    for(int number{100}; number <= 999; number++)
    {
        int hundreds{number / 100};
        int decades{number / 10 % 10};
        int units{number % 10};

        if((hundreds != decades) && (hundreds != units) && (decades != units))
            count++;
    }

    std::cout << count << "\n";

    return 0;
}