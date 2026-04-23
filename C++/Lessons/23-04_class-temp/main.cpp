#include <iostream>
#include "Array.h"

int main()
{
    Array<int> intArr;
    intArr.print();

    size_t s{intArr.getSize()};

    // std::cout << s << '\n';

    for(size_t i{s}; i > 0; i--)
        intArr.setItem(s-i, i);
    intArr.print();

    intArr.sort();
    intArr.print();

    Array<std::string> strArr;
    strArr.print();

    strArr.setItem(0, "e");
    strArr.setItem(1, "d");
    strArr.setItem(2, "c");
    strArr.setItem(3, "b");
    strArr.setItem(4, "a");

    strArr.print();

    strArr.sort();

    size_t test{};
    std::cout << test - 1 << "\n";

    strArr.print();

    return 0;
}