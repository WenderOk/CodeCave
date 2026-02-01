#include <iostream>
#include <cstring>

// Структура, представляющая дату
struct date
{
    // метод структуры?
    void printStruct()
    {
       std::cout << day << "." << month << "." << year;     
    }
    
    int day;
    int month;
    int year;
    int weekday;
    char mon_name[12];
};

void printItem(int repeats, char item);

int main()
{
    // Создание объекта структуры date без инициализации
    date d;

    // Создание объекта структуры date с инициализацией
    date new_day{12, 3, 32, 45, "December"};

    // Изменение значений полей структуры
    d.year = 2008;
    strcpy(d.mon_name, "August");
    printItem(20, '-');
    new_day.printStruct();
    std::cout << "\n"; 
    printItem(20, '-');

    std::cout << "date: ";
    std::cin >> d.day >> d.month >> d.year;

    d.printStruct();

    return 0;
}

void printItem(int repeats, char item)
{
    for(int i{}; i < repeats; i++)
        std::cout << item;
    std::cout << "\n"; 
}