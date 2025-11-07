#include <iostream>
#include <cstdlib>
#include <ctime>

const int WIDTH {5};
const int HEIGHT {5};

void print_2d_arr(int arr[][WIDTH], int w, int h);

int main()
{
    int arr[HEIGHT][WIDTH]{};
    std::srand(std::time({}));
    int rborder{};
    int lborder{};

    std::cout << "Enter left and right borders: ";
    std::cin >> lborder >> rborder;

    for(int i{}; i < HEIGHT; i++)
    {
        for(int j{}; j < WIDTH; j++)
            arr[i][j] = std::rand() % rborder + lborder;
    }
    
    print_2d_arr(arr, WIDTH, HEIGHT);

    return 0;
}

void print_2d_arr(int arr[][WIDTH], int w, int h)
{
    for(int i{}; i < h; i++)
    {
        for(int j{}; j < w; j++)
        {
            if(arr[i][j] < 10)
                std::cout << '0';
            std::cout << arr[i][j] << " ";
        }
    std::cout << "\n";    
    }
}