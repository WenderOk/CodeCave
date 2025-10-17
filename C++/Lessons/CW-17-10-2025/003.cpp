#include <iostream>

int main()
{
    int start{};
    int end{};
    int sum{};

    std::cout << "Enter start and end of range: ";
    std::cin >> start >> end;

    if(start > end)
    {
        int tmp{end};
        end = start;
        start = tmp;
    }
    for(int i = start; i <= end; i++)
    {
            sum += i;
    }

    std::cout << "Summ: " << sum << "\n";

    return 0;
}