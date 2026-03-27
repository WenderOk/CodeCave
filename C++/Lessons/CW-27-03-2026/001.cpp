#include <iostream>
#include <cstring>

class Name
{
    char* FirstName;
    char* SecondName;
    void setCharArray(char*& dest, const char* source)
    {
        int strSize = strlen(source)+1;
        dest = new char[strSize];
        strcpy(dest, source);
    }
    void remove()
    {
        if(FirstName != nullptr)
            delete[] FirstName;
        if(SecondName != nullptr)
            delete[] SecondName;
    }
public:
    Name(): FirstName{nullptr}, SecondName{nullptr} 
    {std::cout << "Empty object created" << this << "\n";}
    Name(const char* fn, const char* sn)
    {
        setCharArray(FirstName, fn);
        setCharArray(SecondName, sn);
        std::cout << "Object created: " << *this << " " << this << "\n";
    }
    Name(const Name& name)
    {
        setCharArray(FirstName, name.FirstName);
        setCharArray(SecondName, name.SecondName);
        std::cout << "Object copied: " << *this << " " << this << "\n";
    }
    ~Name()
    {
        std::cout << "Object deleted: " << *this << " " << this << "\n";
        remove();
    }

    Name& operator=(const Name& n)
    {
        if(this == &n)
            return *this;
        remove();
        
        setCharArray(FirstName, n.FirstName);
        setCharArray(SecondName, n.SecondName);
        std::cout << "Object copied: " << *this << " " << this << "\n";
        return *this;
    }
    friend std::ostream& operator<<(std::ostream& out, const Name& name);
};

void writeLine(Name name)
{ std::cout << name << "\n"; }

int main()
{
    char firstName[10]{"Seva"};
    char secondName[10]{"Shlyahov"};
    {
        Name name{firstName, secondName};
    }
    std::cout << "\n";
    {
        Name name{firstName, secondName};
        writeLine(name);
    }
    std::cout << "\n";
    Name aName;
    {
        Name name{firstName, secondName};
        aName = name;
    }
    std::cout << aName << "\n";
    
    
    return 0;
}


std::ostream& operator<<(std::ostream& out, const Name& name)
{
    out << name.FirstName << " " << name.SecondName;
    return out;
}