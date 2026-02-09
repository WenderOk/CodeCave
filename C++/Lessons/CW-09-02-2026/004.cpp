#include <iostream>

struct Product
{
    char name[50];
    double amount;
    char unit[10];
};

int main()
{
    FILE* file;
    const int size{4};
    Product products[size]{};

    const int size{256};
    char str[size];

    file = fopen("products.txt", "r");

    int res{};
    for(int i{}; i < size; i++)
    {
        res = fscanf(file, "%s %.3f %s\n",
                    products[i].name, products[i].amount, products[i].unit);
        std::cout << products[i].name << " "
                  << products[i].amount << " "
                  << products[i].unit << "\n";
    }

    return 1;
}