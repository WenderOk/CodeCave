#include <iostream>
#include "Student.h"

Student::Student()
{
    strcpy(name, "<unknow>");
    for (int i{}; i < MAX_MARKS_COUNT; i++)
        marks[i] = 0;
}

Student::Student(char n[], int m[])
{
    strcpy(name, n);
    for (int i{}; i < MAX_MARKS_COUNT; i++)
        marks[i] = m[i];
}

Student::~Student()
{
    std::cout << "Student has been deleted!\n";
}

double Student::averageMark()
{
    double res{};
    int i{};
    for(i; (marks[i] != 0) && (i < MAX_MARKS_COUNT); i++)
    {
        res+=marks[i];
    }
    return res/i;
}

void Student::print()
{
    std::cout << "Student name: " << name << "\n";
    std::cout << "Student marks: ";
    int i{};
    while((marks[i] != 0) && (i < MAX_MARKS_COUNT))
    {
        std::cout << marks[i] << " ";
        i++;
    }
    std::cout << "\n";
}

char* Student::getName() { return name; }
void Student::setName(char n[]) { strcpy(name, n); }

int Student::getMark(int index)
{
    if((index >= 0) && (index < MAX_MARKS_COUNT))
        return marks[index];
    else return -1;
}

int Student::setMark(int index, int mark)
{
    if((index >= 0) && (index < MAX_MARKS_COUNT))
        if(mark > 0 && mark <= 5)
            marks[index] = mark;
        else return -2;
    else return -1;
    return 0;
}