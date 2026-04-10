#include <iostream>

class Array2Linear
{
    int sizeY;
    int sizeX;

public:
    int** data;

    Array2Linear(int sY, int sX): sizeY{sY}, sizeX{sX}, data{new int*[sizeY]}
    {
        // for(int i{}; i < sizeY; i++)
        // { data[i] = new int[sizeX]; }
        int * dataElems = new int[sizeY * sizeX];
        for(int i{}; i < sizeY; i++)
        { data[i] = dataElems + i* sizeX; }
    }
    Array2Linear& print()
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
    ~Array2Linear()
    {
        // for (int i{}; i < sizeY; i++)
        // { delete[] data[i]; }
        delete[] data[0];
        delete[] data;
    }

};
