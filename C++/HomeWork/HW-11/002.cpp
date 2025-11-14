#include <iostream>
 
int range_sum(int a, int b);

int main()
{
    int a{};
    int b{};

    std::cout << "Enter range (a b): ";
    std::cin >> a >> b;

    std::cout << "Res: " << range_sum(a,b) << "\n";
 
    return 0;
}

int range_sum(int a, int b)
{
    int sum{};
    if(a < b)
    {
        for(int i{a+1}; i < b; i++)
            sum += i;
    }
    else
    {
        for(int i{b+1}; i < a; i++)
            sum += i;
    }
    return sum;
}