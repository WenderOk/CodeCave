#include <iostream>

int main()
{
    const int num{10};
    int arr[num]{};
    double negSum{};

    for(int i{};i < num; i++)
    {
        std::cout << "Enter array element " << i << ": ";
        std::cin >> arr[i];
        if(arr[i] < 0)
            negSum += arr[i];
    }


    std::cout << negSum << "\n";

    return 0;
}