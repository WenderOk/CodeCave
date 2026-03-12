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

    int findGCD(int a, int b);                                  // функция для нахождения НОД по методу Евклида

    Fraction& add(const Fraction& frac1, const Fraction& frac2);
    Fraction& sub(const Fraction& frac1, const Fraction& frac2);
    Fraction& mul(const Fraction& frac1, const Fraction& frac2);
    Fraction& div(const Fraction& frac1, const Fraction& frac2);


};
