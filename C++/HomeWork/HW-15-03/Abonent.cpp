#include <iostream>
#include <cstring>
#include "Abonent.h"

Abonent::Abonent():
    fullName{new char[1]{""}}, homePh{new char[1]{""}}, workPh{new char[1]{""}}, mobPh{new char[1]{""}}, addInfo{new char[1]{""}}
{}

Abonent::Abonent(const char fn[], const char hPh[], const char wPh[], const char mPh[], const char addInf[])
{
    processStringArgs(fullName, fn);
    processStringArgs(homePh, hPh);
    processStringArgs(workPh, wPh);
    processStringArgs(mobPh, mPh);
    processStringArgs(addInfo, addInf);
}

// Конструктор без дополнительной информации (addInfo). Раз она дополнительная то может не указываться.
Abonent::Abonent(const char fn[], const char hPh[], const char wPh[], const char mPh[]):
    Abonent(fn, hPh, wPh, mPh, "")
{}

Abonent::~Abonent()
{
    delete[] fullName;
    delete[] homePh;
    delete[] workPh;
    delete[] mobPh;
    delete[] addInfo;
}

// Чтобы не повторять процесс выделения памяти для каждого поля сделал отдельную функцию
void Abonent::processStringArgs(char* &field, const char arg[])
{
    field = new char[strlen(arg)+1];
    strcpy(field, arg);
}

void Abonent::print()
{
    std::cout << "| " << fullName << " | " << homePh << " | " << workPh << " | " << mobPh << " | " << (addInfo ? addInfo : " - ") << " |\n";
}