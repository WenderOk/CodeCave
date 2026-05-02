#include <cstring>
#include <iostream>
#include "String.h"

String::String(size_t s): size{s}, content{new char[s]{}}
{ }
String::String(): String(80)
{}
String::String(const char str[]): size{strlen(str)+1}, content{new char[size]}
{ strcpy(content, str); }
String::String(String&& str): size{str.size}, content{str.content}
{
    str.content = nullptr;
    str.size = 0;
}
String::~String()
{ delete[] content; }

size_t String::len()
{ return size; }

char String::operator[](int index) const
{ return content[index]; }
int String::operator()(const char ch[]) const
{
    char* result = strstr(content, ch);
    if(result != nullptr)
        return result - content;
    return -1;
}
String::operator int()
{ return this->len(); }

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