#include <iostream>

int main()
{  
    int x{12};
    int y{10};
    int* px{ &x };

    // Constant pointer
    int* const px2{ &x }; // initialization required!
    // You cant modify constant pointer but you can modify variable that it points to
    *px2 = 50; 

    int z{45};
    // Pointer to constant variable
    const int* px3{ &z };

    const int* const px4{ &x };
    

    return 0;
}