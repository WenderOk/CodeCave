#include <iostream>

class Date
{
    int day;
    int month;
    int year;

public:
    Date(int dayP, int monthP, int yearP): day{dayP}, month{monthP}, year{yearP}
    {}
    Date(int year): Date(1, 1, year)
    {}
    Date():Date(1, 1, 1970)
    {}

    ~Date()
    { }

    friend void displayDate(Date date)
    {
        { std::cout << date.day <<"." << date.month << "." << date.year << "\n"; }    
    }

    Date baseDate()
    { return 2000; }

    void print() const
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
    int getDay()
    {return day;}

};


