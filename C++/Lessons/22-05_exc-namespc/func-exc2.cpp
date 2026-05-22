#include <iostream>
 
void Test(int num)
{
    std::cout << "Inside Test, begin\n";
    
    if(num == 2)
        throw "Error: num == 2";

    if(num == 3)
        throw "Error: num == 3";
}

int main()
{
    try
    {
        Test(4);
        Test(2);
    }
    catch(const char* e)
    {
        std::cerr << e << '\n';
    }

    
    return 0;
}