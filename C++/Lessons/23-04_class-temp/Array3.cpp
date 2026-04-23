#include <iostream>
#include <vector>

template<class T>
struct Point
{
    T x;
    T y;
    void print()
    { std::cout << '(' << x << ", " << y << ')'; }
};

template<class T>
struct Array
{
    std::vector<T> arr;

    void add(T item)
    { arr.push_back(item); }

    void print() const
    {
        for(T val: arr)
            std::cout << val << " ";
        std::cout << '\n';
    }
};

template<template<class> class T, class T1>
struct Some
{

};

int main()
{


    return 0;
}