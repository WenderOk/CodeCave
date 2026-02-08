#include <iostream>
#include <cstdio> // for FILE (optional for Windows)

int main()
{
    FILE *myFile;

    myFile = fopen("./данные.txt", "w");

    if(!myFile)
    {
        std::cout << "Erroe while creating file!\n";
        return 1;
    }

    std::cout << "File created succefully!\n";

    int success{fclose(myFile)};
    if(success)
    {
        std::cout << "Error while closing file!\n";
        return 1;
    }

    std::cout << "File closed succefully!\n";

    return 0;
}
