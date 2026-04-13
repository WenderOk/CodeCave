#pragma once

class PhoneBook
{
    Abonent** abonents;
    int maxAbonNumber;
    
public:
    // Сделал статическим чтобы получать доступ к файлу до создания экземпляра класса
    static inline const char* fileName{"data.txt"};

    PhoneBook();
    PhoneBook(int abonentsNumber);
    ~PhoneBook();
    
    PhoneBook& addAbonent(Abonent* abonent);
    PhoneBook& deleteAbonent(int index);
    Abonent* getAbonent(int index)
    { return abonents[index]; }
    int findAbonent(const char name[]);
    void print();
    int saveToFile();
    int loadFromFile();
};