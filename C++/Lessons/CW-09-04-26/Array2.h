#include <iostream>

class Array2
{
    int sizeY;
    int sizeX;

public:
    int** data;

    Array2(int sY, int sX): sizeY{sY}, sizeX{sX}, data{new int*[sizeY]}
    {
        for(int i{}; i < sizeY; i++)
        { data[i] = new int[sizeX]; }
    }
    Array2& print()
    {
        for (int i{}; i < sizeY; i++)
        {
            for (int j{}; j < sizeX; j++)
            {
                std::cout << data[i][j] << " ";
            }
            std::cout << "\n";
        }        
        return *this;
    }
    ~Array2()
    {
        for (int i{}; i < sizeY; i++)
        {
            delete[] data[i];
        }
        delete[] data;
    }

};
