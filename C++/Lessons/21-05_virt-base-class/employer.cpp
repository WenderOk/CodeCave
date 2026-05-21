#include <iostream>
#include <string>

class Employer
{
protected:
    std::string name;
    int id;
public:
    Employer(int i, std::string n): id{i}, name{n}
    {}
    virtual void print() = 0;
    
};

class President: public Employer
{
    std::string expireDate;
public:
    President(int i, std::string n, std::string exD): Employer{i, n}, expireDate{exD}
    {}
    void print()
    { std::cout << "President: " << expireDate << '\n'; }
};

class Worker: public Employer
{
    int exp;
public:
    Worker(int i, std::string n, int ex): Employer{i, n}, exp{ex}
    {}
    void print()
    { std::cout << "Worker: " << exp << '\n'; }
};

class Manager: public Employer
{
    std::string secName;
public:
    Manager(int i, std::string n, std::string sn): Employer{i, n}, secName{sn}
    {}
    void print()
    { std::cout << "Manager: " << secName << '\n'; }
};

int main()
{
    const int size{3};
    Employer* em[size]
    {
        new President{1, "George", "02.12.2026" },
        new Manager{2, "Seva", "IT"},
        new Worker{3, "Leo", 12}
    };

    for(int i{}; i < size; i++)
        em[i]->print();

    return 0;
}