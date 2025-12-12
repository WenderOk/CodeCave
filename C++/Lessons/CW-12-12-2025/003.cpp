#include <iostream>
#include <cstdlib>

char* month_name(int n);

int main()
{
    int n{};
    std::cout << "Enter month number: ";
    std::cin >> n;
    std::cout << month_name(n) << '\n';
    return 0;
}

char* month_name(int n)
{
    char* months[12]{
        "January", "February", "March", "April",
        "May", "June", "July", "August",
        "September", "October", "November", "December"
    };
    if(n < 1 || n > 12)
        {
            std::cout << "Wrong month number!\n";
            std::exit(1);
        }
    else
        return months[n-1];
}