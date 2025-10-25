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
            if(i==j)
                std::cout << "\\";
            else if(i + j == width + 1)
                std::cout << "/";
            else if((i < j) && (i + j > width + 1))
                std::cout << " # ";
            else
                std::cout << " " << symbol << " ";
        }
        std::cout << "\n";
    }

    return 0;
}