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

    file = fopen("products.dat", "ab");

    for(int i{}; i < size; i++)
    {
        fwrite(products[i].name, 20, 1, file);
        fwrite(&products[i].amount, sizeof(double), 1, file);
        fwrite(products[i].unit, 20, 1, file);
    }

    return 1;
}