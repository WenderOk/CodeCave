#include <iostream>
#include "Student.h"

int main()
{
    // group of students
    const int NUM{4};
    Student group[NUM]{};


    for(int i{}; i < NUM; i++)
    {
        group[i].create();
    }

    for(int i{}; i < NUM; i++)
    {
        group[i].print();
        std::cout << "\n";
    }



    return 0;
}