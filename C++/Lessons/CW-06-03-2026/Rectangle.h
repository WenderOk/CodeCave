#pragma once

#include <iostream>
#include "Point.h"

class Rectangle
{
    Point vertex;
    int width;
    int heigth;

public:
    Rectangle() : vertex{{}, {}}, width{}, heigth{}
    {}
    Rectangle(int xP, int yP, int widthP, int heigthP) 
        : vertex{xP, yP}, width{widthP}, heigth{heigthP}
    {}

    void print()
    {
        vertex.print();
        std::cout << " " << width << " " << heigth;
    }
    
};