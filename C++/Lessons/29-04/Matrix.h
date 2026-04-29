#include <cstring>
#include <iostream>

template <class T, int height, int width> 
class Matrix
{
    T m[height][width];
public:
    const auto& operator()(int j, int i) const
    {
        if(j < 0 || j >= height || i < 0 || i >= width)
        {
            std::cout << "Index out of range!\n";
            exit(1);
        }
        return m[j][i];
    }
    auto& operator()(int j, int i)
    {
        if(j < 0 || j >= height || i < 0 || i >= width)
        {
            std::cout << "Index out of range!\n";
            exit(1);
        }
        return m[j][i];
    }

    auto getMin()
    {
        auto min{m[0][0]};
        for(int j{}; j < height; j++)
            for(int i{}; i < width; i++)
                if(m[j][i] < min)
                    min = m[j][i];
        
        return min;
    }
    auto getMax()
    {
        auto max{m[0][0]};
        for(int j{}; j < height; j++)
            for(int i{}; i < width; i++)
                if(m[j][i] > max)
                    max = m[j][i];
        
        return max;
    }
};

template <int height, int width>
class Matrix<const char*, height, width>
{
    const char* m[height][width];
public:
    const auto& operator()(int j, int i) const
    {
        if(j < 0 || j >= height || i < 0 || i >= width)
        {
            std::cout << "Index out of range!\n";
            exit(1);
        }
        return m[j][i];
    }
    auto& operator()(int j, int i)
    {
        if(j < 0 || j >= height || i < 0 || i >= width)
        {
            std::cout << "Index out of range!\n";
            exit(1);
        }
        return m[j][i];
    }

    auto getMin()
    {
        auto min{m[0][0]};
        for(int j{}; j < height; j++)
            for(int i{}; i < width; i++)
                if(strcmp(m[j][i], min) < 0)
                    min = m[j][i];
        
        return min;
    }
    auto getMax()
    {
        auto max{m[0][0]};
        for(int j{}; j < height; j++)
            for(int i{}; i < width; i++)
                if(strcmp(m[j][i], max) > 0)
                    max = m[j][i];
        
        return max;
    }
};