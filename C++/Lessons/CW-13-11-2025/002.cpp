#include <iostream>

const double pi(3.14); // Глобальная константа

int global_variable{}; // Глобальная переменная


// Функция счетчик
inline void counter()
{
    static int count{}; // Статические локальная переменная
    count++;
    std::cout << count << "\n";
}


int main()
{
    // Статические переменные

    double local_variable{pi}; // Локальная переменная

    std::cout << local_variable << "\n";

    return 0;
}