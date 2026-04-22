#include <iostream>
#include <vector>
#include <algorithm> // для std::binary_search
#include <cmath>     // для std::sqrt
#include "Timer.h"

int main()
{
    Timer t;

    int N{500000}; // размер файла в байтах

    // получить входные данные
    // std::cin >> N;

    std::vector<int> primes; // массив простых чисел, меньших или равных N
    
    // перебрать все целые числа до N включительно
    // первое простое число: 2, поэтому начинаем перебор с 2
    for (int i{ 2 }; i <= N; i++)
    {
        // проверить, является ли число i простым
        // перебрать делители, начиная с 2 (на 1 все числа делятся)
        // и до i-1 включительно (на себя все числа делятся)
        bool isPrime{ true };
        int j{ 2 };
        for (; j < i; j++)
        {
            // если проверяемое число i делится без остатка на делитель j
            if (i % j == 0)
            {
                isPrime = false;
                break; // прервать проверку
            }
        }

        // если не найдено делителя, делящего число i без остатка
        if (isPrime)
        {
            primes.push_back(i); // запомнить простое число
        }
    }

    // есть теория, что четное число (большее 2) можно представить двумя
    // простыми числами
    if (N % 2 == 0)
    {
        if (N == 2)
        {
            std::cout << 1 << '\n'; // количество простых чисел
            std::cout << 2;
            std::cout << "Time elapsed: " << t.elapsed() << " seconds\n";
            return 0;
        }

        for (int i{}; primes[i] <= N / 2; i++)
        {
            int diff{ N - primes[i] };
            if (std::binary_search(primes.begin(), primes.end(), diff))
            {
                std::cout << 2 << '\n'; // количество простых чисел
                std::cout << primes[i] << ' ' << diff;
                std::cout << "Time elapsed: " << t.elapsed() << " seconds\n";
                return 0;
            }
        }
    }

    // есть теория, что нечетное число можно представить тремя простыми числами
    // или меньшим числом простых чисел (одним или двум)

    // если само нечетное число простое
    if (std::binary_search(primes.begin(), primes.end(), N))
    {
        std::cout << 1 << '\n'; // количество простых чисел
        std::cout << N;
        std::cout << "Time elapsed: " << t.elapsed() << " seconds\n";
        return 0;
    }

    // разложение нечетных чисел на два простых числа-слагаемых
    if (std::binary_search(primes.begin(), primes.end(), N - 2))
    {
        std::cout << 2 << '\n'; // количество простых чисел
        std::cout << 2 << ' ' << N - 2;
        std::cout << "Time elapsed: " << t.elapsed() << " seconds\n";
        return 0;
    }

    // разложение нечетных чисел на три простых числа-слагаемых
    std::cout << 3 << '\n'; // количество простых чисел
    std::cout << 3 << ' ';
    for (int i{}; i < N - 3; i++)
    {
        if (std::binary_search(primes.begin(), primes.end(), i) &&
            std::binary_search(primes.begin(), primes.end(), N - 3 - i))
        {
            std::cout << i << ' ' << N - 3 - i;
            break;
        }
    }

    std::cout << "Time elapsed: " << t.elapsed() << " seconds\n";

    return 0;
}