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
    Product products[size]{
        {"Apple", 12.5, "kg"}, 
        {"Computer", 20, "item"},
        {"Pineapple", 102.46, "kg"},
        {"Phone", 50, "item"}
    };

    file = fopen("products.txt", "a");
    for(int i{}; i < size; i++)
    {
        fprintf(file, "%s ", products[i].name);
        fprintf(file, "%.3f ", products[i].amount);
        fprintf(file, "%s\n", products[i].unit);
    }

    return 1;
}