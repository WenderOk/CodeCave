#include <iostream>

union unionData
{
    short int field1;
    int field2;
};

int main()
{
    unionData ud;
    ud.field2 = 100'000;

    std::cout << ud.field1 << "\n";
    std::cout << ud.field2 << "\n";

    return 0;
}

