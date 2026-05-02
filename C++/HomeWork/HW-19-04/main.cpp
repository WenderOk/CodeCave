#include <iostream>
#include <string>
#include "String.h"
#include "Array.h"

int main(int argc, char* argv[]) 
{
    if (argc < 2) 
    {
        std::cout << "Usage: " << argv[0] << " [MODE]" << "\n"
                  << "--string - Test String class\n"
                  << "--array - Test Array class\n";
        return 1;
    }

    std::string mode{argv[1]};

    if (mode == "--string") 
    {
        String s1{"Hello"};
        std::cout << "Current string s1: " << s1 << "\n\n";
        std::cout << "Getting element by []\n"
                  << "Element with index 1: " << s1[1] << "\n\n";
        std::cout << "Searching element by ()\n"
                  << "Element 'o' has index: " << s1("o") << "\n\n";
        std::cout << "Converting to int\n"
                  << "Length: " << (int)s1 << "\n\n";
        std::cout << "Moving contructor\n";
        String s2{std::move(s1)};
        std::cout << "New object\n"
                  << "Content: " << s2 << "\n"
                  << "Length: " << s2.len() << "\n"; 
        std::cout << "Old object\n"
                  << "Content: Cant display content because its nullptr\n"
                  << "Length: " << s1.len() << "\n"; 
    } else if (mode == "--array") 
    {
        Array arr1{10};
        arr1.randomize();
        std::cout << "Current array arr1: " << arr1 << "\n\n";
        Array arr2{std::move(arr1)};
        std::cout << "New object\n"
                  << "Content: " << arr2 << "\n"
                  << "Length: " << arr2.len() << "\n"; 
        std::cout << "Old object\n"
                  << "Content: Cant display content because its nullptr\n"
                  << "Length: " << arr1.len() << "\n"; 
    } else 
    {
        std::cerr << "Unknown mode: " << mode << "\n";
        return 1;
    }

    return 0;
}
