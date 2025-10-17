#include <iostream>

int main()
{
    const int secret{12};
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
    std::cout << "Games over!";

    return 0;
}