#include <iostream>
#include "Person.h"

int main()
{
    Person p1{"Seva", 16, 123456};
    p1.print();
    Person p2{"Egort", 17};
    p2.print();
    Person p3{};
    p3.print();

    return 0;
}