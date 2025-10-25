#include <iostream>
#include <cstdlib> // for std::rand, std::srand, RAND_MAX 
#include <ctime> // for std::time()

int main()
{
    std::srand(std::time({})); // seed
    int secret{std::rand() % 100 +1};
    const int maxAttempts{5};
    int number{};
    int attempts{1};

    do
    {
        std::cout << "Guess the number: ";
        std::cin >> number;

        if (number < secret)
        {
            std::cout << "Secret number is bigger\n";
        }
        else if (number > secret)
        {
            std::cout << "Secret number is smaller\n";
        }
        else
        {
            std::cout << "You won!\n"
                      << "It took you " << attempts << " tries\n";
            return 0;
        }
        attempts++;

    } while(attempts < maxAttempts);
    std::cout << "Games over!\nGueesed number: " << secret << "\n";

    return 0;
}