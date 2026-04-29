#include <iostream>
#include <string>
// #include "List.h"
#include "Matrix.h"

int main()
{
    const int height{2};
    const int width{3};

    Matrix<int, height, width> intMatrix;
    intMatrix(0,0) = 1;
    intMatrix(0,1) = 2;
    intMatrix(0,2) = 3;
    intMatrix(1,0) = 4;
    intMatrix(1,1) = 5;
    intMatrix(1,2) = 6;
    std::cout << intMatrix.getMin() << '\n';
    std::cout << intMatrix.getMax() << '\n';

    Matrix<std::string, height, width> strMatrix;
    strMatrix(0,0) = "five";
    strMatrix(0,1) = "one";
    strMatrix(0,2) = "nine";
    strMatrix(1,0) = "eleven";
    strMatrix(1,1) = "evelen";
    strMatrix(1,2) = "nineteen";
    std::cout << strMatrix.getMin() << '\n';
    std::cout << strMatrix.getMax() << '\n';

    Matrix<const char*, height, width> chrMatrix;
    chrMatrix(0,0) = "five";
    chrMatrix(0,1) = "one";
    chrMatrix(0,2) = "nine";
    chrMatrix(1,0) = "eleven";
    chrMatrix(1,1) = "evelen";
    chrMatrix(1,2) = "nineteen";
    std::cout << chrMatrix.getMin() << '\n';
    std::cout << chrMatrix.getMax() << '\n';

    return 0;
}