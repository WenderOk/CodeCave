#pragma once

class Date
{
    int day;
    int month;
    int year;

    // Метод для проверки високосного года
    bool isLeap(int y) const;

    // Дней в конкретном месяце
    int daysInMonth(int m, int y) const;

public:
    Date(int d, int m, int y);

    Date& operator++();
    Date& operator--();

    bool operator==(const Date& d2) const;
    bool operator!=(const Date& d2) const;
    bool operator>(const Date& d2) const;
    bool operator<(const Date& d2) const;

    Date& operator()(int y, int m, int d);

    const Date& operator=(Date& d2);
    Date& operator+=(int days);
    Date& operator-=(int days);

    friend std::ostream& operator<<(std::ostream& out, const Date& d);
    friend std::istream& operator>>(std::istream& in, Date& d);
};