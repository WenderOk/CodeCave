#include <iostream>

class NoSequence
{
    bool init;
    int prevEl;
public:
    NoSequence(): init{false}, prevEl{0}
    {}
    bool operator()(int el)
    {
        if(init)
        {
            bool result{prevEl != el };
            if(result)
                prevEl = el;
            return result;
        }
        init = true;
        prevEl = el;
        return true;
    }
};

class SumLimit
{
    int sumLimit;
    int sum;
public:
    SumLimit(int sumL, int startSum): sumLimit{sumL}, sum{startSum}
    {}
    SumLimit(int sL): SumLimit(sL, 0)
    {}
    bool operator()(int el)
    {
        if(sum + el < sumLimit)
        {
            sum += el;
            return true;
        }
        return false;
    }
};

template <typename T>
void print(T* begin, T* end, char delimeter = ' ')
{
    while (begin != end)
        std::cout << *begin++ << delimeter;
    std::cout << '\n';
}

template <typename T, typename Predicate>
int copy_if(T* beginS, T* endS, T* beginD, T* endD, Predicate pred)
{
    int count{};
    while (beginS != endS && beginD != endD)
    {
        if(pred(*beginS))
        {
            *beginD++ = *beginS;
            count++;
        }
        beginS++;
    }
    return count;
}

bool odd(const int el)
{ return el % 2 != 0; }

bool even(const int el)
{ return el % 2 == 0; }

bool all(const int el)
{ return true; }

int main()
{
    // const int size{5};
    // int arr1[size]{12,54,65,2,4};
    // int arr3[size]{};
    // // print(arr1, arr1+size);

    // double arr2[size]{1.54,4.23,5.543,54.76,33.5};
    // copy_if(arr1, arr1 + size, arr3, arr3 + size, even);
    // print(arr3, arr3+size);

    // int arr4[10]{13,543,67,34,32,65,23,654,534,65};
    // int arr5[5]{};
    // int n{copy_if(arr4, arr4+10, arr5, arr5+5, odd)};
    // print(arr5, arr5+n);

    int arr7[8]{};
    int arr6[10]{1,1,1,2,2,3,3,3,3,2};
    
    int n1{copy_if(arr6, arr6+8, arr7, arr7+10, NoSequence{})};   
    print(arr7, arr7+n1);

    int arr1[5]{1,1,1,3,1};
    int arr2[10]{};
    int n2{copy_if(arr1, arr1+5, arr2, arr2+10, SumLimit{5})};
    print(arr2, arr2+n2);

    return 0;
}