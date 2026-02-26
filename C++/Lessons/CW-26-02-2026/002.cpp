#include <iostream>
#include <cstring>

const int MAX_NAME_SIZE{20};
const int MAX_MARKS_COUNT{5};

class Student
{
public:
    char name[MAX_NAME_SIZE];
    int marks[MAX_MARKS_COUNT];

    Student(char n[], int m[])
    {
        strcpy(name, n);
        for (int i{}; i < MAX_MARKS_COUNT; i++)
            marks[i] = m[i];
    }

    double averageMark()
    {
        double res{};
        int i{};
        for(i; (marks[i] != 0) && (i < MAX_MARKS_COUNT); i++)
        {
            res+=marks[i];
        }
        return res/i;
    }

    void print()
    {
        std::cout << "Student name: " << name << "\n";
        std::cout << "Student marks: ";
        int i{};
        while((marks[i] != 0) && (i < MAX_MARKS_COUNT))
        {
            std::cout << marks[i] << " ";
            i++;
        }
    }
};

int main()
{
    int marks[MAX_MARKS_COUNT]{3,5,5,4,3};
    Student stud{"Egor", marks};
    // stud.print();
    // stud.averageMark();
    
    std::cout << stud.name << "\n";

    return 0;
}
