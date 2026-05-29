#include <iostream>
#include "parts.h"

// класс, описывающий компьютер и его составляющие
class PC
{
    Box* box;             // корпус
    Processor* processor; // центральный процессор
    MainBoard* mainBoard; // материнская плата
    Hdd* hdd;             // жесткий диск
    Memory* memory;       // оперативная память
public:
    PC(): box{ nullptr }, processor{ nullptr }, mainBoard{ nullptr },
          hdd{ nullptr }, memory{ nullptr }
    {}
    virtual ~PC()
    {
        if (box) delete box;
        if (processor) delete processor;
        if (mainBoard) delete mainBoard;
        if (hdd) delete hdd;
        if (memory) delete memory;
    }
    Box* GetBox()
    {
        return box;
    }
    void SetBox(Box* pBox)
    {
        box = pBox;
    }
    Processor* GetProcessor()
    {
        return processor;
    }
    void SetProcessor(Processor* pProcessor)
    {
        processor = pProcessor;
    }
    MainBoard* GetMainBoard()
    {
        return mainBoard;
    }
    void SetMainBoard(MainBoard* pMainBoard)
    {
        mainBoard = pMainBoard;
    }
    Hdd* GetHdd()
    {
        return hdd;
    }
    void SetHdd(Hdd* pHdd)
    {
        hdd = pHdd;
    }
    Memory* GetMemory()
    {
        return memory;
    }
    void SetMemory(Memory* pMemory)
    {
        memory = pMemory;
    }
    void print()
    {
        box->print();
        processor->print();
        mainBoard->print();
        hdd->print();
        memory->print();
    }
};

// интерфейс фабрики для создания конфигурации ПК
class IPCFactory
{
public:
    virtual Box* CreateBox() = 0;
    virtual Processor* CreateProcessor() = 0;
    virtual MainBoard* CreateMainBoard() = 0;
    virtual Hdd* CreateHdd() = 0;
    virtual Memory* CreateMemory() = 0;
};

// конкретная фабрика для создания "домашней" конфигурации ПК
class HomePCFactory: public IPCFactory
{
public:
    Box* CreateBox()
    {
        return new SilverBox{};
    }
    Processor* CreateProcessor()
    {
        return new IntelProcessor{};
    }
    MainBoard* CreateMainBoard()
    {
        return new MSIMainBoard{};
    }
    Hdd* CreateHdd()
    {
        return new SamsungHDD{};
    }
    Memory* CreateMemory()
    {
        return new Ddr2Memory{};
    }
};

// конкретная фабрика для создания "офисной" конфигурации ПК
class OfficePCFactory: public IPCFactory
{
public:
    Box* CreateBox()
    {
        return new BlackBox{};
    }
    Processor* CreateProcessor()
    {
        return new AmdProcessor{};
    }
    MainBoard* CreateMainBoard()
    {
        return new AsusMainBoard{};
    }
    Hdd* CreateHdd()
    {
        return new LGHDD{};
    }
    Memory* CreateMemory()
    {
        return new DdrMemory{};
    }
};

// класс, конфигурирующий объект класса PC выбранным семейством составляющих
class PcConfigurator
{
    IPCFactory* pcFactory; // конкретная фабрика для конфигурации ПК
public:
    PcConfigurator(): pcFactory{ nullptr }
    {}
    virtual ~PcConfigurator()
    {
        if (pcFactory) delete pcFactory;
    }
    IPCFactory* GetPcFactory()
    {
        return pcFactory;
    }
    void SetPcFactory(IPCFactory* pConcreteFactory)
    {
        pcFactory = pConcreteFactory;
    }
    void Configure(PC* pc)
    {
        pc->SetBox(pcFactory->CreateBox());
        pc->SetProcessor(pcFactory->CreateProcessor());
        pc->SetMainBoard(pcFactory->CreateMainBoard());
        pc->SetHdd(pcFactory->CreateHdd());
        pc->SetMemory(pcFactory->CreateMemory());
    }
};

int main()
{
    // готовим компьютер для продажи
    // пока все его свойства заполняются nullptr (без комплектующих)
    PC pc;

    // покупатель выбирает из двух имеющихся конфигураций: домашняя или офисная
    // (мы можем добавить дополнительные конфигурации, если будет нужно)
    OfficePCFactory office;
    HomePCFactory home;

    // пусть покупатель выбрал домашнюю конфигурацию
    PcConfigurator configurator;
    //configurator.SetPcFactory(&home);
    configurator.SetPcFactory(&home);
    configurator.Configure(&pc);

    // покупатель проверяет заказанную комплектацию
    std::cout << "Укомплектованный компьютер:\n";
    pc.print();

    return 0;
}