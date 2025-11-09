#include <iostream>
 
int count_digits(int number);
int sum_digits(int number);
double averege_of_digits(int number);
int count_zeroes(int number);

int main()
{
    int menu_item{};
    int number{};

    std::cout << "Enter a number: ";
    std::cin >> number;

    do
    {
        std::cout << "\nMENU\n"
                  << "1 - count digits\n"
                  << "2 - sum digits\n"
                  << "3 - average of digits\n"
                  << "4 - count zeros\n"
                  << "5 - exit\n";

        std::cout << "Choose operation: ";
        std::cin >> menu_item;

        switch (menu_item)
        {
            case 1:
            std::cout << "\nCount of digits: " << count_digits(number) << "\n";
            break;

            case 2:
            std::cout << "\nSum of digits: " << sum_digits(number) << "\n";
            break;
            
            case 3:
            std::cout << "\nAverage of digits: " << averege_of_digits(number) << "\n";
            break;

            case 4:
            std::cout << "\nCount of zeroes: " << count_zeroes(number) << "\n";
            break;

            case 5:
            std::cout << "\nExiting...\n";
            break;

            default:
            std::cout << "\nWrong menu item!\n";
            break;
        }
    }while(menu_item != 5);
    return 0;
}


int count_digits(int number)
{
    int count{};
    while(number > 0)
    {
        number /= 10;
        count++;
    }
    return count;
}

int sum_digits(int number)
{
    int sum{};
    while(number > 0)
    {
        sum += number % 10;
        number /= 10;
    }
    return sum;
}

double averege_of_digits(int number)
{
    return (sum_digits(number) / 1.0) / count_digits(number);
}

int count_zeroes(int number)
{
    int count{};
    while(number > 0)
    {
        if (number % 10 == 0) count++;
        number /= 10;
    }
    return count;
}
