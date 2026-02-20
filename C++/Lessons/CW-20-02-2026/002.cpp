#include <iostream>
#include <filesystem>
#include <algorithm>

void search(const std::filesystem::path& directory, const std::filesystem::path& filename)
    {
        auto d{std::filesystem::directory_iterator(directory)};
        
        auto found = std::find_if(d, end(d), [&](const auto& dir_entry)
        {
            return dir_entry.path().filename() == file_name;
        });
    }