#include <iostream>
#include "Matrix.h"

int main()
{
    const int ROWS{3};
    const int COLUMNS{3};
    Matrix arr{ROWS, COLUMNS};

    int counter{1};
    for (int i{}; i < ROWS; i++)
    {
        for (int j{}; j < COLUMNS; j++)
        { arr(i, j) = counter++; }
    }
    
    arr.print();
    std::cout << "\n";
    arr.deleteColumn(1);
    arr.print();
    arr.addColumn(1, new int[3]{12, 13, 14});
    arr.print();
}
