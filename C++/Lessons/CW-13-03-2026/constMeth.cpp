#include <iostream>
#include "Date.h"

int main()
{
    const Date d{13, 3, 2026};
    d.print();

    Date d2{8, 3, 2026};
    d2.print();
    d2.setDay(21).print();

    displayDate(2000);
    Date date{2010};

    return 0;
}