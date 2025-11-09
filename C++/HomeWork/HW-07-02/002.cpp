#include <iostream>

int main()
{
    int cell_size{};
    int row_count{8};
    std::cout << "Enter cell size: ";
    std::cin >> cell_size;

    for (int i = 0; i < row_count; i++)
    {
        if (i % 2 == 0)
        {
            for (int m = 0; m < cell_size; m++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j % 2 == 0) for (int k = 0; k < cell_size; k++) std::cout << "\033[37;40m" << "-" << "\033[0m";
                    else for (int k = 0; k < cell_size; k++) std::cout << "\033[30;47m" << "+" << "\033[0m";
                }
                std::cout << "\n";
            }
        }
        else 
        {
            for (int m = 0; m < cell_size; m++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((j+1) % 2 == 0) for (int k = 0; k < cell_size; k++) std::cout << "\033[37;40m" << "-" << "\033[0m";
                    else for (int k = 0; k < cell_size; k++) std::cout << "\033[30;47m" << "+" << "\033[0m";
                }
                std::cout << "\n";
            }
        }
    }
    return 0;
}