#include <iostream>

int main()
{
    int charCode;
    char ch;
    std::cout << "Please, enter a character: ";
    std::cin >> ch;
    charCode = (int)ch;

    if (((charCode >= 65)&&(charCode <= 90)) || ((charCode >= 97) && (charCode <= 122)))
        std::cout << "You entered a letter\n";

    else if ((charCode >= 48) && (charCode <= 57))
        std::cout << "You entered a digit\n";
    
    else if ((charCode == 33) || ((charCode >= 44) && 
    (charCode<=46)) || (charCode == 58) || 
    (charCode == 59) || (charCode == 63))
        std::cout << "You entered a punctuation mark\n";
    else
        std::cout << "You entered an unknown symbol\n";
    
    return 0;
}