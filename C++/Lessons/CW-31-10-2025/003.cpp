#include <iostream>

int main()
{
    const int rowCount {8};
    const int colCount {8};
    int arr[rowCount][colCount]{
        {1,2,3,4,5,6,7,8},
        {1,2,3,4,5,6,7,8},
        {1,2,3,4,5,6,7,8},
        {1,2,3,4,5,6,7,8},
        {1,2,3,4,5,6,7,8},
        {1,2,3,4,5,6,7,8},
        {1,2,3,4,5,6,7,8},
        {1,2,3,4,5,6,7,8},
    };
    
    for (int r{}; r < rowCount; r++)
    {
        for (int c{}; c < colCount; c++)
        {
            if (r % 2 == 0)
            {
                if (c % 2 == 0)
                {
                    std::cout << "\033[30;47m " << arr[r][c] << " \033[0m";
                }
                else
                {
                    std::cout << "\033[37;40m " << arr[r][c] << " \033[0m";
                }
            }
            else
            {
                if ((c+1) % 2 == 0)
                {
                    std::cout << "\033[30;47m " << arr[r][c] << " \033[0m";
                }
                else
                {
                    std::cout << "\033[37;40m " << arr[r][c] << " \033[0m";
                }
            }
            
            
        }
        std::cout << "\n";
    }

    return 0;
}