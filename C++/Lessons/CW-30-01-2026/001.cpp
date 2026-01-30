#include <iostream>

struct date
{
    int day ;
    int month;
    int year;
}; 
struct group
{
    char ch[5];
    int num;
};

int main()
{
    date d{30, 1, 2026};

    group g{9, 'abob'};

    // Вывод размера объекта структуры (в байтах)
    std::cout << "Size of date struct: " << sizeof(d) << "\n";
    std::cout << "Size of group struct: " << sizeof(g)  << "\n";
    std::cout << "Size of group struct: " << sizeof(bool)  << "\n";

    return 0;
}