#include <iostream>

int main()
{
    const int num{100};

    int i{1};
    for (; i < num; i++)
    {
        int n{};
        std::cout << "Enter a number: ";
        std::cin >> n;

        if(n == 0)
        {
            break;
        }
    }
    std::cout << "Cycle iterations: " << i << "\n";
}
