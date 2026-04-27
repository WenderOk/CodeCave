#include <iostream>
#include "String.h"
 
int main()
{
    String str1{};
    String str2{10};
    String str3{"George"};

    std::cout << "Enter string 1 and string 2: ";
    std::cin >> str1 >> str2;
    std::cout << "Strings\n"
              << "str1: " << str1 << "\nsize: " << str1.len()
              << "\nstr2: " << str2 << "\nsize: " << str2.len()
              << "\nstr3: " << str3 << "\nsize: " << str3.len();
    
    std::cout << "\nNumber of String instances: " << String::getInstanceNum() << "\n";              
 
    return 0;
}