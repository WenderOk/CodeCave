#include <iostream>
#include <string>
#include "Reservoir.h"
#include "ReservoirManager.h"


int main()
{
    // Демонстрация работы класса Reservoir
    Reservoir r1("Байкал", "озеро", 1000.0, 636.0, 1642.0);
    Reservoir r2("Каспийское", "море", 1200.0, 1030.0, 1025.0);
    
    // Демонстрация конструктора копирования
    Reservoir r3(r1);
    r3.setName("Байкал (копия)");

    std::cout << "Проверка типа (Байкал и Каспийское): " 
              << (r1.isSameType(r2) ? "Да" : "Нет") << "\n";

    std::cout << "Сравнение площадей (Байкал и его копия): ";
    int cmp = r1.compareSurfaceArea(r3);
    
    if (cmp == 0) 
        std::cout << "Площади равны\n";
    else if (cmp == 1)  
        std::cout << "Площадь первого больше\n";
    else 
        std::cout << "Площадь второго больше\n";

    std::cout << "\n";

    // Демонстрация работы менеджера (динамический массив)
    ReservoirManager manager;

    manager.addReservoir(r1);
    manager.addReservoir(r2);
    
    Reservoir r4("Городской", "бассейн", 25.0, 50.0, 2.0);
    Reservoir r5("Дачный", "пруд", 30.0, 40.0, 1.5);
    
    manager.addReservoir(r4);
    manager.addReservoir(r5);

    std::cout << "Все водоемы в системе:\n";
    manager.displayAll();

    std::cout << "\nУдаление водоема с индексом 1 (Каспийское)...\n";
    manager.removeReservoir(1);
    
    std::cout << "Список после удаления:\n";
    manager.displayAll();

    // Запись в файлы
    manager.saveToTextFile("reservoirs.txt");
    manager.saveToBinaryFile("reservoirs.dat");
    
    std::cout << "\nДанные успешно сохранены в reservoirs.txt и reservoirs.bin\n";

    return 0;
}