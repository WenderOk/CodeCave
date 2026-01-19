#include <iostream>

int sum(int a, int b);
auto checkDiscount(int prodID);

int main()
{
    auto var{ 1.2 };
    std::cout << var << "\n";

    auto var2 {2.3 + 10};
    std::cout << var2 << "\n";

    auto ptr {&var};
    std::cout << ptr << "\n";

    auto ptrf{sum};
    std::cout << ptrf(80, 45) << "\n";

    return 0;
}

int sum(int a, int b)
{
     return a + b;
}

auto checkDiscount(int prodID)
{
    if(prodID == 1)
        return 10;
    else
        return 78;
}