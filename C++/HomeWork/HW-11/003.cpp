#include <iostream>
 
bool is_perfect(int number);
void find_perfect(int a, int b);

int main()
{
    int a{};
    int b{};

    std::cout << "Enter range (a b): ";
    std::cin >> a >> b;
    
    find_perfect(a,b);
 
    return 0;
}

void find_perfect(int a, int b)
{
    int flag{};
    int sum{};
    if(a < b)
    {
        for(int i{a+1}; i < b; i++)
            if(is_perfect(i))
            {
                std::cout << "Found perfect number: " << i << "\n";
                flag=1;
            }
              
    }
    else
    {
        for(int i{a+1}; i < b; i++)
            if(is_perfect(i))
            {
                std::cout << "Found perfect number: " << i << "\n";
                flag=1;
            }
    }
    if(!flag)
        std::cout << "No perfect numbers were found...\n";
    else
        std::cout << "No more perfect numbers were found.\n";
}

bool is_perfect(int number)
{
    int sum{};
    for(int i{1}; i < number; i++)
        (number % i == 0) ? sum += i : sum += 0;
    
    return sum == number;
}