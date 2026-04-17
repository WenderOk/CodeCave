#include <iostream>
#include "Fraction.h"

Fraction operator+(Fraction frac1, Fraction frac2)
{
    return { frac1.getNum() * frac2.getDen() + frac2.getNum() * frac1.getDen(),
            frac1.getDen() * frac2.getDen() };
}

int main()
{
    Fraction f1{1,2};
    Fraction f2{3,4};
    Fraction sum{};
    sum = f1 + f2;
    sum.print();

    return 0;
}