#include <iostream>
#include <cstring>

////////////////////
// КЛАСС ЧЕЛОВЕКА //
////////////////////
class Person
{
    char* fio;
    int age;

    void allocateString(const char* str)
    {
        if (str != nullptr)
        {
            fio = new char[strlen(str) + 1];
            strcpy(fio, str);
        }
        else
        {
            fio = new char[1];
            fio[0] = '\0';       // Записываем нулевой символ чтобы программа не вылетела при случайном обращении к строке
        }
    }

public:
    Person() : age(0)
    { allocateString("Не указано"); }

    Person(const char* f, int a) : age(a)
    { allocateString(f); }

    Person(const Person& other) : age(other.age)
    { allocateString(other.fio); }

    ~Person()
    { delete[] fio; }

    Person& operator=(const Person& other)
    {
        if (this != &other)
        {
            delete[] fio;
            age = other.age;
            allocateString(other.fio);
        }
        return *this;
    }

    void print() const
    {
        std::cout << "  Жилец: " << fio << ", Возраст: " << age << '\n';
    }

    const char* getFio() const
    { return fio; }

    int getAge() const
    { return age; }
};


////////////////////
// КЛАСС КВАРТИРА //
////////////////////
class Apartment
{
    int number;
    Person* residents;
    int count;

public:
    Apartment() : number(0), residents(nullptr), count(0)
    {}

    Apartment(int num) : number(num), residents(nullptr), count(0)
    {}

    // Глубокое копирование массива жильцов
    Apartment(const Apartment& other) : number(other.number), count(other.count)
    {
        if (count > 0)
        {
            residents = new Person[count];
            for (int i = 0; i < count; ++i)
                residents[i] = other.residents[i];
        }
        else
            residents = nullptr;   
    }

    ~Apartment()
    { delete[] residents; }

    Apartment& operator=(const Apartment& other)
    {
        if (this != &other)
        {
            delete[] residents;
            number = other.number;
            count = other.count;
            if (count > 0)
            {
                residents = new Person[count];
                for (int i = 0; i < count; ++i)
                    residents[i] = other.residents[i];
            }
            else
                residents = nullptr;
        }
        return *this;
    }

    // Добавление жильца с перевыделением памяти
    void addResident(const Person& p)
    {
        Person* temp = new Person[count + 1];
        for (int i = 0; i < count; ++i)
            temp[i] = residents[i];
        
        temp[count] = p;

        delete[] residents;
        residents = temp;
        count++;
    }

    void print() const
    {
        std::cout << "Квартира №" << number << " (Жильцов: " << count << "):\n";
        for (int i = 0; i < count; ++i)
            residents[i].print();
    }

    int getNumber() const
    { return number; }
};


///////////////
// КЛАСС ДОМ //
///////////////
class Building
{
    char* address;
    Apartment* apartments;
    int count;

    void allocateString(const char* str)
    {
        if (str != nullptr)
        {
            address = new char[strlen(str) + 1];
            strcpy(address, str);
        }
        else
        {
            address = new char[1];
            address[0] = '\0';
        }
    }

public:
    Building() : apartments(nullptr), count(0)
    { allocateString("Адрес не указан"); }

    Building(const char* addr) : apartments(nullptr), count(0)
    { allocateString(addr); }

    Building(const Building& other) : count(other.count)
    {
        allocateString(other.address);
        if (count > 0)
        {
            apartments = new Apartment[count];
            for (int i = 0; i < count; ++i)
            {
                apartments[i] = other.apartments[i];
            }
        }
        else
        {
            apartments = nullptr;
        }
    }

    ~Building()
    {
        delete[] address;
        delete[] apartments;
    }

    Building& operator=(const Building& other)
    {
        if (this != &other)
        {
            delete[] address;
            delete[] apartments;

            allocateString(other.address);
            count = other.count;

            if (count > 0)
            {
                apartments = new Apartment[count];
                for (int i = 0; i < count; ++i)
                    apartments[i] = other.apartments[i];
            }
            else
                apartments = nullptr;
        }
        return *this;
    }

    void addApartment(const Apartment& apt)
    {
        Apartment* temp = new Apartment[count + 1];
        for (int i = 0; i < count; ++i)
            temp[i] = apartments[i];
        
        temp[count] = apt;

        delete[] apartments;
        apartments = temp;
        count++;
    }

    void print() const
    {
        std::cout << "ДОМ: " << address << " (Квартир: " << count << ")\n";
        for (int i = 0; i < count; ++i)
        {
            apartments[i].print();
            std::cout << "----------------------------------------\n";
        }
    }
};


int main()
{
    // Код дщля тестирования написал ИИ

    // Создаём жильцов
    Person p1("Иванов Иван Иванович", 35);
    Person p2("Петрова Мария Сергеевна", 28);
    Person p3("Сидоров Петр Алексеевич", 45);

    // Формируем квартиры
    Apartment apt1(10);
    apt1.addResident(p1);
    apt1.addResident(p2);

    Apartment apt2(11);
    apt2.addResident(p3);

    // Тест конструктора копирования квартиры
    std::cout << "--- Тест конструктора копирования Квартиры ---\n";
    Apartment apt1_copy = apt1;
    apt1_copy.addResident(Person("Тестов Тест Тестович", 20));

    std::cout << "Оригинал квартиры 10:\n";
    apt1.print();
    std::cout << "Копия квартиры 10 (с добавленным жильцом):\n";
    apt1_copy.print();
    std::cout << "------------------------------------------------\n\n";

    // Создаём дом и заселяем квартиры
    Building myHouse("г. Москва, ул. Программистов, д. 1");
    myHouse.addApartment(apt1);
    myHouse.addApartment(apt2);

    myHouse.print();

    // Тест конструктора копирования и оператора присваивания дома
    std::cout << "\n--- Тест конструктора копирования Дома ---\n";
    Building houseCopy = myHouse;

    Apartment apt3(12);
    apt3.addResident(Person("Новиков Новик Новикович", 22));
    houseCopy.addApartment(apt3);

    Building anotherHouse("г. Санкт-Петербург, Невский пр., д. 2");
    anotherHouse = houseCopy;

    std::cout << "Оригинальный дом:\n";
    myHouse.print();

    std::cout << "\nСкопированный и измененный дом:\n";
    anotherHouse.print();

    return 0;
}