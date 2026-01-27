#include <iostream>
#include <cstdlib>
#include <ctime>

void printArray(int arr[], int size);
void fillWithRand(int arr[], int size);
int find_in_arr(int arr[], int len, int value);

int main()
{
    std::srand(std::time(nullptr));
    const int M{4};
    const int N{3};
    // std::cout << "Enter M and N: ";
    // std::cin >> M >> N;

    // int* A = new int[M]{};
    // int* B = new int[N]{};
    // int* res = new int[M]{};
    int res [4]{};
    int A [M]{2,2,3,4};
    int B [N]{1,1,3};

    // fillWithRand(A, M);
    // fillWithRand(B, N);
    printArray(A, M);
    printArray(B, N);

    for(int i{}; i < M;)
    {
        if((find_in_arr(B, N, A[i]) < 0) && (find_in_arr(res, M, A[i]) < 0))
        {
            res[i] = A[i];
            i++;
        }
    }

    printArray(res, M);

    return 0;
}

void fillWithRand(int arr[], int size)
{
    int rborder{100};
    int lborder{1};

    for(int i{}; i < size; i++)
        arr[i] = std::rand() % rborder + lborder;
}

void printArray(int arr[], int size)
{
    for(int i{}; i < size; i++)
        std::cout << arr[i] << " ";
    std::cout << "\n";
}

int find_in_arr(int arr[], int len, int value)
{
    int res{-1};
    for(int i{}; i < len; i++)
        if(arr[i] == value)
            {
                res = i;
                return i;
            }
    return res;
}