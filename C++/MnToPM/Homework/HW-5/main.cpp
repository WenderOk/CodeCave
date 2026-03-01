#include <iostream>
#include <cstdio>
#include "lib.h"
 
int main()
{
    const char* path{""}; // напишите сюда свой путь к файлу

    int res{countFileRows(path)};
    
    if(res < 0)
        std::cout << "File is empty or not existing\n";
    else
        std::cout << "The number of rows in file is: " << res << "\n";

    return 0;
}