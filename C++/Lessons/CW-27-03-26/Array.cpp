#include <iostream>
#include "Array.h"
#include "ctime"
#include "cstdlib"

Array::Array(int s): size{s}, array{new int[size]} 
{ std::cout << "Created array with " << size << " elements\nAddress " << this << "\n"; }

Array::Array(): Array{5}
{}

Array::Array(const Array& arr): size{arr.size}, array{new int[size]}
{
    for(int i{}; i < size; i++)
        array[i] = arr[i];
    std::cout << "Copied array with " << size << " elements\nAddress " << this << "\n";
}

Array::Array(Array&& arr) : size{arr.size}, array{arr.array}
{
    arr.array = nullptr;
    arr.size = 0;
    std::cout << "Moved array with " << size << " elements\nAddress " << this << "\n";
}

Array::~Array()
{
    std::cout << "trying to delete array with " << size << " elements\nAddress " << array << "\n";
    delete[] array; 
    std::cout << "Deleted array with " << size << " elements\nAddress " << this << "\n";
}

int Array::len() const
{ return size; }

const Array& Array::operator=(const Array& arr)
{
    if(this == &arr)
        return *this;
    if(size != arr.size)
    { 
        delete[] array;   
        size = arr.size;
        array = new int[size];
    }
    for(int i{}; i < size; i++)
        array[i] = arr[i];
    std::cout << "Assigned by copying array with address " << this << "\n";
    return *this;
}

const Array& Array::operator=(Array&& arr)
{
    if(this == &arr)
        return *this;

    delete array;
    array = arr.array;
    size = arr.size;
    arr.array = nullptr;
    arr.size = 0;

    std::cout << "Moving operator used\n";
    std::cout << "Moved array with " << size << " elements\nAddress " << this << "\n";
    return *this;
}

bool Array::operator==(const Array& arr) const
{
    if(size != arr.size) return false;
    for(int i{}; i < size; i++)
    { if(array[i] != arr[i]) return false; }
    return true;
}

int& Array::operator[](int i)
{
    if(i < 0 || i >= size)
    {
        std::cout << "index out of range\n";
        exit(1);
    }
    return array[i];
}

int Array::operator[](int i) const
{
    if(i < 0 || i >= size)
    {
        std::cout << "index out of range\n";
        exit(1);
    }
    return array[i];
}

std::ostream& operator<<(std::ostream& out, const Array& arr)
{
    for(int i{}; i < arr.size; i++)
    { out << arr.array[i] << " "; }
    return out;
}

std::istream& operator>>(std::istream& in, Array& arr)
{
    for(int i{}; i < arr.size; i++)
    { in >> arr.array[i]; }
    return in;   
}

void Array::randomize()
{
    std::srand(std::time(nullptr));
    for (int i{}; i < size; i++)
    {
        array[i] = std::rand() % 100 + 1;
    }
}