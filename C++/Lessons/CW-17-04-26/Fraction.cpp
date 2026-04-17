#include <iostream>
#include "Fraction.h"

Fraction& Fraction::print()
{ 
    (denominator < 0) ?                 // Если знаменатель отрицательный, то в выводе выносим знак "-"" за скобки
    std::cout << "-(" << numerator << "/" << (denominator*-1) << ")\n" : 
    std::cout << numerator << "/" << denominator << "\n";
    return *this;
}

Fraction& Fraction::setNum(int numP)
{
    numerator = numP;
    return *this;
}
Fraction& Fraction::setDen(int denP)
{
    denominator = denP;
    return *this;
}

int Fraction::findGCD(int a, int b)
{
    while((a != 0) && (b != 0))
    {
        if(a > b)
            a = a % b;
        else
            b = b % a;
    }
    return (a+b);
}

// Fraction& Fraction::operator+(Fraction frac2)
// {
//     int a{numerator};
//     int b{denominator};

//     int c{frac2.numerator};
//     int d{frac2.denominator};

//     int new_num{a*d + c*b};
//     int new_den{b*d};

//     int gcd{findGCD(new_num, new_den)};

//     Fraction* res{new Fraction(new_num / gcd, new_den / gcd)};

//     return *res;
// }

