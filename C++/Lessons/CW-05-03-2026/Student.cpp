#include <iostream>
#include "Student.h"

Student::Student()
{
    strcpy(name, "<unknow>");
    for (int i{}; i < MAX_MARKS_COUNT; i++)
        marks[i] = 0;
    // std::cout << "Student: " << this << " was created\n";
}

Student::Student(char n[], int m[])
{
    strcpy(name, n);
    for (int i{}; i < MAX_MARKS_COUNT; i++)
        marks[i] = m[i];
    // std::cout << "Student: " << this << " was created\n";
}

Student::~Student()
{
    // std::cout << "Student: " << this << " has been deleted!\n";
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

void Student::create()
{
    std::cout << "Enter student name: ";
    std::cin >> name;
    std::cout << "Enter " << MAX_MARKS_COUNT << " marks: \n";
    for(int i{}; i < MAX_MARKS_COUNT; i++)
    {
        std::cout << "Mark " << i+1 << ": ";
        std::cin >> marks[i];
    }
        
    std::cout << "\n";
}