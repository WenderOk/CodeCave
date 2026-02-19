#include <iostream>
#include <io.h>

int main()
{
    char* path("файл.txt"); // путь по которому искать файл

    struct _finddata_t fd; // структура хранящая результат поиска

    intptr_t res {_findfirst(path, &fd)};
    if(res < 0)
    {
        std::cout << "No files found";
        return 1;
    }

    std::cout << fd.name << " " << fd.size << "\n";

    while(_findnext(res, &fd) != -1)
    {
        std::cout << fd.name << " " << fd.size << "\n";
    }

    return 0;
}