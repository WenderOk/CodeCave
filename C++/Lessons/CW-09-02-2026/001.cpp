#include <iostream>
#include <cstdio> // for FILE (optional for Windows)

int main()
{
    FILE *myFile;

    myFile = fopen("./data.txt", "a");

    if(!myFile)
    {
        std::cout << "Erroe while creating file!\n";
        return 1;
    }

    std::cout << "File created succefully!\n";

    // writing some data in file
    int num{ fprintf(myFile, "Hello мир\n") };

    if(num < 0)
    {
        std::cout << "Error while writing in file!\n";
        return 1;
    }
    std::cout << "Data succeffuly written into file!\n";

    int success{fclose(myFile)};
    if(success)
    {
        std::cout << "Error while closing file!\n";
        return 1;
    }

    std::cout << "File closed succefully!\n";

    return 0;
}
