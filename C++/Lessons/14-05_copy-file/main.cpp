#include <iostream>

bool copyFile(char* source, char* destination)
{
    const int size{65536};

    FILE* src;
    FILE* dest;

    if(!(src = fopen(source, "rb")))
        return false;

    int handle{_fileno(src)};

    char* data{new char[size]};
    if(!data)
        return false;
    

    if(!(dest = fopen(destination, "wb")))
    {
        delete[] data;
        return false;
    }

    int realsize{};
    while(!feof(src))
    {
        realsize = fread(data, sizeof(char), size, src);
        fwrite(data , sizeof(char), realsize, dest);
    }

    return true;
}

int main()
{
    char* src{"\xF2\xE5\xEA\xF1\xF2.txt"};
    char* dest{"textDest.txt"};

    if(copyFile(src, dest))
        std::cout << "Succesefuly copied\n";
    else
        std::cout << "Error while copying\n";


    return 0;
}