#include <iostream>
#include <vector>
#include <algorithm>
#include "Timer.h"

int main() {
    int N{};
    std::cin >> N;
    Timer t;

    if (N < 2) return 0;

    // 1. Решето Эратосфена (очень быстро находит все простые до N)
    std::vector<bool> is_prime(N + 1, true);
    is_prime[0] = is_prime[1] = false;
    for (int p = 2; p * p <= N; p++) {
        if (is_prime[p]) {
            for (int i = p * p; i <= N; i += p)
                is_prime[i] = false;
        }
    }

    // Собираем список простых чисел для быстрого перебора
    std::vector<int> primes;
    for (int i = 2; i <= N; i++) {
        if (is_prime[i]) primes.push_back(i);
    }

    // 2. Логика разложения
    // Случай 1: Число само по себе простое
    if (is_prime[N]) {
        std::cout << "1\n" << N << std::endl;
    } 
    // Случай 2: Четное число или N-2 - простое (сумма двух)
    else if (N % 2 == 0 || is_prime[N - 2]) {
        for (int p : primes) {
            if (is_prime[N - p]) {
                std::cout << "2\n" << p << " " << N - p << std::endl;
                break;
            }
        }
    } 
    // Случай 3: Нечетное число (сумма трех)
    else {
        // По теореме Виноградова любое нечетное > 5 — сумма трех простых.
        // Самый простой способ: вычесть 3 и свести к четному (сумме двух).
        std::cout << "3\n3 ";
        int target = N - 3;
        for (int p : primes) {
            if (is_prime[target - p]) {
                std::cout << p << " " << target - p << std::endl;
                break;
            }
        }
    }

    std::cout << "Time elapsed: " << t.elapsed() << " seconds" << std::endl;
    return 0;
}
