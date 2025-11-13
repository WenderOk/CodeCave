#include <iostream>

// Макросы
#define SQR(X) ((X) * (X)) // Квадрат числа
#define CUDE(X) (SQR(X)*(X)) // Куб числа
#define ABS(X) (((X) < 0) ? -(X) : X) // Модуль числа

int main()
{
    int z{8};

    std::cout << SQR(z + 5) << "\n";
    std::cout << CUDE(5) << "\n";
    std::cout << ABS(-5) << "\n";

    return 0;
}