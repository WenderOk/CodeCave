#include <iostream>

void print(int* arr, int size);
int& rmax(int index);
const int rows{5};
const int cols{2};
int a[rows][cols];

int main()
{  
    for(int i{}; i < rows; i++)
    {
        std::cout << "Enter " << i << " element: ";
        int tmp{};
        std::cin >> tmp;
        a[i][0] = tmp;
        rmax(i) = tmp;
    }
    
    for(int i{}; i < rows; i++)
    {
        std::cout << a[i][0] << "\t" << rmax(i) << "\n";
    }
    std::cout << "\n";

    return 0;
}


int& rmax(int index)
{
    return a[index][1];
}

