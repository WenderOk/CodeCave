#include <iostream>

int global_variable{}; // Глобальная переменная


// Функция счетчик
void counter()
{
    static int count{0}; // Статические локальная переменная
    count++;
    std::cout << count << "\n";
}


int main()
{
    // Статические переменные

    int local_variable{}; // Локальная переменная

    counter();
    counter();
    counter();

    return 0;
}