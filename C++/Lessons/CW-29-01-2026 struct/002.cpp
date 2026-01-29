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
    char weekday[10];
    char mon_name[12];
};

struct person
{
    char name[15];
    int age;
    char city[25];
    date birth_date;
};

int main()
{
    person seva{"Vselovod", 17, "Vyborg", {29, 6, 2008}};
    std::cout << "Name: " << seva.name 
              << "\nAge: " << seva.age
              << "\nCity: " << seva.city
              << "\nBirth date: ";
    seva.birth_date.printStruct();
    return 0;
}
