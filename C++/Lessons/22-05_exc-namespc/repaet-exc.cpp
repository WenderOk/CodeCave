#include <iostream>
 
void Test()
{
    try
    {
        throw "Error!";
    }
    catch(const char* e)
    {
        std::cerr << e << '\n';
        throw;
    }
}

int main()
{
    std::cout << "Main begin\n";
    try
    {
        Test();
    }
    catch(const char* e)
    {
        std::cerr << e << '\n';
    }

    
    return 0;
}