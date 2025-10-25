#include <iostream>

int main ()
{
    for (int i{}; i < 26; i++)
    {
        if (i % 2==0)
            continue;
        std::cout << i << " ";
    }

    return 0;
}