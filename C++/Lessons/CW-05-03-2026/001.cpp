#include <iostream>
#include "Student.h"

int main()
{
    Student stud;
    // std::cout << stud.getName() << "\n";

    Student stud2("Seva", new int[]{4,3,5,2,3});

    // std::cout << stud2.getName() << "\n";

    for(int i{}; i < 5; i++)
        std::cout << stud2.getMark(i) << " ";
    std::cout << "\n";

    return 0;
}