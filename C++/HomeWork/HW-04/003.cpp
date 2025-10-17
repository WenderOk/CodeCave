#include <iostream>

int main()
{
    // Знаю чтл массивы мы еще не проходили, но мне просто очень не хотелось писать кучу ветвлений
    int numbers [7] {};
    int max{};

    for(int i = 0; i < 7; i++)
    {
        std::cout << "Enter number " << i+1 << ": ";
        std::cin >> numbers[i];
    }
    
    for(int i = 0; i < 7; i++)
    {
        if(numbers[i] > max)
        {
            max = numbers[i];
        }
    }

    std::cout << "Maximum number is: " << max << "\n";

    return 0;
}