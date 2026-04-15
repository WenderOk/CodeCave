#include <iostream>
#include "Overcoat.h" 
#include "Flat.h"

void TestOvercoat()
{
    Overcoat coat{ClothType::coat, 2.54};
    Overcoat coat2{ClothType::coat, 87.45};
    Overcoat coat3{ClothType::jacket, 4.95};
 
    std::cout << "Overcoat 1: "
              << "\nType: " << coat.getStrType() 
              << "\nPrice: " << coat.getPrice() << "\n\n";

    std::cout << "Overcoat 2: "
              << "\nType: " << coat2.getStrType() 
              << "\nPrice: " << coat2.getPrice() << "\n\n";

    std::cout << "Overcoat 3: "
              << "\nType: " << coat3.getStrType() 
              << "\nPrice: " << coat3.getPrice() << "\n\n";

    std::cout << "Overcoat 2 > Overcoat 1: " << (coat2 > coat ? "True" : "False") << "\n";
    std::cout << "Overcoat 2 == Overcoat 1: " << (coat2 == coat ? "True" : "False") << "\n";
    std::cout << "Overcoat 2 == Overcoat 3: " << (coat2 == coat3 ? "True" : "False") << "\n";
    std::cout << "Executing coat3 = coat2...\n";
    coat3 = coat2;
    std::cout << "Overcoat 2 == Overcoat 3: " << (coat2 == coat3 ? "True" : "False") << "\n";
}

void TestFlat()
{
    Flat flat{25.45, 2.54};
    Flat flat2{25.45, 87.45};
    Flat flat3{78.12, 4.95};
 
    std::cout << "Flat 1: "
              << "\nArea: " << flat.getArea() 
              << "\nPrice: " << flat.getPrice() << "\n\n";

    std::cout << "OverFlatcoat 2: "
              << "\nArea: " << flat2.getArea() 
              << "\nPrice: " << flat2.getPrice() << "\n\n";

    std::cout << "Flat 3: "
              << "\nArea: " << flat3.getArea() 
              << "\nPrice: " << flat3.getPrice() << "\n\n";

    std::cout << "Flat 2 > Flat 1: " << (flat2 > flat ? "True" : "False") << "\n";
    std::cout << "Flat 2 == Flat 1: " << (flat2 == flat ? "True" : "False") << "\n";
    std::cout << "Flat 2 == Flat 3: " << (flat2 == flat3 ? "True" : "False") << "\n";
    std::cout << "Executing flat3 = flat2...\n";
    flat3 = flat2;
    std::cout << "Flat 2 == Flat 3: " << (flat2 == flat3 ? "True" : "False") << "\n";
}

int main()
{
    int choice{};
    while(choice != 3)
    {
        std::cout << "\n----MENU----\n"
                  << "1. Test Overcoat\n"
                  << "2. Test Flat\n"
                  << "3. Exit\n"
                  << "Choose class to test or exit: ";
        std::cin >> choice;

        switch(choice)
        {
            case 1:
                TestOvercoat();
                break;
            case 2:
                TestFlat();
                break;
            case 3:
                exit(0);
                break;
            default:
                std::cout << "Wrong choice!\n";
                break;
        }
    }
    return 0;

}