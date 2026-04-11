#include <iostream>
#include <fstream>
#include "Abonent.h"
#include "PhoneBook.h"
 
int main()
{
    std::ifstream file(PhoneBook::fileName);
    int abonNum{5};

    if(file.is_open())
        file >> abonNum;
    
    PhoneBook phb{abonNum};
    phb.loadFromFile();
    

    int choice{};
    while(choice != 5)
    {
        std::cout << "\n=====MENU=====\n"
                  << "1. Print abonents\n"
                  << "2. Add abonent\n"
                  << "3. Delete abonent\n"
                  << "4. Find abonent\n"
                  << "5. Exit\n"
                  << "Select action: ";
        
        std::cin >> choice;
        switch(choice)
        {
        case 1:
            phb.print();
            break;
        case 2:
            std::cin.ignore(100, '\n');
            char fullName[50], homePh[50], workPh[50], mobPh[50], addInfo[50];
            std::cout << "Enter Full name: ";
            std::cin.getline(fullName, 50);
            std::cout << "Enter home number: ";
            std::cin.getline(homePh, 50);
            std::cout << "Enter work number: ";
            std::cin.getline(workPh, 50);
            std::cout << "Enter mobile number: ";
            std::cin.getline(mobPh, 50);
            std::cout << "Enter additional info (optionaly): ";
            std::cin.getline(addInfo, 50);
            phb.addAbonent(new Abonent(fullName, homePh, workPh, mobPh, addInfo));
            phb.saveToFile();
            break;
        case 3:
            int idx;
            phb.print();
            std::cout << "Enter number of abonent to delete: ";
            std::cin >> idx;
            std::cin.ignore(1);
            phb.deleteAbonent(idx-1);
            phb.saveToFile();
            break;
        case 4:
            std::cin.ignore(100, '\n');
            char findName[50];
            std::cout << "Enter name of abonent to find: ";
            std::cin.getline(findName, 50);
            int res;
            res = phb.findAbonent(findName);
            if(res != -1)
            {
                std::cout << "Abonent found!\n";
                std::cout << "| ID | Name | Home num | Work num | Mobile num | Add. info |\n";
                std::cout << "------------------------------------------------------------\n";
                std::cout << "| " << res+1 << " ";
                phb.getAbonent(res)->print();
            }    
            else
                std::cout << "Abonent not found!\n";
            break;
        case 5:
            exit(0);
            break;
        default:
            std::cout << "Wrong option!\n";
            break;   
        }       
    }
    return 0;
}