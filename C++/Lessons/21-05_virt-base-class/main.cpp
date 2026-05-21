#include <iostream>

class A
{
protected:
    int val;
public:
    A(): val{5}
    {}
};

class B: public virtual A
{};

class C: public virtual A
{};

class D: public B, public C
{
public:
    void printVal()
    {
        std::cout << &(val) << '\n';
    }
};

int main()
{
    C c;
    B b;
    D d;
    d.printVal();

    std::cout << sizeof(d) << '\n';
    std::cout << sizeof(b) << '\n';
    std::cout << sizeof(c) << '\n';

    return 0;
}