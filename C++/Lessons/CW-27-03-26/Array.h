#pragma once

#include <iostream>

class Array
{
    int size;
    int* array;
public:
    explicit Array(int s);
    Array();
    Array(const Array& arr);
    Array(Array&& arr);
    ~Array();
    int len() const; 

    const Array& operator=(const Array& arr);
    const Array& operator=(Array&& arr);
    bool operator==(const Array& arr) const;
    bool operator!=(const Array& arr) const
    { return !(*this == arr); }
    int& operator[](int i);
    int operator[](int i) const;
    void randomize();
private:
    friend std::ostream& operator<<(std::ostream& out, const Array& arr);
    friend std::istream& operator>>(std::istream& in, Array& arr);
};