#include <iostream>
#include <cstdio> // for FILE (optional for Windows)

int main()
{
    FILE *myFile;

    myFile = fopen("./data.txt", "r");

    if(!myFile)
    {
        std::cout << "Erroe while opening file!\n";
        return 1;
    }

    // writing some data in file
    const int size{256};
    char str[size];

    // while (fscanf(myFile, "%256[^\n]", str) > 0)
    // {
    //     std::cout << str;
    // }

    // while (fgets(str, size, myFile) != nullptr)
    // {
    //     std::cout << str;
    // }
    // std::cout << "\n";
    char ch{};
    while ((ch = fgetc(myFile)) != EOF)
        std::cout << ch;
    
    std::cout << "\n";

    int success{fclose(myFile)};
    if(success)
    {
        std::cout << "Error while closing file!\n";
        return 1;
    }


    return 0;
}
