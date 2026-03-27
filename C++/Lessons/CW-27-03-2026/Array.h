#pragma once

#include <iostream>

class Array
{
    int size;
    int* array;
public:
    explicit Array(int s = 10);
    Array(const Array& arr);
    ~Array();
    int len() const; 

    const Array& operator=(const Array& arr);
    bool operator==(const Array& arr) const;
    bool operator!=(const Array& arr) const
    { return !(*this == arr); }
    int& operator[](int i);
    int operator[](int i) const;
private:
    friend std::ostream& operator<<(std::ostream& out, const Array& arr);
    friend std::istream& operator>>(std::istream& in, Array& arr);
};