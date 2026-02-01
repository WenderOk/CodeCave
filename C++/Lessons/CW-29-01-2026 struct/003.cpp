#include <iostream>

// Структура, представляющая дату
struct date
{
    void printStruct()
    {
       std::cout << day << "." << month << "." << year;     
    }

    int day;
    int month;
    int year;
};

date createDate(int day, int month, int yaer);

int main()
{
    date d{29, 1, 2026};

    // Указатель на структуру
    date* pd{&d};

    // обращение к значению структуры по указателю
    // std::cout << pd->day << "." << pd->month << "." << pd->year;

    date d2{d};

    date d3{createDate(12, 2, 2023)};
    d3.printStruct();

    return 0;
}

date createDate(int day, int month, int yaer)
{
    return {day, month, yaer};
}
