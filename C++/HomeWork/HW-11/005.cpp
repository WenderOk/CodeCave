#include <iostream>
 
bool is_happy(int number)
{
    int sum1{};
    int sum2{};

    for(int i{}; i < 6; i++)
    {
        i <= 2 ? sum1 += number % 10 : sum2 += number % 10;
        number /= 10;
    }
        
    return sum1 == sum2;
}

int main()
{
    int num{};
    std::cout << "Enter a 6-digit number: ";
    std::cin >> num;

    if(is_happy(num))
        std::cout << num << " is happy number!\n";
    else
        std::cout << num << " isnt happy number...\n";

    return 0;
}