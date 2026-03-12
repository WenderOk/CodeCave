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

Fraction& Fraction::add(const Fraction& frac1, const Fraction& frac2)
{
    int a{frac1.numerator};
    int b{frac1.denominator};

    int c{frac2.numerator};
    int d{frac2.denominator};

    int new_num{a*d + c*b};
    int new_den{b*d};

    int gcd{findGCD(new_num, new_den)};

    Fraction* res{new Fraction(new_num / gcd, new_den / gcd)};

    return *res;
}

Fraction& Fraction::sub(const Fraction& frac1, const Fraction& frac2)
{
    int a{frac1.numerator};
    int b{frac1.denominator};

    int c{frac2.numerator};
    int d{frac2.denominator};

    int new_num{a*d - c*b};
    int new_den{b*d};

    int gcd{findGCD(new_num, new_den)};

    Fraction* res{new Fraction(new_num / gcd, new_den / gcd)};

    return *res;
}

Fraction& Fraction::mul(const Fraction& frac1, const Fraction& frac2)
{
    int new_num{frac1.numerator*frac2.numerator};
    int new_den{frac1.denominator*frac2.denominator};

    int gcd{findGCD(new_num, new_den)};

    Fraction* res{new Fraction(new_num / gcd, new_den / gcd)};

    return *res;
}

Fraction& Fraction::div(const Fraction& frac1, const Fraction& frac2)
{
    int new_num{frac1.numerator*frac2.denominator};
    int new_den{frac1.denominator*frac2.numerator};

    int gcd{findGCD(new_num, new_den)};

    Fraction* res{new Fraction(new_num / gcd, new_den / gcd)};

    return *res;    
}