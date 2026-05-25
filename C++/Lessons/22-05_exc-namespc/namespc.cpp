#include <iostream>
 
namespace combat
{
    void fire()
    {
        std::cout << "Fire!\n";
    }
}

namespace exploration
{
    void fire()
    {
        std::cout << "Make fire\n";
    }
}


int main()
{
    combat::fire();
    exploration::fire();
 
    return 0;
}