#include <algorithm>
#include <array>
#include <chrono> 
#include <cstddef>
#include <numeric>

const int g_arrayElements{10000};

class Timer
{
    using Clock = std::chrono::steady_clock;
    using Second = std::chrono::duration<double, std::ratio<1>>;

    std::chrono::time_point<Clock> m_beg {Clock::now()};

public:
	void reset()
	{ m_beg = Clock::now(); }

	double elapsed() const
	{ return std::chrono::duration_cast<Second>(Clock::now() - m_beg).count(); }
};

void sosrtArray(std::array<int, g_arrayElements>& array)
{
    for (std::size_t startIndex{ 0 }; startIndex < (g_arrayElements - 1); startIndex++)
    {
        std::size_t smallestIndex{ startIndex };

        for (std::size_t currentIndex{ startIndex + 1 }; currentIndex < g_arrayElements; currentIndex++)
            if (array[currentIndex] < array[smallestIndex])
                smallestIndex = currentIndex; 
        
        std::swap(array[startIndex], array[smallestIndex]);
    }
}

