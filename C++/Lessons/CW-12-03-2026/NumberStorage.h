#include <iostream>
#include <ctime>
#include <cstdlib>

class NumberStorage
{
private:
    int* arr;
    int n;
    static int mem_sum; 
public:
    NumberStorage(int nP): arr{new int[n]}, n{nP}
    {
        srand(time(nullptr));
        for(int i{}; i < n; i++)
            arr[i] = rand() % 10 + 1;
        size_t size{n * sizeof(int)};
        mem_sum += size;
        std::cout << "New instance of class was created\n"
                  << "Added: " << size << "\n"
                  << "Total: " << mem_sum << "\n";
    }
    ~NumberStorage()
    {
        delete[] arr;
        size_t size{n * sizeof(int)};
        mem_sum -= size;
        std::cout << "Instance of class was deleted\n"
                  << "Free: " << size << " \n"
                  << "Total: " << mem_sum << "\n";
    }

    static int getUsedMem()
    {
        return mem_sum;
    }

    void print()
    {
        for(int i{}; i < n; i++)
            std::cout << i << " ";
        std::cout << "\n";
    }

};

int NumberStorage::mem_sum{};
