#include <iostream>

template <typename T> T max_in_arr(T arr[], int len);
int max_in_arr(int arr[][5], int len, int wid);
int max_in_arr(int arr[][5][5], int len, int wid, int dep);

int main()
{
    const int len{5};
    const int wid{5};
    const int dep{5};

    int arr1[len]{32,21,652,136,453};
    double arrD[len]{32.1,21.65,65.312,13.86,45.043};

    int arr2[len][wid]
    {
    {1,21,65,123,6},
    {1,21,65,45,6},
    {1,21,9,5,1},
    {1,21,65,1,54},
    {1,21,4563,123,4}
    };

    int arr3[len][wid][dep]
    {
    {{1,21,65,123,7654},{1,21,67,123,7654},{1,21,65,123,7654},{1,21,65,123,7654},{1,21,65,123,7654}},
    {{1,21,65,5676,9},{1,21,65,123,7654},{1,21,65,123,7654},{1,21,65,45,7654},{1,21,65,123,7654}},
    {{1,21,234,353,7654},{1,21,65,123,7654},{234,21,65,123,7654},{1,21,65,123,7654},{1,21,65,123,7654}},
    {{1,21,65,123,7654},{1,21,65,123,7654},{1,21,65,123,7654},{1,21,65,123,65},{1,21,65,123,87}},
    {{1,23,65,123,543},{1,21,54,123,7654},{1,21,65,123,7654},{1,789,65,123,7654},{1,21,65,123,7654}}
    };
    
    std::cout << max_in_arr(arr1, len) << "\n";
    std::cout << max_in_arr(arrD, len) << "\n";
    std::cout << max_in_arr(arr2, len, wid) << "\n";
    std::cout << max_in_arr(arr3, len, wid, dep) << "\n";

    return 0;
}

template <typename T> T max_in_arr(T arr[], int len)
{
    int mx_i{};
    for(int i{1}; i < len; i++)
        if (arr[mx_i] < arr[i])
            mx_i = i;
    return arr[mx_i];
}

int max_in_arr(int arr[][5], int len, int wid)
{
    int mx_i{};
    int mx_j{};
    for(int i{}; i < len; i++)
        for(int j{}; j < wid; j++)
            if (arr[mx_j][mx_i] < arr[j][i])
                {
                    mx_i = i;
                    mx_j = j;
                }
                
    return arr[mx_j][mx_i];
}

int max_in_arr(int arr[][5][5], int len, int wid, int dep)
{
    int mx_i{};
    int mx_j{};
    int mx_l{};
    
    for(int i{}; i < len; i++)
        for(int j{}; j < wid; j++)
            for(int l{}; l < dep; l++)
                if (arr[mx_j][mx_i][mx_l] < arr[j][i][l])
                    {
                        mx_i = i;
                        mx_j = j;
                        mx_l = l;
                    }
                
    return arr[mx_j][mx_i][mx_l];
}