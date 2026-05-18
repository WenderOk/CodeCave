#include <iostream>

class A
{};
class B: public A
{};
class C: public B
{};
class D
{};

int main()
{
    A objA;
    B objB;
    C objC;
    D objD;

    A* pobjA;

    pobjA = &objA;
    pobjA = &objB;
    // objA = &objC;

    return 0;
}