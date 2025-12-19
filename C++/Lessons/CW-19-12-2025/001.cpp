#include <iostream>
#include <cstdlib>
#include <ctime>

void fillWithRand(int arr[], int size);
void delete2DArray(int* arr[], int rows);
void print3DArray(int* arr[], int rows, int cols);

int main()
{
    std::srand(std::time(nullptr));
    int ns{};
    int nm{};
    std::cout << "Enter amount of students: ";
    std::cin >> ns;
    std::cout << "Enter amount of marks: ";
    std::cin >> nm;

    int** marks{new int*[ns]};
    
    for(int i{}; i < ns; i++)
    {
        marks[i] = new int[nm];
        fillWithRand(marks[i], nm);
    }

    print3DArray(marks, ns, nm);
    delete2DArray(marks, ns);
    return 0;
}

void fillWithRand(int arr[], int size)
{
    for(int i{}; i < size; i++)
        arr[i] = std::rand() % 5 + 1;
}

void print3DArray(int* arr[], int rows, int cols)
{
    for(int i{}; i < rows; i++)
    {   for(int j{}; j < cols; j++)
        {
            std::cout << arr[i][j] << " ";
        }
        std::cout << "\n";
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