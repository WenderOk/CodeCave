#include <iostream>
 
int main()
{
    try
    {
        int a{};
        std::cout << "Enter number a: ";
        std::cin >> a;
        if(a == 0) throw "Error";
    }
    catch(...)
    {
        std::cerr << "Error" << '\n';
    }
    
    
    return 0;
}