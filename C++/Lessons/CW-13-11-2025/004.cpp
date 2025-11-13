#include <iostream>

// Перегрузки фунцкий

int zero_count(int a, int b)
{
    return a + b;
}

int zero_count(double a, int b)
{
    return a + b;
}

double sum(int a, double b)
{
    return a + b;
}

int sum(double a, double b)
{
    return a + b;
}


int main()
{
    std::cout << zero_count(5,10) << "\n";
    std::cout << zero_count(5.1,10) << "\n";
    std::cout << sum(5,10.7) << "\n";
    std::cout << sum(5.1,10.7) << "\n";

    return 0;
}