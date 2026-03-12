#include <iostream>
#include "Point.h"
#include "NumberStorage.h"
#include "Date.h"
#include "Fraction.h"

int main()
{
    // Point p1(2, 5);
    // Point p2(4, 7);
    
    // p1.print();
    // p2.print();

    // std::cout << Point::PI;

    // std::cout << &(p2.x) << "\n";
    // std::cout << &(p1.PI) << "\n";
    
    // std::cout << &(p2.x) << "\n";
    // std::cout << &(p2.PI) << "\n";

    // std::cout << "Used memory: " << NumberStorage::getUsedMem() << "\n\n";

    // NumberStorage ns1{5};
    // NumberStorage ns2{2};
    // NumberStorage ns3{10};
    // std::cout << "\n";
    // std::cout << "Used memory: " << ns1.getUsedMem() << "\n";
    // std::cout << "\n";

    // Date d1;
    
    // d1.setDay(12);
    // d1.setMonth(3);
    // d1.setYear(2026);

    // d1.print();
    // Date d2;
    // d1.setDay(23).setMonth(4).setYear(2017);
    // d1.print();

    Fraction f1{1,3};
    Fraction f2{f1};
    f1.print();
    f2.print();


    return 0;
}