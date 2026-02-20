#include <filesystem>
#include <iostream>
#include <string>
#include <sys/stat.h>

int main()
{
    std::string path(".");

    struct stat sb;

    for (const auto& entry : std::filesystem::directory_iterator(path))
    {
        std::filesystem::path outfilename = entry.path();
        std::string outfilename_str = outfilename.string();
        const char* path = outfilename_str.c_str();

        if (stat(path, &sb) == 0 && !(sb.st_mode & S_IFDIR))
            std::cout << path << "\n";
    }
}