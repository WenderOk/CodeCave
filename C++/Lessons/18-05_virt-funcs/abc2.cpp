#include <iostream>

class A
{
public:
    virtual void virt_func() {}
};
class B: public A
{
    virtual void virt_func()
    { std::cout << "Virt func from class B\n"; }
};
class C: public B
{
    virtual void virt_func()
    { std::cout << "Virt func from class C\n"; }
};

int main()
{
    A objA;
    B objB;
    C objC;
   
    A* pobjA;

    pobjA = &objB;
    pobjA->virt_func();
    std::cout << sizeof(objB) << "\n";

    pobjA = &objC;
    pobjA->virt_func();

    return 0;
}

