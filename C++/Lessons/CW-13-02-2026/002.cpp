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

    file = fopen("products.dat", "rb");

    for(int i{}; i < size; i++)
    {
        fread(products[i].name, 20, 1, file);
        fread(&products[i].amount, sizeof(double), 1, file);
        fread(products[i].unit, 20, 1, file);

        std::cout << products[i].name << " " 
                  << products[i].amount << " "
                  << products[i].unit << "\n";

    }

    return 1;
}