#include <iostream>

void swap(int* a, int* b)
{
    int temp{*a};
    *a = *b;
    *b = temp;
}

void swap2(int& a, int& b)
{
    int temp{a};
    a = b;
    b = temp;
}

int main()
{  
    int x{12};
    int y{21};
    
    int& xref(x);

    swap(&x,&y);
    std::cout << x << " " << y << "\n";
    swap2(x, y);
    std::cout << x << " " << y << "\n";

    return 0;
}