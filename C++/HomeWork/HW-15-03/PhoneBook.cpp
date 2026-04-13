#include "Abonent.h"
#include "PhoneBook.h"
#include <iostream>
#include <fstream>
#include <cstring>
#include <string>

// Использовал "магическое число" 10, потому что не захотел заморачиваться
// с глобальной переменной или константой класса PhoneBook
PhoneBook::PhoneBook(): maxAbonNumber{10} 
{ abonents = new Abonent*[maxAbonNumber]; }

PhoneBook::PhoneBook(int abonentsNumber): maxAbonNumber{abonentsNumber}
{
    abonents = new Abonent*[maxAbonNumber];
    for(int i{}; i < maxAbonNumber; i++) 
        abonents[i] = nullptr;
}

PhoneBook::~PhoneBook()
{ 
    if (abonents != nullptr)
    {
        for(int i{}; i < maxAbonNumber; i++)
        {
            if (abonents[i] != nullptr)
                delete abonents[i];
        }
        delete[] abonents;
    }
}

PhoneBook& PhoneBook::addAbonent(Abonent* abonent)
{
    // Сначала хотел сделать через вспомогательное поле, 
    // хранящиее индекс текущей свободной ячейки в массиве, 
    // но подмал что много ручного контроля придется делать
    // и решил просто сделать в лоб не заморачиваясь
    for(int i{}; i < maxAbonNumber; i++)
    {
        if(abonents[i] == nullptr)
        {
            abonents[i] = abonent; 
            return *this;
        }    
    }
    std::cout << "\nMaximum of abonents added!\n";
    return *this;
}

PhoneBook& PhoneBook::deleteAbonent(int index)
{
    if (abonents[index] != nullptr)
    {
        delete abonents[index];
        abonents[index] = nullptr;
    }
    return *this;
}

int PhoneBook::findAbonent(const char name[])
{
    for(int i{}; i < maxAbonNumber; i++)
    {
        if(strstr(abonents[i]->getFullName(), name))
            return i;
    }
    return -1;
}

void PhoneBook::print()
{
    std::cout << "| ID | Name | Home num | Work num | Mobile num | Add. info |\n";
    std::cout << "------------------------------------------------------------\n";
    for(int i{}; i < maxAbonNumber; i++)
        if (abonents[i] != nullptr)
        {
            std::cout << "| " << i+1 << " ";
            abonents[i]->print();
        }
}

int PhoneBook::saveToFile()
{
    std::ofstream file(fileName);
    if (!file.is_open()) return -1;
    
    file << maxAbonNumber << "\n";
    for (int i{}; i < maxAbonNumber; i++)
    {
        if(abonents[i] != nullptr)
        {
            file << abonents[i]->getFullName() << "\n";
            file << abonents[i]->getHomeNum() << "\n";
            file << abonents[i]->getWorkNum() << "\n";
            file << abonents[i]->getMobileNum() << "\n";
            file << abonents[i]->getAddInfo() << "\n";
        }
    }
    file.close();
    return 0;
}

int PhoneBook::loadFromFile()
{
    std::ifstream file(fileName);
    if (!file.is_open()) return -1;
    
    file >> maxAbonNumber;
    file.ignore(1);
    for (int i{}; i < maxAbonNumber; i++)
    {
        char fullName[50], homePh[50], workPh[50], mobPh[50], addInfo[50];
        file.getline(fullName, 50);
        file.getline(homePh, 50);
        file.getline(workPh, 50);
        file.getline(mobPh, 50);
        file.getline(addInfo, 50);
        addAbonent(new Abonent(fullName, homePh, workPh, mobPh, addInfo));
    }
    file.close();
    return 0;
}

