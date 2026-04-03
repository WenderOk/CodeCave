#include <iostream>

int max(int a, int b)
{ return a > b ? a : b; } 

int main()
{
    // работа со ссылкой на rvalue
    int&& rvalRef{2 + 3};
    rvalRef += 3;
    std::cout << rvalRef << "\n";

    // работа со ссылкой на rvalue через функцию
    int&& res{max(3,5)};
    res += max(6,4);
    std::cout << res << "\n";

    // что нельзя делать с rvalue-ссылкой
    int x{42};
    //int&& rvalBad{x};  // an rvalue reference cannot be bound to an lvalue
    //int&& rvalBad1{res};   rvalue сама является lvalue значением
    

    int& lvalRef{res};      // это разрешено
    std::cout << lvalRef << "\n";

    return 0;
}