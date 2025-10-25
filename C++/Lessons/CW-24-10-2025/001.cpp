#include <iostream>

int main()
{
    int width{};
    int hight{};
    char symbol{' '};

    std::cout << "Enter width hight and symbol: ";
    std::cin >> width >> hight;

    for(int j{1}; j <= hight; j++)
    {
        for (int i{1}; i <= width; i++)
        {
            if((i <= j) && (i + j >= width + 1))
                std::cout << "|===|";
            else
                std::cout << "     ";
        }
        std::cout << "\n";
    }

    
    for(int i{}; i < hight; i++)
    {
        for(int j{}; j < width; j++) 
        {
            if(((j == 6 && i == 5) | (j == 6 && i == 5)) && ((i < j) && (i + j > width + 1)))
                std::cout << "     ";    
            else
                std::cout << "|###|";
        }
        std::cout << "\n";
    }

    return 0;
} 