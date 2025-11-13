#include <iostream>

// Шаблон фунцкий

template <typename T>
 int zero_count(T arr[], int n)
{
    int zeros{};

    for(int i{}; i < n; i++)
        if(arr[i] == 0)
            zeros++;
    return zeros;
}

int main()
{
    const int size{5};
    int arr1[size]{0,2,0,4,5};
    double arr2[size]{0.1,2.7,0.6,4.7,5.2};

    std::cout << zero_count<int>(arr1,5) << "\n";
    std::cout << zero_count<double>(arr2,5) << "\n";

    return 0;
}