#include <iostream>

void codeEditor(short p);
const short ORPHO{1};
const short DARK_BG{2};
const short WORD_PER{4};

int main()
{
    codeEditor(ORPHO | DARK_BG | WORD_PER);
    std::cout << "\n";
    codeEditor(DARK_BG | WORD_PER);
    std::cout << "\n";
    codeEditor(WORD_PER);

    return 0;
}

void codeEditor(short p)
{
    if(p & ORPHO)
        std::cout << "Orpho check enabled\n";
    else
        std::cout << "Orpho check disabled\n";

    if(p & DARK_BG)
        std::cout << "Dark BG enabled\n";
    else
        std::cout << "Dark BG disabled\n";

    if(p & WORD_PER)
        std::cout << "Word per enabled\n";
    else
        std::cout << "Word per disabled\n";
    
}