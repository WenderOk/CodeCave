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
    T<T1> data;
    void add(T1 value)
    { data.add(value); }
    void print()
    {
        data.print(); 
        std::cout << '\n';
    }
};

int main()
{
    Some<Point, int> intPoint;
    intPoint.data.x = 1;
    intPoint.data.y = 2;
    std::cout << "Int point\n";
    intPoint.print();

    Some<Point, double> doublePoint;
    doublePoint.data.x = 1.12;
    doublePoint.data.y = 2.43;
    std::cout << "Double point\n";
    doublePoint.print();

    Some<Array, int> intArray;
    intArray.add(1);
    intArray.add(2);
    intArray.add(3);
    std::cout << "Int Array\n";
    intArray.print();

    return 0;
}