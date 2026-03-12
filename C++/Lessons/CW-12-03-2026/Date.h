#include <iostream>

class Date
{
    int day;
    int month;
    int year;

public:
    Date(int dayP, int monthP, int yearP): day{dayP}, month{monthP}, year{yearP}
    { std::cout << "Constructor for: " << this << "\n"; }
    Date():Date(1, 1, 1970)
    {}

    ~Date()
    { std::cout << "Desstructor for: " << this << "\n"; }

    void print() 
    { std::cout << day <<"." << month << "." << year << "\n"; }
    
    Date& setDay(int dayP)
    { 
        day = dayP;
        return *this;
    }
    Date& setMonth(int monthP)
    { 
        month = monthP;
        return *this;
    }
    Date& setYear(int yearP)
    {
         year = yearP;
         return *this;
    }
};


