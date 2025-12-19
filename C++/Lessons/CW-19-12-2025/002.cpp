#include <iostream>
#include <cstdlib>
#include <ctime>

void fillWithRand(int arr[], int size);
void print3DArray(int* arr[], int rows, int cols);
void delete2DArray(int* arr[], int rows);

void fill_arr(int* arr, int len)
{
    for (int i{}; i < len; i++)
    {
        arr[i] = rand() % 5 + 1;
    }
}

int main()
{
    std::srand(std::time(nullptr));
    int ns{};
    int nm{};
    std::cout << "Enter amount of students: ";
    std::cin >> ns;
    std::cout << "Enter amount of marks: ";
    std::cin >> nm;

    // создание массива указателей на строки
    int** marks{ new int*[ns] };

    for (int i{}; i < ns; i++)
    {
        int len{ (i + 1 > nm) ? nm : i + 1 };
        marks[i] = new int[len];
        fillWithRand(marks[i], len);
    }
    print3DArray(marks, ns, nm);
    delete2DArray(marks, ns);
    std::cout << "Finish\n";

    return 0;
}

void fillWithRand(int arr[], int size)
{
    for(int i{}; i < size; i++)
        arr[i] = std::rand() % 5 + 1;
}

void print3DArray(int* arr[], int rows, int cols)
{
    for (int i{}; i < rows; i++)
    {
        int rowlen{ (i + 1 > cols) ? cols : i + 1 };
        for (int j{}; j < rowlen; j++)
        {
            std::cout << arr[i][j] << ' ';
        }
        std::cout << '\n';
    }
}
void delete2DArray(int* arr[], int rows)
{
    for(int i{}; i < rows; i++)
    {
        delete[] arr[i];
    }
    delete[] arr;
}