#include <iostream>

class Fraction
{
    int numerator;
    int denominator;
public:

    Fraction(int num, int denom): numerator{num}, denominator{denom}
    { std::cout << "Constructor for: " << this << "\n"; }
    Fraction(): Fraction(1, 1)
    {}
    ~Fraction()
    { std::cout << "Desstructor for: " << this << "\n"; }
    Fraction(const Fraction& fr): numerator{fr.numerator}, denominator{fr.denominator}
    { std::cout << "Copy constructor for: " << this << "\n"; }

    Fraction& print()
    {
        std::cout << numerator << "/" << denominator << "\n";
        return *this;
    }
};
