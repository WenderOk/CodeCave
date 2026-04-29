#include <vector>
#include <cstring>

template <class T>
class Matrix
{
    std::vector<T> list;
public:
    auto getMin()
    {
        auto min{list.begin()};
        for(auto i{list.begin()}; i < list.end(); i++)
            if(*min > *i)
                min = i;
        return *min;
    }
    auto getMax()
    {
        auto max{list.begin()};
        for(auto i{list.begin()}; i < list.end(); i++)
            if(*max < *i)
                max = i;
        return *max;
    }

    void add(T value)
    { list.push_back(value); }
    void remove(int index)
    { list.erase(list.begin() + index); }

};

template <>
class Matrix<const char*>
{
    std::vector<const char*> list;
public:
    auto getMin()
    {
        auto min{list.begin()};
        for(auto i{list.begin()}; i < list.end(); i++)
            if(strcmp(*i, *min) < 0)
                min = i;
        return *min;
    }
    auto getMax()
    {
        auto max{list.begin()};
        for(auto i{list.begin()}; i < list.end(); i++)
            if(strcmp(*i, *max) > 0)
                max = i;
        return *max;
    }

    void add(const char* value)
    { list.push_back(value); }
    void remove(int index)
    { list.erase(list.begin() + index); }

};