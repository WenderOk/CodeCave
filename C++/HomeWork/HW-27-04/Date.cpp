#include <iostream>
#include "Date.h"

Date::Date(int d, int m, int y): day{d}, month{m}, year{y}
{}

bool Date::isLeap(int y) const 
{ return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0); }

int Date::daysInMonth(int m, int y) const 
{
    int days[] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    if (m == 2 && isLeap(y)) return 29;
    return days[m - 1];
}

const Date& Date::operator=(Date& d2)
{
    if(this == &d2)
        return *this;
    year = d2.year;
    month = d2.month;
    day = d2.day;

    return *this;
}
Date& Date::operator+=(int days)
{
    day += days;
    while(day > daysInMonth(month, year))
    {
        day -= daysInMonth(month, year);
        if(++month > 12)
        {
            month = 1;
            year++;
        }
    }
    return *this;
}
Date& Date::operator-=(int days)
{
    day -= days;
    while(day <= 0)
    {
        if(--month < 1)
        {
            month = 12;
            year--;
        }
        day += daysInMonth(month, year);
    }
    return *this;
}

Date& Date::operator++()
{
    *this += 1;
    return *this;
}
Date& Date::operator--()
{
    *this -= 1;
    return *this;
}

bool Date::operator==(const Date& d2) const
{ return (year == d2.year && month == d2.month && day == d2.day); }
bool Date::operator!=(const Date& d2) const
{ return !(*this == d2); }
bool Date::operator>(const Date& d2) const
{ return (year > d2.year || month > d2.month || day > d2.day); }
bool Date::operator<(const Date& d2) const
{ return (year < d2.year || month < d2.month || day < d2.day); }

// В задании не уакзано как надо было перегрузить так что сделал просто обновление даты
Date& Date::operator()(int d, int m, int y) 
{
    year = y;
    month = m;
    day = d;
    return *this;
}

std::ostream& operator<<(std::ostream& out, const Date& d)
{
    out << d.day << '.' << d.month << '.' << d.year;
    return out;
}
std::istream& operator>>(std::istream& in, Date& d)
{
    in >> d.day >> d.month >> d.year;
    return in;
}