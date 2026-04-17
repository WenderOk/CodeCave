#include <iostream>

class Fraction
{
    int numerator;
    int denominator;
public:

    Fraction(int num, int denom): numerator{num}, denominator{denom}
    {}
    Fraction(): Fraction(1, 1)
    {}
    ~Fraction()
    {}

    Fraction& print();

    Fraction& setNum(int numP);
    Fraction& setDen(int denP);

    int getNum()
    { return numerator; }
    int getDen()
    { return denominator; }

    int findGCD(int a, int b);

    // Fraction& operator+(Fraction frac2);
};
