#include <iostream>
#include "Array.h"

Array::Array(int s): size{s}, array{new int[size]} {}
Array::Array(const Array& arr): size{arr.size}, array{new int[size]}
{
    for(int i{}; i < size; i++)
        array[i] = arr[i];
}
Array::~Array()
{ delete[] array; }
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
}