#include <iostream>
 
int main()
{
    // char test[][3]{
    //     {'A','B','C'},
    //     {'A','B','C'},
    //     {'A','B','C'}
    // };
    char field[][10]{
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'},
        {'A','B','C','D','E','F','G','H','I','J'}
    };

    for(int i{}; i < 10; i++)
    {
        for(int j{}; j < 10; j++)
            std::cout << field[i][j] << i << " ";
        std::cout << "\n";
    }

    return 0;
}