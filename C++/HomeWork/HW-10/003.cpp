#include <iostream>
#include <cstdlib>
#include <ctime>

void fillWithRand(int arr[], int size);
void shiftArr(int arr[], int size, int digit, bool);
void print2DArray(int arr[][6], int size1, int size2);

int main()
{
    std::srand(std::time({}));
    const int size1{1};
    const int size2{6};

    int digit{};
    bool is_right{true};

    std::cout << "Enter digit: ";
    std::cin >> digit;
    std::cout << "Enter direction\n1 - right\n0 - left\ndefault - 1\nYour choice: ";
    std::cin >> is_right;

    int arr[size1][size2];
 
    for(int i{}; i < size1; i++)
        fillWithRand(arr[i], size2);
    std::cout << "Source array: ";
    print2DArray(arr, size1, size2);

    for(int i{}; i < size1; i++)
        shiftArr(arr[i], size2, digit, is_right);

    std::cout << "Result array: ";
    print2DArray(arr, size1, size2);

    return 0;
}

void shiftArr(int arr[], int size, int digit, bool is_right)
{
    int tmp[size]{};
    digit = (is_right) ? digit : digit*(-1);

    for(int i{}; i < size; i++)
        tmp[i] = arr[i];

    for(int i{}; i < size; i++)
    {
        int new_index{i + digit};

        if((i + digit) > (size - 1))
            new_index = digit - (size - i);
        else if((i + digit) < 0)
            new_index = -((-digit - i) - size);
        

        arr[new_index] = tmp[i];
    }
}

void fillWithRand(int arr[], int size)
{
    int rborder{10};
    int lborder{1};

    for(int i{}; i < size; i++)
        arr[i] = std::rand() % rborder + lborder;
}

void print2DArray(int arr[][6], int size1, int size2)
{
    for(int i{}; i < size1; i++)
    {
        for(int j{}; j < size2; j++)
            std::cout << arr[i][j] << " ";
        std::cout << '\n';
    }
}   