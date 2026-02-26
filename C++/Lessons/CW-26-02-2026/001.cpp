#include <iostream>

const int MAX_NAME_SIZE{20};
const int MAX_MARKS_COUNT{10};
struct Student
{
    char name[MAX_NAME_SIZE];
    int marks[MAX_MARKS_COUNT];
};

void createStudent(Student& student);
void printStudent(Student student);

int main()
{
    Student stud{};

    createStudent(stud);
    printStudent(stud);
    return 0;
}

void createStudent(Student& student)
{
    std::cout << "Enter student name: ";
    std::cin >> student.name;
    std::cout << "Enter student marks\n";
    int input{1};
    for(int i{}; (input != 0) && (i < MAX_MARKS_COUNT); i++)
    {
        std::cout << "Enter " << i+1 << " mark: ";
        std::cin >> input;
        student.marks[i] = input;
    }
}

double averageMark(Student student)
{
    double res{};
    int i{};
    for(i; (student.marks[i] != 0) && (i < MAX_MARKS_COUNT); i++)
    {
        res+=student.marks[i];
    }
    return res/i;
}

void printStudent(Student student)
{
    std::cout << "Student name: " << student.name << "\n";
    std::cout << "Student marks: ";
    int i{};
    while((student.marks[i] != 0) && (i < MAX_MARKS_COUNT))
    {
        std::cout << student.marks[i] << " ";
        i++;
    }
    std::cout << "\nAverage marks: " << averageMark(student) << "\n";
}