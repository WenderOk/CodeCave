#include <iostream>
#include <cstring>
#include "Student.h"

int main()
{
    int marks[MAX_MARKS_COUNT]{3,5,5,4,3};
    Student stud{"Egor", marks};
    // stud.print();
    // std::cout << "Average mark: " << stud.averageMark() << "\n";
    
    // std::cout << stud.getName() << "\n";
    // stud.setName("Mark");
    // std::cout << stud.getName() << "\n";

    std::cout << "Mark at index 2: " << stud.getMark(2) << "\n";
    std::cout << "Wrong mark index error: " << stud.getMark(42) << "\n";
    std::cout << "Wrong index error: " << stud.setMark(54, 5) << "\n";
    std::cout << "Wrong mark error: " << stud.setMark(2, 55) << "\n";
    

    return 0;
}
