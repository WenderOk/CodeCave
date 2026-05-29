#ifndef PARTS_H_
#define PARTS_H_

#include <iostream>

//----- классы корпусов -----
class Box
{
public:
    virtual void print() = 0;
};

class SilverBox: public Box
{
public:
    void print()
    {
        std::cout << "  серебристый корпус\n";
    }
};

class BlackBox: public Box
{
public:
    void print()
    {
        std::cout << "  черный корпус\n";
    }
};

//----- классы центральных процессоров -----
class Processor
{
public:
    virtual void print() = 0;
};

class IntelProcessor: public Processor
{
public:
    void print()
    {
        std::cout << "  процессор Intel\n";
    }
};

class AmdProcessor: public Processor
{
public:
    void print()
    {
        std::cout << "  процессор AMD\n";
    }
};

//----- классы материнских плат -----
class MainBoard
{
public:
    virtual void print() = 0;
};

class MSIMainBoard: public MainBoard
{
public:
    void print()
    {
        std::cout << "  материнская плата MSI\n";
    }
};

class AsusMainBoard: public MainBoard
{
public:
    void print()
    {
        std::cout << "  материнская плата ASUS\n";
    }
};

//----- классы жестких дисков -----
class Hdd
{
public:
    virtual void print() = 0;
};

class SamsungHDD: public Hdd
{
public:
    void print()
    {
        std::cout << "  жесткий диск Sumsung\n";
    }
};

class LGHDD: public Hdd
{
public:
    void print()
    {
        std::cout << "  жесткий диск LG\n";
    }
};

//----- классы оперативной памяти -----
class Memory
{
public:
    virtual void print() = 0;
};

class Ddr2Memory: public Memory
{
public:
    void print()
    {
        std::cout << "  оперативная память DDR2\n";
    }
};

class DdrMemory: public Memory
{
public:
    void print()
    {
        std::cout << "  оперативная память DDR\n";
    }
};

#endif // PARTS_H_