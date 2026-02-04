#include <iostream>
#include <ctime>
#include <iomanip>

double calc_pi(int n);

int main()
{
    int n{};
    std::cout << "Enter N: ";
    std::cin >> n;
    int t_start = time(nullptr);
    std::cout << "Result: " << calc_pi(n) << "\n";
    std::cout << "Time: " << time(nullptr) - t_start << "\n";
}

double calc_pi(int n)
{
    double res{};
    for(int i{}; i < n; i++)
    {
        double t1 = 4.0/(8 * i + 1);
        double t2 = 2.0/(8 * i + 4);
        double t3 = 1.0/(8 * i + 5);
        double t4 = 1.0/(8 * i + 6);
        double t5 = 1.0/(pow(16, i));

        res += t5 * (t1 - t2 - t3 - t4);
    }
    return res;
}