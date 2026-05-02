#include <iostream>
#include <vector>
#include <algorithm>
#include "Timer.h"

void calc(int N)
{
    if (N < 2) return;

    // 1. Решето Эратосфена (очень быстро находит все простые до N)
    std::vector<bool> is_prime(N + 1, true);
    is_prime[0] = is_prime[1] = false;
    for (int p = 2; p * p <= N; p++) 
    {
        if (is_prime[p]) 
        {
            for (int i = p * p; i <= N; i += p)
                is_prime[i] = false;
        }
    }

    // Собираем список простых чисел для быстрого перебора
    std::vector<int> primes;
    for (int i = 2; i <= N; i++)
        if (is_prime[i]) primes.push_back(i);

    // 2. Логика разложения
    // Случай 1: Число само по себе простое
    if (is_prime[N])
        std::cout << "Res: \n" << "1\n" << N << '\n';
    
    // Случай 2: Четное число или N-2 - простое (сумма двух)
    else if (N % 2 == 0 || is_prime[N - 2]) 
    {
        for (int p : primes) 
        {
            if (is_prime[N - p]) 
            {
                std::cout << "Res: \n" << "2\n"  << p << " " << N - p << '\n';
                break;
            }
        }
    } 
    // Случай 3: Нечетное число (сумма трех)
    else 
    {
        int target = N - 3;
        for (int p : primes) {
            if (is_prime[target - p]) {
                std::cout << "Res: \n3\n" 
                            << 3 << " " << p << " " << target - p << '\n';
                break;
            }
        }
    }
}

int main() 
{
    int Ns[5]{17, 100, 15, 27, 1000000};
    
    for(int i{}; i < 5; i++)
    {
        Timer t;
        calc(Ns[i]);
        std::cout << "Time elapsed: " << t.elapsed() << " seconds" << '\n';
        std::cout << "-----------------------------------------------\n";
    }

    return 0;
}
