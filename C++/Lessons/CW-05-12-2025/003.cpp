#include <iostream>

int& sum(int a, int b)
{
    int res{ a + b };
    int& resref{res};
    return resref;
}

int main()
{  
    int x{12};
    int y{21};
    
   std::cout << sum(x, y) << "\n";

   sum(8, 12) = 15;

   std::cout << sum(8, 12) << "\n";

    return 0;
}