#include <iostream>

void func()
{ std::cout << "Global func\n"; }

namespace
{
    void func()
    { std::cout << "Unnamed func\n"; }
}

int main()
{
    ::func();
    

}