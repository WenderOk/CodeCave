#include <iostream>
#include <limits>

int main()
{
    const int rowCount {8};
    const int colCount {8};
    int arr[rowCount][colCount]{
        {1, 2, 675, 4, 5, 6, 7, 8},
        {1, 2, 3, 243, 5, 6, 7, 8},
        {1, 2, 3, 4, 5, 123, 7, 8},
        {1, 2, 3, 4, 12, 6, 7, 8},
        {1, 2, 3, 4, 5, 6, 7, 8},
        {1, 2, 3, 4, 5, 6, 7, 8},
        {1, 2, 3, 4, 5, 6, 23, 8},
        {1, 34, 3, 4, 5, 6, 7, 8},
    };
    
    for (int r{}; r < rowCount; r++)
    {
        int max{std::numeric_limits<int>::min()};
        for (int c{}; c < colCount; c++)
        {
            if (arr[c][r] > max)
                max = arr[c][r];
        }
        std::cout << "Max: " << max << "\n";
    }

    return 0;
}