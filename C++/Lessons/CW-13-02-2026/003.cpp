#include <iostream>
#include <fstream>

struct Product
{
    char name[50];
    double amount;
    char unit[10];

};

int main()
{
    std::fstream fout("products.txt", std::ios::app);
    const int size{4};
    Product products[size]{
        {"Apple", 12.5, "kg"}, 
        {"Computer", 20, "item"},
        {"Pineapple", 102.46, "kg"},
        {"Phone", 50, "item"}
    };

    for(int i{}; i < size; i++)
    {
        fout << products[i].name << " "
             << products[i].amount << " "
             << products[i].unit << "\n";
    }

    fout.close();
    
    return 1;
}