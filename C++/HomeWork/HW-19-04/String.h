#pragma once

#include <iostream>

class String
{
    size_t size;   // использовал size_t потому что компилятор выдавал предупреждение о сужаюющем приобразовании (а это потенциальная ошибка)
    char* content;
public:
    String(size_t s);
    String();
    String(const char str[]);
    String(String&& str);
    ~String();

    size_t len();

    char operator[](int index) const;
    int operator()(const char ch[]) const;
    operator int();

    friend std::ostream& operator<<(std::ostream& out, const String& str);
    friend std::istream& operator>>(std::istream& in, const String& str);
};
