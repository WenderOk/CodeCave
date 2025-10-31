#include <iostream>

int main()
{
    const int num {31};
    double temps[num]{
    -7.5, -8.2, -9.1, -10.3, -11.4,
    -12.1, -11.8, -11.2, -10.6, -9.8,
    -9.1, -8.5, -8.0, -7.6, -7.2,
    -6.9, -6.7, -6.5, -6.3, -6.2,
    -6.1, -6.0, -5.9, -5.8, -5.7,
    -5.6, -5.5, -5.4, -5.3, -5.2,
    -5.1 };
    double sum{};
    double border{};
    int lowerCounter{};

    std::cout << "Enter number: ";
    std::cin >> border;

    for(int i{}; i < num; i++)
    {
        sum += temps[i];
        if(temps[i] < border)
            lowerCounter++;
    }

    std::cout << "Average temp: " << sum / num << "\n";
    std::cout << "Number of lower than border: " << lowerCounter << "\n";

    return 0;
}