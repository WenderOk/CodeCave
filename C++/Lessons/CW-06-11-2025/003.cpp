#include <iostream>

void hello()
{
    std::cout << "Hello, World!\n";
}

void print_number(int number)
{
    std::cout << number << "\n";
}

int fact(int number)
{
    int res{1};
    for(int i{2}; i <= number; i++)
    {
        res *= i;
    }

    return res;
}

void print_line(int len, char symbol)
{
    for(int i{}; i < len; i++)
    {
        std::cout << symbol;
    }
    std::cout << "\n";
}

void print_rect(int width, int height, char symbol)
{
    for(int i{}; i < height; i++)
    {
        print_line(width, symbol);
    }
}

int main()
{
    // hello();
    // printNumber(4);
    // std::cout << fact(3) << "\n";
    // print_line(10, '$');
    print_rect(10, 5, '#');

    return 0;
}