#include <iostream>

int sum(int a, int b);
int sub(int a, int b);
int execOper(int a, int b, int (*f)(int, int));

int main()
{
    // std::cout << main << "\n";
    // std::cout << *main << "\n";

    int (*func) (int, int);

    func = sum;

    int a{5};
    int b{10};
    std::cout << execOper(a, b, sum) << "\n";
    std::cout << execOper(a, b, sub) << "\n";

    return 0;
}

int sum(int a, int b)
{
    return a + b;
}

int sub(int a, int b)
{
    return a - b;   
}

int execOper(int a, int b, int (*f)(int, int))
{
    return f(a, b);
}
    