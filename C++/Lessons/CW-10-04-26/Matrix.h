#include <iostream>

class Matrix
{
    int sizeY;
    int sizeX;
    int* data;

    int index2D(int y, int x) const
    { return y * sizeX + x; }

    int index2D(int y, int x, int sizeXP)
    { return y * sizeXP + x; }

public:
    Matrix(int sY, int sX): sizeY{sY}, sizeX{sX}, data{new int[sizeY * sizeX]}
    {}

    int operator()(int y, int x) const
    { return *(data + index2D(y, x)); }

    int& operator()(int y, int x)
    { return *(data + index2D(y, x)); }

    void deleteColumn(int colPos)
    {
        --sizeX;
        int* newData{new int[sizeX * sizeY]};
        for (int i{}; i < sizeY; i++)
        {
            for (int j{}; j < sizeX; j++)
            { *(newData + index2D(i, j)) = *(data + index2D(i, j + (j >= colPos), sizeX+1)); }
        }   
        delete[] data;
        data = newData;
    }

    void addColumn(int colPos, int* newCol = nullptr)
    {
        int* newData{new int[(sizeX + 1)* sizeY]};
        for (int i{}; i < sizeY; i++)
        {
            for (int j{}; j < sizeX; j++)
            {
                *(newData + index2D(i, j + (j >= colPos), sizeX + 1)) = *(data + index2D(i, j));
            }
            *(newData + index2D(i, colPos,sizeX + 1)) = newCol ? *(newCol + i) : 0;
        }   
        delete[] data;
        data = newData;
        sizeX++;
    }

    void print() const
    {
        for (int i{}; i < sizeY; i++)
        {
            for (int j{}; j < sizeX; j++)
            { std::cout << (*this)(i, j) << " "; }
            std::cout << "\n";
        }        
    }
    ~Matrix()
    { delete[] data; }

};
