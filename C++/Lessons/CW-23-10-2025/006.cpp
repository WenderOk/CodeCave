#include <iostream>
#include <cstdlib>
#include <ctime>

int main()
{
    std::srand(std::time({}));
    
    int num{std::rand()};
    std::cout << num << "\n";

    num = std::rand();
    std::cout << num << "\n";

    num = std::rand();
    std::cout << num << "\n";

    std::cout << "Range of pseudo random numbers: [0, " << RAND_MAX << "]\n";
}