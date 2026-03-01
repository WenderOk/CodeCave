#include <iostream>
#include <cstdio>

int countFileRows(const char* path)
{
    FILE* file = fopen(path, "r");
    if (!file) return -1; // Если файл не смог открыться возращаем ошибку

    int res{};
    int ch{};
    int lastChar{EOF};

    while ((ch = fgetc(file)) != EOF) 
    {
        if (ch == '\n') res++;
        lastChar = ch;
    }

    // Если файл не пуст и не заканчивается переводом строки,
    // то последняя строка тоже должна быть учтена.
    if (lastChar != EOF && lastChar != '\n') res++;

    fclose(file);
    return res;
}