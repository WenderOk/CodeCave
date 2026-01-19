#include <iostream>

int main()
{
    // Regular variable
    int x{10};

    // pointer is also a variable
    int* px{ &x };
    std::cout << px << "\n";

    // dereference
    std::cout << *px << "\n";

    // You can use dereference to write value in variable that pointer points to
    *px = 20;
    std::cout << x << "\n";

    return 0;
}