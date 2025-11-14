#include <iostream>
 
double pow(int a, int b);

int main()
{
    int a{};
    int b{};

    std::cout << "Enter number and power (a b): ";
    std::cin >> a >> b;

    std::cout << "Res: " << pow(a,b) << "\n";

    return 0;
}

double pow(int a, int b)
{
    double res{1};

    if(b > 0)
    {    
        for(int i{1}; i <= b; i++)
            res *= a;
    }
    else if ((b < 0) && (a == 0))
    {
        std::cout << "You cant raise zero to negative power! ";
        return 0;
    }
    else if((b < 0) && (a > 0))
    {    
        for(int i{1}; i <= -b; i++)
            res *= 1.0 / a;
    }
    else if ((a < 0) && (b < 0))
    {
        for(int i{1}; i <= -b; i++)
            res *= 1.0 / -a;
        res = -res;
    }

    return res;
}