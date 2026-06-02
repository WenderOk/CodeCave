#pragma once

#include <iostream>
#include <string>
#include <fstream>
#include <cstring>

class Reservoir
{
    char* name;
    std::string type;
    double width;
    double length;
    double maxDepth;

public:
    // Конструктор по умолчанию
    Reservoir() : name(nullptr), type("Неизвестно"), width(0.0), length(0.0), maxDepth(0.0)
    {}

    // Параметризированный конструктор (explicit предотвращает неявное преобразование типов)
    explicit Reservoir(const char* name, const std::string& type, double width, double length, double maxDepth)
        : type(type), width(width), length(length), maxDepth(maxDepth)
    {
        if (name != nullptr) 
        {
            this->name = new char[std::strlen(name) + 1];
            std::strcpy(this->name, name);
        } else 
        {
            this->name = new char[1];
            this->name[0] = '\0';
        }
    }

    // Конструктор копирования (глубокое копирование)
    Reservoir(const Reservoir& other)
        : type(other.type), width(other.width), length(other.length), maxDepth(other.maxDepth)
    {
        if (other.name != nullptr) 
        {
            this->name = new char[std::strlen(other.name) + 1];
            std::strcpy(this->name, other.name);
        } else
            this->name = nullptr;
        
    }

    ~Reservoir()
    { delete[] name; }

    Reservoir& operator=(const Reservoir& other)
    {
        if (this != &other) 
        {
            delete[] name;
            
            type = other.type;
            width = other.width;
            length = other.length;
            maxDepth = other.maxDepth;

            if (other.name != nullptr)
            {
                this->name = new char[std::strlen(other.name) + 1];
                std::strcpy(this->name, other.name);
            }
            else
                this->name = nullptr;
            
        }
        return *this;
    }

    double getVolume() const
    { return width * length * maxDepth; }

    double getSurfaceArea() const
    { return width * length; }

    bool isSameType(const Reservoir& other) const
    {
        if (type == other.type)
            return true;
        
        // В задаче почему-то бассейн = пруд, поэтому написал специальное условие для них
        if ((type == "бассейн" && other.type == "пруд") ||
            (type == "пруд" && other.type == "бассейн")) 
            return true;
        
        return false;
    }

    // 4. Сравнение площади поверхности (только для одного типа)
    // Возвращает: 1 (больше), -1 (меньше), 0 (равны), 2 (типы разные, сравнение некорректно)
    int compareSurfaceArea(const Reservoir& other) const
    {
        if (!isSameType(other))
            return 2;

        double area1 = getSurfaceArea();
        double area2 = other.getSurfaceArea();

        if (area1 > area2) 
            return 1;
        else if (area1 < area2)
            return -1;
        
        return 0;
    }

    // 5. Метод для копирования объектов (альтернатива оператору присваивания)
    void copyFrom(const Reservoir& other)
    { *this = other; }

    const char* getName() const { return name; }
    
    void setName(const char* newName)
    {
        delete[] name;
        if (newName != nullptr) 
        {
            name = new char[std::strlen(newName) + 1];
            std::strcpy(name, newName);
        } else 
        {
            name = new char[1];
            name[0] = '\0';
        }
    }

    const std::string& getType() const 
    { return type; }
    void setType(const std::string& newType) 
    { type = newType; }

    double getWidth() const 
    { return width; }
    void setWidth(double w) 
    { width = w; }

    double getLength() const 
    { return length; }
    void setLength(double l) 
    { length = l; }

    double getMaxDepth() const 
    { return maxDepth; }
    void setMaxDepth(double d) 
    { maxDepth = d; }

    void display() const
    {
        std::cout << "Название: " << (name ? name : "Без названия") << "\n"
                  << "Тип: " << type << "\n"
                  << "Размеры (Ш x Д x Г): " << width << " x " << length << " x " << maxDepth << " м\n"
                  << "Площадь поверхности: " << getSurfaceArea() << " м²\n"
                  << "Объем: " << getVolume() << " м³\n";
    }

    // Сериализация в бинарный поток (необходима для корректной записи char* и std::string)
    void writeBinary(std::ofstream& file) const
    {
        size_t nameLen = name ? std::strlen(name) : 0;
        file.write(reinterpret_cast<const char*>(&nameLen), sizeof(nameLen));
        if (nameLen > 0)
            file.write(name, nameLen);

        size_t typeLen = type.length();
        file.write(reinterpret_cast<const char*>(&typeLen), sizeof(typeLen));
        file.write(type.c_str(), typeLen);

        file.write(reinterpret_cast<const char*>(&width), sizeof(width));
        file.write(reinterpret_cast<const char*>(&length), sizeof(length));
        file.write(reinterpret_cast<const char*>(&maxDepth), sizeof(maxDepth));
    }
};