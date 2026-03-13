#include <iostream>
#include <ctime>
#include <cstdlib>

class DynArr
{
    int* array;
    int size;
public:
    DynArr(int sizeP): array{new int[sizeP]}, size{sizeP}
    { std::cout << "Constructor for: " << this << "\nWith " << size << " items\n"; }
    DynArr(): DynArr{5}
    {}
    DynArr(const DynArr& da): array{new int[size]}, size{da.size}
    { 
        for (int i; i < size; i++)
            array[i] = da.array[i];
        std::cout << "Copy constructor for: " << this << "\nWith " << size << " items\n";
    }
    ~DynArr()
    {
        delete[] array;
        std::cout << "Object " << this << " destroyed\n";
    }

    DynArr& print()
    {
        for(int i{}; i < size; i++)
            std::cout << array[i] << " ";
        std::cout << "\n";
        return *this;
    }

    int getElem(int index)
    { return array[index]; }

    DynArr& setElem(int index, int value)
    {
         array[index] = value;
        return *this; 
    }

    DynArr& randomize()
    {
        srand(time(nullptr));
        for(int i{}; i < size; i++)
            array[i] = rand() % 100 + 1;        
        return *this;
    }
};
