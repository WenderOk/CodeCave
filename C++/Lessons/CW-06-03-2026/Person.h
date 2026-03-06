#include <cstring>
#include <iostream>

class Person
{
    char* name;
    int age;
    int id;
public:
    Person() : Person{nullptr, 0, 0}
    {}
    Person(char* nameP) : Person{nameP, 0, 0}
    {}
    Person(char* nameP, int ageP) : Person{nameP, ageP, 0}
    {}

    Person(const char* nameP, int ageP, int idP) 
        : name{nameP ? new char[strlen(nameP) + 1] : nullptr},
          age{ageP}, id{idP}
    { if(name) strcpy(name, nameP); }

    void print()
    {
        if(name) std::cout << "Person: " << name << ", " << age << ", " << id << "\n"; 
        else std::cout << "Person: <unknow>" << ", " << age << ", " << id << "\n"; 
    }

    ~Person() { delete[] name; }
};
