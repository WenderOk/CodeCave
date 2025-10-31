#include <iostream>
#include <cstdlib>
#include <ctime>

int main()
{
    const int num {100};
    int arr[num]{};
    std::srand(std::time({}));
    int rborder{};
    int lborder{};

    std::cout << "Enter left and right borders: ";
    std::cin >> lborder >> rborder;

    for(int i{}; i < num; i++)
    {
        arr[i] = std::rand() % rborder + lborder;
    }

    for(int i{}; i < num; i++)
    {
        std::cout << arr[i] << " ";
    }
    

    return 0;
}