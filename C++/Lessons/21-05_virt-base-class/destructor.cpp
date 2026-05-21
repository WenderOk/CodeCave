#include <iostream>
#include <cstring>

class Base
{
    int size;
    char* str;
public:
    Base(int sz, const char* s): size{sz}, str{new char[sz]}
    { strcpy(str, s); }

    virtual ~Base()
    {
        std::cout << "Destructor of Base class\n";
        delete[] str;
    }
};

class Derived: public Base
{
    int size2;
    char* str2;
public:
    Derived(int sz1, const char* s1, 
            int sz2, const char* s2)
    : Base{sz1, s1},
      size2{sz2}, str2{new char[sz2]}
    { strcpy(str2, s2); }

    virtual ~Derived()
    {
        std::cout << "Destructor of Derived class\n";
        delete[] str2;
    }
};
int main()
{
    // Base b{7, "George"};
    // Derived d{7, "George", 5, "Tema"};

    Base* pBase;
    pBase = new Derived{7, "George", 5, "Tema"};
    delete pBase;

    // Derived* pDerived;
    // pDerived = new Derived{7, "George", 5, "Tema"};
    // delete pDerived;

    return 0;
}
