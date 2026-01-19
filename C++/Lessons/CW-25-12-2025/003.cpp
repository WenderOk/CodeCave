#include <iostream>

int sum(int a, int b = 0);
int sub(int a, int b = 0);
int division(int a, int b = 0);
int mul(int a, int b = 0);

int main()
{
    // std::cout << sum(10, 5) << "\n";
    // std::cout << sum(10) << "\n";

    int (*func) (int, int);
    func = sum;
    int a{5};
    int b{10};

    // std::cout << func(5, 10) << "\n";
    // std::cout << func(5, 0) << "\n";
    const int size{4};
    int (*arrOper[size]) (int, int);

    arrOper[0] = sum;
    arrOper[1] = sub;
    arrOper[2] = division;
    arrOper[3] = mul;

    for(int i{}; i < size; i++)
    {
        std::cout << arrOper[i](a,b) << "\n";
    }

    return 0;
}


int sum(int a, int b)
{
    return a + b;
}

int sub(int a, int b)
{
    return a + b;
}

int division(int a, int b)
{
    return a / b;
}

int mul(int a, int b)
{
    return a * b;
}