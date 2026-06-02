#pragma once

#include <iostream>
#include <string>
#include <fstream>
#include "Reservoir.h"

class ReservoirManager
{
    Reservoir* array;
    int count;
    int capacity;

    // Внутренний метод для увеличения емкости динамического массива
    void resize()
    {
        int newCapacity = (capacity == 0) ? 2 : capacity * 2;
        Reservoir* newArray = new Reservoir[newCapacity];
        
        for (int i = 0; i < count; ++i) {
            newArray[i] = array[i];
        }
        
        delete[] array;
        array = newArray;
        capacity = newCapacity;
    }

public:
    ReservoirManager() : array(nullptr), count(0), capacity(0)
    {}

    ~ReservoirManager()
    { delete[] array; }

    // Конструктор копирования для менеджера
    ReservoirManager(const ReservoirManager& other) : count(other.count), capacity(other.capacity)
    {
        if (capacity > 0) 
        {
            array = new Reservoir[capacity];
            for (int i = 0; i < count; ++i)
                array[i] = other.array[i];
            
        } else
            array = nullptr;
    }

    // Оператор присваивания для менеджера
    ReservoirManager& operator=(const ReservoirManager& other)
    {
        if (this != &other) 
        {
            delete[] array;
            count = other.count;
            capacity = other.capacity;
            
            if (capacity > 0) 
            {
                array = new Reservoir[capacity];
                for (int i = 0; i < count; ++i)
                    array[i] = other.array[i];
                
            } else 
                array = nullptr;
        }
        return *this;
    }

    void addReservoir(const Reservoir& res)
    {
        if (count == capacity)
            resize();

        array[count] = res;
        ++count;
    }

    void removeReservoir(int index)
    {
        if (index < 0 || index >= count) 
        {
            std::cerr << "Ошибка: некорректный индекс для удаления.\n";
            return;
        }
        
        for (int i = index; i < count - 1; ++i)
            array[i] = array[i + 1];
        --count;
    }

    void saveToTextFile(const std::string& filename) const
    {
        std::ofstream file(filename);
        if (!file.is_open()) 
        {
            std::cerr << "Ошибка открытия текстового файла для записи.\n";
            return;
        }

        for (int i = 0; i < count; ++i) 
        {
            file << array[i].getName() << "\n"
                 << array[i].getType() << "\n"
                 << array[i].getWidth() << "\n"
                 << array[i].getLength() << "\n"
                 << array[i].getMaxDepth() << "\n";
        }
        file.close();
    }

    void saveToBinaryFile(const std::string& filename) const
    {
        std::ofstream file(filename, std::ios::binary);
        if (!file.is_open()) 
        {
            std::cerr << "Ошибка открытия бинарного файла для записи.\n";
            return;
        }

        // Записываем количество объектов
        file.write(reinterpret_cast<const char*>(&count), sizeof(count));
        
        // Записываем каждый объект с помощью его метода сериализации
        for (int i = 0; i < count; ++i)
            array[i].writeBinary(file);
        
        file.close();
    }

    void displayAll() const
    {
        if (count == 0) 
        {
            std::cout << "Список водоемов пуст.\n";
            return;
        }
        
        for (int i = 0; i < count; ++i) 
        {
            std::cout << "--- Водоем #" << (i + 1) << " ---\n";
            array[i].display();
        }
    }
    
    const Reservoir& getReservoir(int index) const
    { return array[index]; }
    
    int getCount() const
    { return count; }
};