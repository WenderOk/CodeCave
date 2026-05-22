#include <iostream>

namespace dragon
{
    int gold{50};
}


int main()
{
    using dragon::gold;
    std::cout << gold << '\n';

    return 0;
}