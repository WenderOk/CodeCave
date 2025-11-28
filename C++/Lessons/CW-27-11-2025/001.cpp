#include <iostream>
#include <ctime>

int fact_recursive(int n)
{
    if (n==1 || n==0)
    {
        return 1;
    }
    return n * fact_recursive(n - 1);
}

int fact_iter(int n)
{
    int res{1};
    for(int i{2}; i <= n; i++)
    {
        res *= i;
    }
    return res;
}

int main()
{
    int t1_start = std::time(nullptr);
    fact_recursive(100);
    int t1_end = std::time(nullptr);

    int t2_start = std::time(nullptr);
    fact_iter(100);
    int t2_end = std::time(nullptr);

    std::cout << t1_end - t1_start << "\n" << t2_end - t2_start << "\n";

    return 0;
}