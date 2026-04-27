#include <cstring>
#include <iostream>

class String
{
    size_t size;   // использовал size_t потому что компилятор выдавал предупреждение о сужаюющем приобразовании (а это потенциальная ошибка)
    char* content;

    static int insNumber;

public:
    String(size_t s): size{s}, content{new char[s]{}}
    { insNumber++; }
    String(): String(80)
    {}
    String(const char str[]): size{strlen(str)+1}, content{new char[size]}
    {
        strcpy(content, str);
        insNumber++;
    }
    ~String()
    {
        delete[] content;
        insNumber--;
    }

    static int getInstanceNum()
    { return insNumber; }

    size_t len()
    { return size; }

    friend std::ostream& operator<<(std::ostream& out, const String& str);
    friend std::istream& operator>>(std::istream& in, const String& str);
};

int String::insNumber{};

std::ostream& operator<<(std::ostream& out, const String& str)
{
    out << str.content;
    return out;
}

std::istream& operator>>(std::istream& in, const String& str)
{
    in >> str.content;
    return in;
}