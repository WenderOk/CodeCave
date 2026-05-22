#include <iostream>
 
int main()
{
    try
    {
        int* ptr{};
        int size{};
        std::cout << "Enter size of array: ";
        std::cin >> size;

        if(size < 1 || size > 500)
            throw "Error: wrong size!";
        ptr = new int[size];

        if(!ptr)
            throw "Memory error!";

        int a{};
        std::cout << "Enter number a: ";
        std::cin >> a;
        if(a == 0) throw a;
    }
    catch(int e)
    {
        std::cerr << "Error: a = " << e << '\n';
    }
    catch(const char* e)
    {
        std::cerr << e << '\n';
    }
    
    return 0;
}