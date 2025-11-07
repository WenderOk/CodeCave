#include <iostream>

int min(int a, int b)
{
    return a<=b ? a : b;
}

int max(int a, int b)
{
    return a>=b ? a : b;
}

double pow(int a, int b)
{
    double res{1};

    if(b > 0)
    {    
        for(int i{1}; i <= b; i++)
            res *= a;
    }
    else if(b < 0)
    {    
        for(int i{1}; i <= (b*(-1)); i++)
            res *= 1.0 / b;
    }
    else
    {
        return 1;
    }
    return res;
}

int main()
{
    //std::cout << "Min: " << min(1,2) << "\n" << "Max: " << max(2,3) << "\n";
    std::cout << "Pow: " << pow(5,3) << "\n";
    std::cout << "Pow: " << pow(0,3) << "\n";
    std::cout << "Pow: " << pow(5,0) << "\n";
    std::cout << "Pow: " << pow(5,-3) << "\n";
    std::cout << "Pow: " << pow(0,-3) << "\n";
    return 0;
}