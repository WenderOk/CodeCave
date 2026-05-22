#include <iostream>
 
int main()
{
    try
    {
        double a{};
        double b{};
        std::cout << "Enter divider: ";
        std::cin >> b;
        std::cout << "Enter what to divide: ";
        std::cin >> a;
        if(b == 0) throw b;
        std::cout << "Result: " << a/b << '\n';
    }
    catch(double e)
    {
        std::cerr << "Error: dividing by " << e << '\n';
    }
    
    return 0;
}