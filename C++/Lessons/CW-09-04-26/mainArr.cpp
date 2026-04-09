#include <iostream>
#include "Array2.h"

int main()
{
    const int ROWS{3};
    const int COLUMNS{3};
    Array2 arr{ROWS, COLUMNS};

    int counter{1};
    for (int i{}; i < ROWS; i++)
    {
        for (int j{}; j < COLUMNS; j++)
        {
            arr.data[i][j] = counter;
            counter++;
        }
    }
    
    arr.print();
    
}
